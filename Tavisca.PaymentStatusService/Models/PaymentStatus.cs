﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tavisca.PaymentStatusService.Models
{
    public class PaymentStatus
    {
        public string TripFolderId { get; set; }
        public List<string> TripProductId { get; set; }
        public string RequestType { get; set; }
        public string SupplierResponse { get; set; }
        public string Status { get; set; }
        public string SupplierRequestTime { get; set; }
        public string SupplierResponseTime { get; set; }
        public string ResponseTime {get; set; }
        public string Amount { get; set; }

    }
}