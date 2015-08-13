
using System;
using System.Web.Http;
using Tavisca.PaymentStatusService.ResourceLayer;
using Tavisca.Singularity;
using PaymentStatus = Tavisca.PaymentStatusService.Models.PaymentStatus;

namespace Tavisca.PaymentStatusService.Controllers
{
    public class PaymentstatusController : ApiController
    {
        private IPaymentStatusRepository _paymentStatusRepository;

        public PaymentstatusController()
        {
             _paymentStatusRepository = RuntimeContext.Resolver.Resolve<IPaymentStatusRepository>("PaymentStatusRepository");
        }
       
        public PaymentStatus SavePaymentStatus([FromBody]PaymentStatus response)
        {
            //TODO:store data in table
            var a = new PaymentStatus();
            return a;
        }
    }
}
