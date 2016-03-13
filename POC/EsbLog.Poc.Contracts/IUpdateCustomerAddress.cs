using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Poc.Contract
{
    public interface IUpdateCustomerAddress
    {
        Guid CommandId { get; }
        DateTime Timestamp { get; }
        string CustomerId { get; }
        string HouseNumber { get; }
        string Street { get; }
        string City { get; }
        string State { get; }
        string PostalCode { get; }
    }
}
