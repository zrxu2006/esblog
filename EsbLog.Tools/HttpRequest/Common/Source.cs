﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EsbLog.Tools.HttpRequest.Common
{
    /// <summary>
    /// Represents the source that a status is from.
    /// </summary>
    [Serializable]
    [XmlRoot("source")]
    public class Source
    {
        /// <summary>
        /// Gets or sets the content of the source object.
        /// </summary>
        [XmlElement("a")]
        public Hyperlink Content { get; set; }
    }
}
