// <copyright file="ApiResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using KutyaVerseny.Logic;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// apiresutl.
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether result.
        /// </summary>
        public bool OpertaionResult { get; set; }
    }
}
