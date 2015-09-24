
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Tavisca.PaymentStatusService.Models;
using Tavisca.TravelNxt.Shared.Entities.Infrastructure;

namespace Tavisca.PaymentStatusService.Controllers
{
    public class PaymentstatusController : ApiController
    {
        // ....api/paymentstatus/SavePaymentStatus   
        public PaymentStatus SavePaymentStatus([FromBody]Models.PaymentStatus response)
        {
            try
            {
                var status =  new PaymentStatusHelper().SavePaymentStatusObjectsPerProduct(response);
                return MapStatus(status);
            }
            catch (Exception exception)
            {
                LogUtility.GetLogger().WriteAsync(exception.ToContextualEntry(), "Log Only Policy");
                return  MapStatus(false);
            }         
        }

        private Models.PaymentStatus MapStatus(bool status)
        {
            if(status==true)
            {
                return new PaymentStatus{Status = Status.Success.ToString()};
            }         
                return new PaymentStatus{Status = Status.Failure.ToString()};
            
        }
 
    }

}
