﻿using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Settings
{
    public class SettingsKeyValueViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public TypeCode Type { get; set; }
    }
}
