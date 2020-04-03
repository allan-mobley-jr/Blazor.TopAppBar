// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Mobsites.Blazor
{
    /// <summary>
    /// Blazor child component that acts as a container for action items.
    /// </summary>
    public partial class TopAppBarActions
    {
        /// <summary>
        /// Parent container.
        /// </summary>
        [CascadingParameter] internal TopAppBar Parent { get; set; }
    
        /// <summary>
        /// All html attributes outside of the class attribute go here. Use the Class attribute property to add css classes.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> ExtraAttributes { get; set; }

        /// <summary>
        /// The action items for the <see cref="TopAppBar">.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Css classes for affecting this component go here.
        /// </summary>
        [Parameter] public string Class { get; set; }

        /// <summary>
        /// Whether to show all actions on all device sizes. Default is to hide all but first on small devices.
        /// </summary>
        [Parameter] public bool ShowActionsAlways { get; set; }

        protected override void OnParametersSet()
        {
            if (Parent is null)
            {
                throw new ArgumentNullException(nameof(Parent), $"This component must have a parent of type {nameof(TopAppBar)}!");
            }

            Parent.ShowActionsAlways = ShowActionsAlways;
        }
    }
}