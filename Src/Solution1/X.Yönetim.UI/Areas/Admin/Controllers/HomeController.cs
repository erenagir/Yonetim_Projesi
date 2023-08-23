﻿using Microsoft.AspNetCore.Mvc;

namespace X.Yönetim.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Header = "X yönetim";
            ViewBag.Title = "Yönetim Paneli";
            return View();
        }
    }
}
