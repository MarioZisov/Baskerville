﻿using Baskerville.Data;
using Baskerville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.App.Controllers
{
    public class SubscribersController : Controller
    {
        private SubscribersService service;

        public SubscribersController()
        {
            this.service = new SubscribersService(new BaskervilleContext());
        }

        // GET: Subscribers
        public ActionResult Index()
        {
            var model = this.service.GetActiveSubscribers();
            return View(model);
        }

    }
}