using EsbLog.Poc.Contract;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Poc.Consumers
{
    public class UpdateCustomerConsumer
        :IConsumer<IUpdateCustomerAddress>
    {
        public async Task Consume(ConsumeContext<IUpdateCustomerAddress> context)
        {
            await Console.Out.WriteLineAsync("asdfasdf");  

            // update the customer address
        }
    }
}
