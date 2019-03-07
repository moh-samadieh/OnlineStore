using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Areas.Admin.ViewModels;
using OnlineStore.Services;
using X.PagedList;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(Repository repository, IHostingEnvironment hostingEnvironment) : base(repository, hostingEnvironment)
        {
        }

        public override object GetDataRows(int page, string search, string sort)
        {
            //  this._repository.GetProducts().ToPagedList(1, 2);

            var lst = GetList(sort, search, page);

            return lst;
        }

        public override object GetDataRow(int id)
        {
            var p = this._repository.GetProduct(id);

            var m = new ProductViewModel { Product = p };

            var images = _repository.GetProductImages(id);

            m.Images = images.Select(x => x.ProductID + "-" + x.ID).ToList();

            return m;
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

        public IPagedList GetList(string sortOrder, string searchString, int? pageIndex)
        {
            var q = this._repository.GetProducts().Where(x => x.Name.Contains(searchString) || x.NameFa.Contains(searchString));

            switch (sortOrder.ToLower())
            {
                case "":
                case "name":
                    q = q.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    q = q.OrderByDescending(s => s.Name);
                    break;
                case "namefa":
                    q = q.OrderBy(s => s.NameFa);
                    break;
                case "namefa_desc":
                    q = q.OrderByDescending(s => s.NameFa);
                    break;
                case "brand":
                    q = q.OrderBy(s => s.Brand.Name);
                    break;
                case "brand_desc":
                    q = q.OrderByDescending(s => s.Brand.Name);
                    break;
            }

            int pageSize = 2;

            var lst = q.ToPagedList(pageIndex ?? 1, pageSize);

            //var lst = await Lib.PaginatedList<Data.Entities.Product>.CreateAsync(q, pageIndex ?? 1, pageSize);

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

        public ContentResult GetProductCategories(int pid)
        {
            var cats = _repository.GetProductCategories(pid).Select(x => x.Name).ToList(); ;

            string r = "<li class=\"list-group-item\">" + string.Join("</li><li class=\"list-group-item\">", cats) + "</li>";

            return new ContentResult { Content = r };
        }

        public JsonResult GetTree(string query, int pid)
        {
            var lst = _repository.GetCategories().ToList();

            var lstproductcats = _repository.GetProductCategories(pid).Select(x => x.ID).ToList();

            var records = lst.Where(l => l.CategoryParentID == null).OrderBy(l => l.ID)
                .Select(x => new CategoryTreeViewModel
                {
                    ID = x.ID,
                    Text = x.Name,
                    Checked = lstproductcats.Contains(x.ID),
                    Children = GetChildren(lst, x.ID, lstproductcats)
                }).ToList();

            return this.Json(records);
        }

        private List<CategoryTreeViewModel> GetChildren(List<Data.Entities.Category> lst, int parentId, List<int> lstproductcats)
        {
            var records = lst.Where(l => l.CategoryParentID == parentId).OrderBy(l => l.ID)
                .Select(x => new CategoryTreeViewModel
                {
                    ID = x.ID,
                    Text = x.Name,
                    Checked = lstproductcats.Contains(x.ID),
                    Children = GetChildren(lst, x.ID, lstproductcats)
                }).ToList();

            return records;
        }

        [HttpPost]
        public JsonResult SaveCheckedNodes(List<int> checkedIds, int pid)
        {
            var lst = _repository.UpdateProductCategories(pid, checkedIds);

            return this.Json(true);
        }

        public IActionResult GetImage(string img)
        {
            var file  = _hostingEnvironment.ContentRootPath + "\\ProductImages\\" + img + ".jpg";

            if (!System.IO.File.Exists(file))
                return NotFound();

            var image = System.IO.File.OpenRead(file);
            return File(image, "image/jpeg");
        }
    }
}