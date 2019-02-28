using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Services;
using X.PagedList;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(Repository repository) : base(repository)
        {
        }

        public override object GetDataRows()
        {
            var laaa = GetList("Name", "", 2).Result;

            return this._repository.GetProducts().ToPagedList(1, 2);
        }

        public override object GetDataRow(int id)
        {
            return this._repository.GetProduct(id);
        }

        public override object CreateNewRow()
        {
            return this._repository.CreateProduct();
        }

        public override void SetViewBag()
        {
            var brands = this._repository.GetBrands();
            ViewBag.BrandList = new SelectList(brands, "ID", "Name");
        }

        [Route("api/table")]
        public virtual ActionResult GetMyTable(string s)
        {
            var d = this._repository.GetProducts();

            if (!string.IsNullOrEmpty(s))
                d = d.Where(x => x.Name.Contains(s));

            return View("mytable", d.ToList());
        }

        public async Task<Lib.PaginatedList<Data.Entities.Product>> GetList(string sortOrder, string searchString, int? pageIndex)
        {
            var q = this._repository.GetProducts().Where(x => x.Name.Contains(searchString) || x.NameFa.Contains(searchString));

            switch (sortOrder)
            {
                case "Name":
                    q = q.OrderBy(s => s.Name);
                    break;
                case "Name_desc":
                    q = q.OrderByDescending(s => s.Name);
                    break;
                case "NameFa":
                    q = q.OrderBy(s => s.NameFa);
                    break;
                case "NameFa_desc":
                    q = q.OrderByDescending(s => s.NameFa);
                    break;
            }

            int pageSize = 2;
            var lst = await Lib.PaginatedList<Data.Entities.Product>.CreateAsync(q, pageIndex ?? 1, pageSize);

            return lst;
        }


        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Data.Entities.Product p)
        {
            try
            {
                this._repository.AddProduct(p);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Data.Entities.Product p)
        {
            try
            {
                this._repository.EditProduct(p);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Data.Entities.Product p)
        {
            try
            {
                this._repository.DeleteProduct(p.ID);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}