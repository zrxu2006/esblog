using AutoMapper;
using EsbLog.Domain.Platform;
using EsbLog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Web.Infrastructure
{
    public class EsbLogAutoMapperProfile:Profile
    {
        public EsbLogAutoMapperProfile()
        {
            

                //{
                //    HashSet<App> result = new HashSet<App>();
                //    if (!string.IsNullOrEmpty(src.AppIds))
                //    {
                //        var ids = src.AppIds.Split(',');
                       
                //        foreach (var id in ids)
                //        {
                //            int tempId;
                //            if (int.TryParse(id,out tempId)) continue;
                //            result.Add(new App
                //            {
                //                AppId = tempId
                //            });
                //        }

                //    }
                //    return result;
                //}));            
        }

        protected override void Configure()
        {
            CreateMap<LoginUserEditModel, LoginUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserType, opt => opt.UseValue<string>("U"))
                .ForMember(dest => dest.LoginTime, opt => opt.UseValue<DateTime?>(null))
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Apps, opt => opt.MapFrom(src => GetApps(src.AppIds)))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? 0));

            CreateMap<LoginUser, LoginUserEditModel>()
                .ForMember(dest => dest.AppIds, opt => opt.MapFrom(src=>GetAppIds(src.Apps)))
                .ForMember(dest => dest.AppList, opt => opt.Ignore());

            CreateMap<LoginUser, UserSessionModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsManager, opt => opt.MapFrom(src => src.UserType == "U"))
                .ForMember(dest => dest.UserApps, opt => opt.MapFrom(src => src.Apps));
        }

        private ICollection<App> GetApps(string concatIds)
        {
            HashSet<App> result = new HashSet<App>();
            if (!string.IsNullOrEmpty(concatIds))
            {
                var ids = concatIds.Split(',');

                foreach (var id in ids)
                {
                    int tempId;
                    if (!int.TryParse(id, out tempId)) continue;
                    result.Add(new App
                    {
                        AppId = tempId
                    });
                }

            }
            return result;
        }

        private string GetAppIds(IEnumerable<App> apps)
        {
            return string.Join(",",
                    apps.Select(a=> a.AppId.ToString()));
        }
    }
}