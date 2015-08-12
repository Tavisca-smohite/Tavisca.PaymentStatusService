
using System;
using System.Web.Http;
using Tavisca.PaymentStatusService.Models;

namespace Tavisca.PaymentStatusService.Controllers
{
    public class PaymentstatusController : ApiController
    {
       
        public PaymentStatus SavePaymentStatus([FromBody]PaymentStatus response)
        {
            //TODO:store data in table
        }
    }
}
