﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Abstractions.Services.Authentication
{
    public interface IExternalAuthentication
    {
        Task GoogleLoginAsync();
    }
}
