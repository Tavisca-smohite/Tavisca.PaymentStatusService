using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.PaymentStatusService.ResourceLayer
{
    
    public class PaymentStatus 
    {
        public Guid TripFolderId { get; set; }
        public Guid TripProductId { get; set; }
        public string RequestType { get; set; }
        public string SupplierResponse { get; set; }
        public string Status { get; set; }
        public DateTime SupplierRequestTime { get; set; }
        public DateTime SupplierResponseTime { get; set; }
        public double TimeTaken { get; set; }
        public decimal PerProductAmount { get; set; }
        public Guid ApiSessionId { get; set; }
    }
}
