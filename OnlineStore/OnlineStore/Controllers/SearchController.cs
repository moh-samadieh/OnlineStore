using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly OnlineStoreContext _context;

        public SearchController(Data.OnlineStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index(string category)
        {
            var cats = this._context.Query<Data.Procedures.GetChildCategories>()
                .FromSql("EXEC dbo.GetChildCategories @p0", category).ToList();

            var catParent = cats.Where(x => x.Kind == 1).ToList();
            var catChild = cats.Where(x => x.Kind == 2).Select(x => x.ID).ToList();

            var plist = this._context.CategoryProducts
                .Where(x => catChild.Contains(x.CategoryID))
                .Select(x => x.Product)
                .Include(x => x.Brand);

            return View(plist);
        }
    }
}
