using MediatR;

namespace EShopperAPI.Application.Features.Commands.AppUser.GoogleLoginUser
{
    public class GoogleLoginUserCommandRequest : IRequest<GoogleLoginUserCommandResponse>
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string id { get; set; }
        public string idToken { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public string photoUrl { get; set; }
        public string provider { get; set; }
    }
}
