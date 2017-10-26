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
            CreateMap<LoginUserAddModel, LoginUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserType, opt => opt.UseValue<string>("U"))
                .ForMember(dest => dest.LoginTime, opt => opt.UseValue<DateTime?>(null))
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Apps, opt => opt.MapFrom(src=> GetApps(src.AppIds)));
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
    }
}