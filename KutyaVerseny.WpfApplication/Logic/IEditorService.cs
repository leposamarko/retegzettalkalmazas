// <copyright file="IEditorService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.WpfApplication.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KutyaVerseny.WpfApplication.Data;

    /// <summary>
    /// editorservice.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// edit player bool.
        /// </summary>
        /// <param name="d">dog name.</param>
        /// <returns>is editabel.</returns>
        bool EditPlayer(DogWpf d);
    }
}
