using EShopperAPI.Application.Abstractions.Hubs;
using EShopperAPI.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.SignalR.HubServices
{
    public class ProductsHubService : IProductHubService
    {
        readonly IHubContext<ProductsHub> _hubContext;

        public ProductsHubService(IHubContext<ProductsHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task ProductAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.ProductAddedMessage, message);
        }
    }
}
