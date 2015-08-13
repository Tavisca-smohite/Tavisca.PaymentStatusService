using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.PaymentStatusService.Controllers;
using Tavisca.PaymentStatusService.Models;

namespace Tavisca.PaymentStatusService.Tests.Controllers
{
    [TestClass]
    public class PaymentStatusControllerTest
    {
        private PaymentstatusController _paymentstatusController = null;
        [TestInitialize]
        public void Initialize()
        {
            _paymentstatusController = new PaymentstatusController();
        }

        [TestMethod]
        public void SavePaymentStatus_Successful_ValidResponse()
        {
            var response = _paymentstatusController.SavePaymentStatus(new PaymentStatus());
            Assert.IsNotNull(response);
        }
    }
}
