// <copyright file="EditorServiceViaWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.WpfApplication.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KutyaVerseny.WpfApplication.Data;
    using KutyaVerseny.WpfApplication.Logic;

    /// <summary>
    /// editorvidow.
    /// </summary>
    internal class EditorServiceViaWindow : IEditorService
    {
        /// <inheritdoc/>
        public bool EditPlayer(DogWpf d)
        {
            EditorWindow win = new EditorWindow(d);
            return win.ShowDialog() ?? false;
        }
    }
}
