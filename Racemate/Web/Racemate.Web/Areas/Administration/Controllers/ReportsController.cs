﻿namespace Racemate.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Racemate.Data;
    using Racemate.Web.Areas.Administration.Controllers.Common;

    public class ReportsController : AdminBaseController
    {
        public ReportsController(IRacemateData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}