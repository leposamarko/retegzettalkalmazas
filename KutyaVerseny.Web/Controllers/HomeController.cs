// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using KutyaVerseny.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// homecontroller.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// index.
        /// </summary>
        /// <returns>view.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// privacy.
        /// </summary>
        /// <returns>view.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// error.
        /// </summary>
        /// <returns>view.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
