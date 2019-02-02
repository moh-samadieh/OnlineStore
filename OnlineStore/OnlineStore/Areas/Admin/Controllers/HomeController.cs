using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Services;
using _OnlineStore.Data.Entities;

namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<MyUser> _usermanager;
        private readonly RoleManager<MyRole> _rolemanager;
        private readonly Repository _repository;

        public HomeController(UserManager<MyUser> usermanager, RoleManager<MyRole> rolemanager, Repository repository)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        private void CreateRoles()
        {
            var roleName = "admin";

            var roleExist = _rolemanager.RoleExistsAsync(roleName).Result;
            if (!roleExist)
            {
                _rolemanager.CreateAsync(new MyRole { Name = roleName }).Wait();
            }

            var currentuser = _usermanager.GetUserAsync(HttpContext.User).Result;

            _usermanager.AddToRoleAsync(currentuser, "admin").Wait();
        }
    }
}