using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingPlanner.DAL;
using WeddingPlanner.WebApp.Authentication;
using WeddingPlanner.WebApp.Models.WishListeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeddingPlanner.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class WishListeController : Controller
    {
        readonly WishListeGateway _wishListeGateway;

        public WishListeController(WishListeGateway wishListeGateway)
        {
            _wishListeGateway = wishListeGateway;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskList()
        {
            IEnumerable<WishListeData> result = await _wishListeGateway.GetAll();
            return Ok( result );
        }

        [HttpGet( "{id}", Name = "GetTask" )]
        public async Task<IActionResult> GetTaskById( int id )
        {
            Result<WishListeData> result = await _wishListeGateway.FindById( id );
            return this.CreateResult( result );
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask( [FromBody] WishListeViewModel model )
        {
            Result<int> result = await _wishListeGateway.Create( model.Task,
                model.CustomerId, model.StateTask );
            return this.CreateResult( result, o =>
            {
                o.RouteName = "GetTask";
                o.RouteValues = id => new { id };
            } );
          
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateTask( int id, [FromBody] WishListeViewModel model )
        {
            Result result = await _wishListeGateway.Update( id, model.Task,
                model.CustomerId, model.StateTask );
            return this.CreateResult( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteTask( int id )
        {
            Result result = await _wishListeGateway.Delete( id );
            return this.CreateResult( result );
        }

    }
}
