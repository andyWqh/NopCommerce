﻿using Nop.Core.Configuration;

namespace Nop.Core.Domain
{
    public class StoreInformationSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether store is closed
        /// </summary>
        public bool StoreClosed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether administrators can visit a closed store
        /// </summary>
        public bool StoreClosedAllowForAdmins { get; set; }

        /// <summary>
        /// Gets or sets a default store theme for desktops
        /// </summary>
        public string DefaultStoreThemeForDesktops { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to select a theme
        /// </summary>
        public bool AllowCustomerToSelectTheme { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether mobile devices supported
        /// </summary>
        public bool MobileDevicesSupported { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether responsive design supported (a graphical theme should also support it)
        /// </summary>
        public bool ResponsiveDesignSupported { get; set; }

        /// <summary>
        /// Gets or sets a default store theme used by mobile devices (if enabled)
        /// </summary>
        public string DefaultStoreThemeForMobileDevices { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether all requests will be handled as mobile devices (used for testing)
        /// </summary>
        public bool EmulateMobileDevice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether mini profiler should be displayed in public store (used for debugging)
        /// </summary>
        public bool DisplayMiniProfilerInPublicStore { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we should display warnings about the new EU cookie law
        /// </summary>
        public bool DisplayEuCookieLawWarning { get; set; }

        /// <summary>
        /// Gets or sets a value of Facebook page URL of the site
        /// </summary>
        public string FacebookLink { get; set; }

        /// <summary>
        /// Gets or sets a value of Twitter page URL of the site
        /// </summary>
        public string TwitterLink { get; set; }

        /// <summary>
        /// Gets or sets a value of YouTube channel URL of the site
        /// </summary>
        public string YoutubeLink { get; set; }

        /// <summary>
        /// Gets or sets a value of Google+ page URL of the site
        /// </summary>
        public string GooglePlusLink { get; set; }
    }
}
