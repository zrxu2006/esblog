using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Tools.HttpRequest.Common
{
    /// <summary>
    /// Represents the event args of ResponseError event.
    /// </summary>
    [Serializable]
    public class ResponseErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the contextual data of a HTTP response error.
        /// </summary>
        public ResponseErrorData ErrorData { get; private set; }

        /// <summary>
        /// Gets or sets a boolean value indicating whether the exception is handled.
        /// </summary>
        public bool IsHandled { get; set; }
    }
}
