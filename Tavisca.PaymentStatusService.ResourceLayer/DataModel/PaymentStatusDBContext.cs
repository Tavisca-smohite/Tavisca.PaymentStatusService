using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.PaymentStatusService.ResourceLayer.DataModel;

namespace Tavisca.PaymentStatusService.ResourceLayer
{
    public class PaymentStatusDBContext : IDisposable
    {
        public static void UsingPaymentStatusDbRead(Action<PaymentStatusDataContext> action)
        {
            using (var context = new PaymentStatusDBContext())
            {
                action(context.Read);
            }
        }

        public static void UsingPaymentStatusDbWrite(Action<PaymentStatusDataContext> action)
        {
            using (var context = new PaymentStatusDBContext())
            {
                action(context.Write);
            }
        }

        public PaymentStatusDBContext()
        {
            if (_stack == null)
            {
                _stack = new Stack<PaymentStatusDBContext>();
                this.Depth = 1;
                this.Read = new PaymentStatusDataContext(DatabaseConfiguration.ReadFraudDatabaseConnection);
                this.Write = new PaymentStatusDataContext(DatabaseConfiguration.WriteFraudDatabaseConnection);
            }
            else
            {
                var parent = _stack.Peek();
                this.Depth = parent.Depth + 1;
                this.Read = parent.Read;
                this.Write = parent.Write;
            }
            _stack.Push(this);
        }

        public int Depth { get; private set; }

        public bool IsRoot
        {
            get { return this.Depth == 1; }
        }

        [ThreadStatic]
        private static Stack<PaymentStatusDBContext> _stack;
        public PaymentStatusDataContext Read { get; private set; }
        public PaymentStatusDataContext Write { get; private set; }

        public void Dispose()
        {
            var context = _stack.Pop();
            if (context.IsRoot == true)
            {
                context.Read.Dispose();
                context.Write.Dispose();
                _stack = null;
            }
        }
        
    }
}
