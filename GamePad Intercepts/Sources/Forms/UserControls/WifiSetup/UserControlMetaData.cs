﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePad_Intercepts.Forms.UserControls.WifiSetup
{
    class UserControlMetaData
    {
        public String breadcrumb;
        public UserControl backUserControl;

        public UserControlMetaData(String breadcrumb, UserControl backUserControl)
        {
            this.breadcrumb = breadcrumb;
            this.backUserControl = backUserControl;
        }
    }
}
