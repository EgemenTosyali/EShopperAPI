﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Queries.ProductImageFile.GetProductImageFile
{
    public class GetProductImageFileQueryRequest : IRequest<List<GetProductImageFileQueryResponse>>
    {
        public string Id { get; set; }
    }
}
