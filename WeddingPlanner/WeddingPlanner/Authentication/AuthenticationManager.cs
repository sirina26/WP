using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth;
using WeddingPlanner.DAL;

namespace WeddingPlanner.WebApp.Authentication
{
    public abstract class AuthenticationManager<TUserInfo>
    {
        public async Task OnCreatingTicket( OAuthCreatingTicketContext ctx )
        {
            TUserInfo userInfo = await GetUserInfoFromContext( ctx );
            await CreateOrUpdateUser( userInfo );
            UserData user = await FindUser( userInfo );
            ctx.Principal = CreatePrincipal( user );
        }

        protected abstract Task<TUserInfo> GetUserInfoFromContext( OAuthCreatingTicketContext ctx );

        protected abstract Task CreateOrUpdateUser( TUserInfo userInfo );

        protected abstract Task<UserData> FindUser( TUserInfo userInfo );

        ClaimsPrincipal CreatePrincipal( UserData user )
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim( ClaimTypes.NameIdentifier, user.UserId.ToString(), ClaimValueTypes.String ),
                new Claim( ClaimTypes.Email, user.Email )
            };
            ClaimsPrincipal principal = new ClaimsPrincipal( new ClaimsIdentity( claims, CookieAuthentication.AuthenticationType, ClaimTypes.Email, string.Empty ) );
            return principal;
        }
    }
}
