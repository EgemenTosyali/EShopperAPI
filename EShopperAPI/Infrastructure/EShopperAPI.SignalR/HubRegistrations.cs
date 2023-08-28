using EShopperAPI.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;

namespace EShopperAPI.SignalR
{
    public static class HubRegistrations
    {
        public static void MapHubs(this WebApplication webApplication)
        {
            webApplication.MapHub<ProductsHub>("/hubs/products_hub");
        }
    }
}
