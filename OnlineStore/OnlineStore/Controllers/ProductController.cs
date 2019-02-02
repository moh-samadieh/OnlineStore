using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly Repository _repository;

        public ProductController(Services.Repository repository)
        {
            this._repository = repository;
        }

        public IActionResult Index(int ID)
        {
            var p = this._repository.GetProduct(ID);

            if (p == null)
                return NotFound();

            return View(p);
        }
    }
}