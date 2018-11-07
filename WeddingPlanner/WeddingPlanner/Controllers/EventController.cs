using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingPlanner.DAL;
using WeddingPlanner.WebApp.Authentication;
using WeddingPlanner.WebApp.Models.EventViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class EventController : Controller
    {
        readonly EventGateway _eventGateway;

        public EventController( EventGateway eventGateway )
        {
            _eventGateway = eventGateway;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventList()
        {
            IEnumerable<EventData> result = await _eventGateway.GetAll();
            return Ok( result );
        }

        [HttpGet( "{id}", Name = "GetEvent" )]
        public async Task<IActionResult> GetEventById( int id )
        {
            Result<EventData> result = await _eventGateway.FindById( id );
            return this.CreateResult( result );
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent( [FromBody] EventViewModel model )
        {
            Result<int> result = await _eventGateway.Create( model.FirstName, model.LastName, model.BirthDate, model.GitHubLogin );
            return this.CreateResult( result, o =>
            {
                o.RouteName = "GetEvent";
                o.RouteValues = id => new { id };
            } );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateEvent( int id, [FromBody] EventViewModel model )
        {
            Result result = await _eventGateway.Update( id, model.FirstName, model.LastName, model.BirthDate, model.GitHubLogin );
            return this.CreateResult( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteEvent( int id )
        {
            Result result = await _eventGateway.Delete( id );
            return this.CreateResult( result );
        }
    }
}
