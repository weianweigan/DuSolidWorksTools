//------------------------------------------------------------------------------
// <copyright file="SolidWorksToolBox.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace DuSolidWorksTools.ToolBox
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("1aac7b9c-5f43-4afd-ad6c-4530a79171cd")]
    public class SolidWorksToolBox : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolidWorksToolBox"/> class.
        /// </summary>
        public SolidWorksToolBox() : base(null)
        {
            this.Caption = "SolidWorksToolBox";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new SolidWorksToolBoxControl();
        }
    }
}
