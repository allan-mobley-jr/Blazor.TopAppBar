// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Mobsites.Blazor
{
    /// <summary>
    /// Blazor child component that acts as a container for the application title and optional navigation button.
    /// </summary>
    public partial class TopAppBarNav
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
        /// The optional navigation button for the <see cref="TopAppBar">.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Css classes for affecting this component go here.
        /// </summary>
        [Parameter] public string Class { get; set; }

        /// <summary>
        /// Whether to scroll to top of page when navigation icon is clicked.
        /// </summary>
        [Parameter] public bool ScrollToTop { get; set; }

        /// <summary>
        /// A brand title to display.
        /// </summary>
        [Parameter] public string BrandTitle { get; set; }

        /// <summary>
        /// Whether to hide brand title on small devices.
        /// </summary>
        [Parameter] public bool HideBrandTitle { get; set; }

        /// <summary>
        /// Whether to hide brand image on small devices.
        /// </summary>
        [Parameter] public bool HideBrandImage { get; set; }

        /// <summary>
        /// Whether to show a brand image.
        /// </summary>
        [Parameter] public bool UseBrandImage { get; set; }

        private string imageSource = "_content/Mobsites.Blazor.TopAppBar/blazor.png";
        
        /// <summary>
        /// Image source override. Defaults to '_content/Mobsites.Blazor.TopAppBar/blazor.png'.
        /// </summary>
        [Parameter] public string BrandImageSource 
        { 
            get => imageSource; 
            set 
            { 
                if (!string.IsNullOrEmpty(value))
                {
                    imageSource = value;
                } 
            } 
        }

        private int imageWidth = 36;
        
        /// <summary>
        /// Image width (px) override. Defaults to 36px.
        /// </summary>
        [Parameter] public int BrandImageWidth 
        { 
            get => imageWidth; 
            set 
            { 
                if (value > 0)
                {
                    imageWidth = value;
                } 
            } 
        }

        private int imageHeight = 36;
        
        /// <summary>
        /// Image height (px) override. Defaults to 36px.
        /// </summary>
        [Parameter] public int BrandImageHeight 
        { 
            get => imageHeight; 
            set 
            { 
                if (value > 0)
                {
                    imageHeight = value;
                } 
            } 
        }

        protected override void OnParametersSet()
        {
            if (Parent is null)
            {
                throw new ArgumentNullException(nameof(Parent), $"This component must have a parent of type {nameof(TopAppBar)}!");
            }

            Parent.ScrollToTop = ScrollToTop;
        }
    }
}