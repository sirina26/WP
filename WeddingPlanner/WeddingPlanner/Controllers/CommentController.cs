using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using WeddingPlanner.DAL;
using WeddingPlanner.WebApp.Authentication;
using WeddingPlanner.WebApp.Models.CommentViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace WeddingPlanner.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]

    public class CommentController: Controller
    {
        readonly CommentGateway _commentGateway;

        public CommentController( CommentGateway commentGateway )
        {
            _commentGateway = commentGateway;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentList()
        {
            IEnumerable<CommentData> result = await _commentGateway.GetAll();
            return Ok( result );
        }

        [HttpGet( "{id}", Name = "GetComment")]
        public async Task<IActionResult> GetCommentById( int id )
        {
            Result<CommentData> result = await _commentGateway.FindById( id );
            return this.CreateResult( result );
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentViewModels model )
        {
            int userId = int.Parse( User.Claims.ElementAt<Claim>( 0 ).Value );
            Result<int> result = await _commentGateway.Create( model.EventId,
                userId, model.Proposition, DateTime.Now );
            return this.CreateResult( result, o =>
            {
                o.RouteName = "GetComment";
                o.RouteValues = id => new { id };
            } );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateComment( int id, [FromBody] CommentViewModels model )
        {
            Result result = await _commentGateway.Update( model.PropositionId,
                model.EventId, model.OrganizerId, model.Proposition,
           model.PropositionDate );
            return this.CreateResult( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteComment( int id )
        {
            Result result = await _commentGateway.Delete( id );
            return this.CreateResult( result );
        }

    }
}
