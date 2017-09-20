using EsbLog.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace EsbLog.Web.Infrastructure
{
    public class EsblogContentHeaderCollection : Collection<ContentHeaderViewModel>
    {
        public EsblogContentHeaderCollection()
        {
            
        }

        public void Register(Func<IEnumerable<ContentHeaderViewModel>> provider)
        {
            foreach (var h in provider())
            {
                Add(h);
            }
        }
    }

    public class EsblogConfig
    {
        private static EsblogContentHeaderCollection _contentHeaders;
        
        static EsblogConfig()
        {
            _contentHeaders = new EsblogContentHeaderCollection();

        }
        public static EsblogContentHeaderCollection ContentHeaders
        {
            get { return _contentHeaders; }
        }

    }
}