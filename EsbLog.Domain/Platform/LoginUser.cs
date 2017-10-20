using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Domain.Platform
{
    public class LoginUser
    {
        public LoginUser()
        {
            Apps = new HashSet<App>();
        }
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public DateTime? LoginTime { get; set; }
        public virtual ICollection<App> Apps { get; set; }
    }
}
