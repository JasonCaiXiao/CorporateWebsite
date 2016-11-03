using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorporateWebsite.Domain;
using CorporateWebsite.Domain.IRepositories;

namespace CorporateWebsite.Controllers
{
    /// <summary>
    /// 参考类，不具有实际意义
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           return View();
        }
    }
}