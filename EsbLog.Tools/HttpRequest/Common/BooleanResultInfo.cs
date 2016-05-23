using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EsbLog.Tools.HttpRequest.Common
{
    /// <summary>
    /// Represents a boolean result.
    /// </summary>
    [Serializable]
    public class BooleanResultInfo
    {
        /// <remarks/>
        [XmlText]
        public virtual bool Value { get; set; }
    }

    /// <summary>
    /// Represents a friendship existence result.
    /// </summary>
    [Serializable]
    [XmlRoot("friends")]
    public class ExistsFriendshipResultInfo : BooleanResultInfo
    {

    }
}
