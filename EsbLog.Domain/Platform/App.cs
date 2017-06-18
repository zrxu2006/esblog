using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Domain.Platform
{
    public class App
    {
        public string Name { get; set; }
        public int AppId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public Guid PublicKey { get; set; }

    }
}
