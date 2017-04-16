﻿using Baskerville.Data;
using Baskerville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.App.Controllers
{
    public class MenuController : Controller
    {
        MenuService service;

        public MenuController()
        {
            this.service = new MenuService(new BaskervilleContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var html = this.service.GetMenuHtml(false);
            return View(html);
        }
    }
}