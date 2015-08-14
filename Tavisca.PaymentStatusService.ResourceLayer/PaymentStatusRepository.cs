using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.Shared.Entities.Infrastructure;

namespace Tavisca.PaymentStatusService.ResourceLayer
{
    public class PaymentStatusRepository : IPaymentStatusRepository
    {
        
        public bool InsertIntoPaymnetStatus(PaymentStatus paymentStatus)
        {
          
            try
            {
                PaymentStatusDBContext.UsingPaymentStatusDbRead(db => db.spInsertTripFolderDetails_dboPaymentStatus(paymentStatus.TripFolderId,
                                                                                                                    paymentStatus.TripProductId,
                                                                                                                    paymentStatus.RequestType, paymentStatus.TimeTaken,
                                                                                                                    paymentStatus.Status,
                                                                                                                    paymentStatus.SupplierRequestTime,
                                                                                                                    paymentStatus.SupplierResponseTime,
                                                                                                                    paymentStatus.PerProductAmount,
                                                                                                                    paymentStatus.SupplierResponse));
                return true;
            }
            catch (Exception exception)
            {
                LogUtility.GetLogger().WriteAsync(exception.ToContextualEntry(), "Log Only Policy");
                throw;
            }           
        }
    }
}
