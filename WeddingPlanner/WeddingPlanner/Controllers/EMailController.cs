using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingPlanner.DAL;
using WeddingPlanner.WebApp.Authentication;
using WeddingPlanner.WebApp.Models.EMailViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.WebApp.Controllers;

namespace WeddingPlanner.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class EMailController : Controller
    {

        readonly EMailGateway _eMailGateway;

        public EMailController( EMailGateway eMailGateway )
        {
            _eMailGateway = eMailGateway;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent( [FromBody] EMailViewModels model )
        {
            Result<int> result = await _eMailGateway.Mail
                ( model.object_mail, model.mail, model.mailadress );
            return this.CreateResult( result, o =>
            {
                o.RouteName = "GetEMail";
                o.RouteValues = id => new { id };
            } );
        }

    }
}
