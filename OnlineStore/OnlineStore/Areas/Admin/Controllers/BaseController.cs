using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Services;

namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class BaseController : Controller
    {
        public readonly Repository _repository;
        public readonly IHostingEnvironment _hostingEnvironment;

        public BaseController(Repository repository, IHostingEnvironment hostingEnvironment)
        {
            this._repository = repository;
            this._hostingEnvironment = hostingEnvironment;
        }

        // GET: Product
        public virtual ActionResult Index(int page = 1, string search = "", string sort = "")
        {
            search = search ?? "";

            var m = GetDataRows(page, search, sort);

            ViewBag.Search = search;

            return View(m);
        }

        // GET: Product/Details/5
        public virtual ActionResult Details(int id)
        {
            var m = GetDataRow(id);
            return View(m);
        }

        // GET: Product/Delete/5
        public virtual ActionResult Delete(int id)
        {
            var m = GetDataRow(id);
            return View(m);
        }

        // GET: Product/Create
        public virtual ActionResult Create()
        {
            this.SetViewBag();

            var m = CreateNewRow();
            return View(m);
        }

        // GET: Product/Edit/5
        public virtual ActionResult Edit(int id)
        {
            this.SetViewBag();

            var m = GetDataRow(id);
            return View(m);
        }

        public virtual object GetDataRows(int page = 1, string search = "", string sort = "")
        {
            return null;
        }

        public virtual object GetDataRow(int id)
        {
            return null;
        }

        public virtual void SetViewBag()
        {
        }

        public virtual object CreateNewRow()
        {
            return null;
        }


        //// POST: Product/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Data.Entities.Product p)
        //{
        //    try
        //    {
        //        this._repository.AddProduct(p);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Product/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Product/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Data.Entities.Product p)
        //{
        //    try
        //    {
        //        this._repository.EditProduct(p);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //// POST: Product/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(Data.Entities.Product p)
        //{
        //    try
        //    {
        //        this._repository.DeleteProduct(p.ID);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}