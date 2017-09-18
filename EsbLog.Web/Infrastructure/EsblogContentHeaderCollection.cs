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
    }

    public class EsblogConfig
    {
        private static EsblogContentHeaderCollection _contentHeaders;
        
        private static EsblogConfig()
        {
            _contentHeaders = new EsblogContentHeaderCollection();

        }
        public static EsblogContentHeaderCollection ContentHeaders
        {
            get { return _contentHeaders; }
        }

        public static void RegisterContentHeaders(Func<IEnumerable<ContentHeaderViewModel>> provider)
        {
            foreach (var h in provider())
            {
                _contentHeaders.Add(h);
            }
        }
    }
}