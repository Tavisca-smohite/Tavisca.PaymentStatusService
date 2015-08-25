using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tavisca.Singularity;
using Tavisca.TravelNxt.Shared.Entities.Infrastructure;
using DTO=Tavisca.PaymentStatusService.ResourceLayer;

namespace Tavisca.PaymentStatusService
{
    public class PaymentStatusHelper
    {
        private DTO.IPaymentStatusRepository _paymentStatusRepository; 

        public  PaymentStatusHelper()
        {          
             _paymentStatusRepository = RuntimeContext.Resolver.Resolve<DTO.IPaymentStatusRepository>("PaymentStatusRepository");
        }

        /// <summary>
        /// paymentStatusObject has tripfolder details which can have multiple tripproducts
        /// resourcelayer contains separate payment status object which takes one tripproduct id and corresponding amount for supplied tripfolder id
        /// thus paymentStatusObject is converted to list of respource layer payment status objects which are further saved in PaymnentStatus Table
        /// </summary>
        /// <param name="paymentStatusObject"></param>
        /// <returns></returns>
        public bool SavePaymentStatusObjectsPerProduct(Models.PaymentStatus paymentStatusObject)
        {
            bool status = false;
            var paymentStatusObjectsList = TranslateToDTOPaymentStatusObject(paymentStatusObject);
            foreach (var paymentStatusObj in paymentStatusObjectsList)
            {
                try
                {
                    status = _paymentStatusRepository.InsertIntoPaymnetStatus(paymentStatusObj);
                }
                catch (Exception exception)
                {
                    LogUtility.GetLogger().WriteAsync(exception.ToContextualEntry(), "Log Only Policy");
                    status = false;
                }
            }
            return status;
        }

       private static List<DTO.PaymentStatus> TranslateToDTOPaymentStatusObject(Models.PaymentStatus paymentStatusObject)
       {
           var paymentStatusObjectsList = new List<DTO.PaymentStatus>();
           int i = 0;
           foreach (var tripProductId in paymentStatusObject.TripProductIds)
           {
               var paymentStatusObjectInResourceLayer = new DTO.PaymentStatus();
               paymentStatusObjectInResourceLayer.TripFolderId = paymentStatusObject.TripFolderId;
               paymentStatusObjectInResourceLayer.TripProductId = tripProductId;
               paymentStatusObjectInResourceLayer.ApiSessionId = paymentStatusObject.ApiSessionId;
               paymentStatusObjectInResourceLayer.TimeTaken = paymentStatusObject.TimeTaken;
               paymentStatusObjectInResourceLayer.RequestType = paymentStatusObject.RequestType;
               paymentStatusObjectInResourceLayer.SupplierResponse = paymentStatusObject.SupplierResponse;
               paymentStatusObjectInResourceLayer.SupplierRequestTime = paymentStatusObject.SupplierRequestTime;
               paymentStatusObjectInResourceLayer.SupplierResponseTime = paymentStatusObject.SupplierResponseTime;
               paymentStatusObjectInResourceLayer.Status = paymentStatusObject.Status;
               paymentStatusObjectInResourceLayer.PerProductAmount = (paymentStatusObject.PerProductAmount!=null &&
                                                                       paymentStatusObject.PerProductAmount.Count>0)?
                                                                       paymentStatusObject.PerProductAmount[i++]
                                                                         : 0;     
               paymentStatusObjectsList.Add(paymentStatusObjectInResourceLayer);                                                             
           }
           return paymentStatusObjectsList;
       }
       
    }
}