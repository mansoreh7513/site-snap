﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.DataAccessLayer.Entites;

namespace Snapp.Site.ViewComponents.TransactInProcessComponent
{
    public class TransactInProcessComponent : ViewComponent
    {
        private readonly IAdmin _admin;
        private PersianCalendar pc = new PersianCalendar();

        public TransactInProcessComponent(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string strToday = pc.GetYear(DateTime.Now).ToString("0000") + "/" +
                pc.GetMonth(DateTime.Now).ToString("00") + "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");

            return await Task.FromResult((IViewComponentResult)View("TView", await _admin.FillTransactInProcess(strToday)));
        }
    }
}
