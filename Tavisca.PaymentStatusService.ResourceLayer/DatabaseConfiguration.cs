using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.PaymentStatusService.ResourceLayer
{
    public class DatabaseConfiguration
    {
        public static string ReadFraudDatabaseConnection
        {
            get { return GetFraudDbConnectionString() ?? "TripDataWareHouse"; }
        }

        public static string WriteFraudDatabaseConnection
        {
            get { return GetFraudDbConnectionString() ?? "TripDataWareHouse"; }
        }

        private static string GetFraudDbConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["TripDataWareHouse"].ConnectionString;
        }
    }
}
