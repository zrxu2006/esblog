using EsbLog.Domain.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Web.Models
{
    public class LogPagingRequestModel : PagingRequest
    {
        public string AppIds { get; set; }
        public string LogLevels { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public static class LogPagingRequestModelExtension
    {
        public static LogPagingRequestModel Copy(this LogPagingRequestModel model, long index)
        {
            return new LogPagingRequestModel
            {
                AppIds = model.AppIds,
                EndDate = model.EndDate,
                LogLevels = model.LogLevels,
                PageIndex = index,
                PageSize = model.PageSize,
                StartDate = model.StartDate
            };
        }
    }

    public class LogPagingPartialViewModel
    {
        public LogPagingPartialViewModel(LogPagingRequestModel request)
        {
            Request = request;
            Result = new LogPagingResultModel();
        }
        public LogPagingRequestModel Request { get; private set; }
        public LogPagingResultModel Result { get; private set; }
        public string UpdateTargetId { get; set; }
    }
}