using System.Security.Claims;
using System.Threading.Tasks;
using WeddingPlanner.DAL;
using WeddingPlanner.WebApp.Authentication;
using WeddingPlanner.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace WeddingPlanner.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class UserController: Controller
    {
        readonly UserGateway _userGateway;
        readonly UserService _userService;


        
        public UserController( UserGateway userGateway, UserService userService )
        {
            _userGateway = userGateway;
            _userService = userService;
        }

        [HttpGet("GetUserId")]
        public async Task<int> UserId()
        {
            int userId = int.Parse( User.Claims.ElementAt<Claim>( 0 ).Value );
            return userId;
        }


        [HttpGet( "GetUserType" )]    
        public async Task<bool> IsOrganizer()
        {
            int userId = int.Parse( User.Claims.ElementAt<Claim>( 0 ).Value );
            bool isOrganizer = await _userGateway.IsOrganizer( userId );
            return isOrganizer;
        }
    }
}
