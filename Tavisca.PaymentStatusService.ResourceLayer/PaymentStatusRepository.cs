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
                PaymentStatusDBContext.UsingPaymentStatusDbRead(
                    db => db.spInsertTripFolderDetails_dboPaymentStatus(paymentStatus.TripFolderId,
                                                                        paymentStatus.TripProductId,
                                                                        paymentStatus.RequestType,
                                                                        paymentStatus.TimeTaken,
                                                                        paymentStatus.Status,
                                                                        CheckDate(paymentStatus.SupplierRequestTime)?paymentStatus.SupplierRequestTime:(DateTime?) null,
                                                                        CheckDate(paymentStatus.SupplierResponseTime)?paymentStatus.SupplierResponseTime:(DateTime?) null,
                                                                        paymentStatus.PerProductAmount,
                                                                        paymentStatus.SupplierResponse,
                                                                        paymentStatus.ApiSessionId));
                return true;
            }
            catch (Exception exception)
            {
                LogUtility.GetLogger().WriteAsync(exception.ToContextualEntry(), "Log Only Policy");
                throw;
            }           
        }

        private bool CheckDate(DateTime date)
        {
            if(date>=new DateTime(1753,1,1) && date<=new DateTime(9999,12,31))
            {
                return true;
            }
            return false;
        }
    }
}
