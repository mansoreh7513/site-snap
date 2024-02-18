using System;
using System.Collections.Generic;
using System.Text;

namespace Snapp.Core.ViewModels
{
    public class DashboardViewModel
    {
        public int Status { get; set; }

        public Guid? TransactId { get; set; }

        public Guid? DriverId { get; set; }

        public Guid? UserId { get; set; }

        public string DriverName { get; set; }

        public string CarCode { get; set; }

        public string CarName { get; set; }

        public string CarColor { get; set; }

        public string StartLat { get; set; }

        public string StartLng { get; set; }

        public string EndLat { get; set; }

        public string EndLng { get; set; }

        public string Avatar { get; set; }

        public long Price { get; set; }

        public long Wallet { get; set; }        
    }
}
