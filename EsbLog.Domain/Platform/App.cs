﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Domain.Platform
{
    public class App
    {
        [Display(Name="应用名称")]
        public string Name { get; set; }
        public int AppId { get; set; }
        [Display(Name="应用编号")]
        public string Code { get; set; }
        [Display(Name="描述")]
        public string Description { get; set; }

        public string PublicKey { get; set; }

    }
}