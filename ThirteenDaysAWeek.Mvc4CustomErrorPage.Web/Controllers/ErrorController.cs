﻿using System;
using System.Web.Mvc;
using ThirteenDaysAWeek.Mvc4CustomErrorPage.Web.Models;

namespace ThirteenDaysAWeek.Mvc4CustomErrorPage.Web.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index(int statusCode, Exception exception, bool isAjaxRequet)
        {
            if (!isAjaxRequet)
            {
                ErrorModel model = new ErrorModel {HttpStatusCode = statusCode, Exception = exception};

                Response.StatusCode = statusCode;

                return View(model);
            }
            else
            {
                var errorObjet = new {message = exception.Message};
                Response.StatusCode = 500;
                return Json(errorObjet, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
