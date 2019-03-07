using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class BrandController : BaseController
    {
        public BrandController(Repository repository, IHostingEnvironment hostingEnvironment) : base(repository, hostingEnvironment)
        {
        }

        public IEnumerable<OnlineStore.Data.Entities.Brand> GetAll()
        {
            return _repository.GetBrands();
        }
    }
}