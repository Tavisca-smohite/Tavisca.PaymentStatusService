using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tavisca.PaymentStatusService.Models
{
    public class PaymentStatus
    {
        public Guid TripFolderId { get; set; }
        public List<Guid> TripProductIds { get; set; }
        public string RequestType { get; set; }
        public string SupplierResponse { get; set; }
        public string Status { get; set; }
        public DateTime SupplierRequestTime { get; set; }
        public DateTime SupplierResponseTime { get; set; }
        public double TimeTaken { get; set; }
        public List<decimal> PerProductAmount { get; set; }

    }
}