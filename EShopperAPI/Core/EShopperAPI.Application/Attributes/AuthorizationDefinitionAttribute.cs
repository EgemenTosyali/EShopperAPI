﻿using EShopperAPI.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Attributes
{
    public class AuthorizationDefinitionAttribute : Attribute
    {
        public string Menu {  get; set; }
        public string Definition { get; set; }
        public ActionType ActionType { get; set; }
    }
}
