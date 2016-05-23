using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EsbLog.Tools.HttpRequest.Common
{
    /// <summary>
    /// Represents a geo.
    /// </summary>
    [Serializable]
    [XmlRoot(Namespace = "http://www.georss.org/georss")]
    public class Geo
    {
        /// <summary>
        /// Gets or sets the geo point.
        /// </summary>
        [XmlElement("point")]
        public GeoPoint Point { get; set; }
    }
}
