//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WeddingPlanner.DAL;
//using WeddingPlanner.WebApp.Models.DemoViewModels;
//using Microsoft.AspNetCore.Mvc;

//namespace WeddingPlanner.WebApp.Controllers
//{
//    [Route( "[controller]" )]
//    public class DemoController : Controller
//    {
//        readonly ClassGateway _classGateway;

//        public DemoController( ClassGateway classGateway )
//        {
//            _classGateway = classGateway;
//        }

//        [HttpGet( "List" )]
//        public async Task<IActionResult> List()
//        {
//            var classes = await _classGateway.GetAll();

//            var models = classes.Select( x => new DemoClassViewModel
//            {
//                ClassId = x.ClassId,
//                Level = x.Level,
//                Name = x.Name
//            } );

//            return View( models );
//        }

//        [HttpGet( "Edit/{classId?}" )]
//        public async Task<IActionResult> Edit( int? classId )
//        {
//            if( classId.HasValue )
//            {
//                var result = await _classGateway.FindById( classId.Value );

//                if( result.HasError )
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    var existing = result.Content;

//                    var model = new DemoClassViewModel
//                    {
//                        ClassId = existing.ClassId,
//                        Level = existing.Level,
//                        Name = existing.Name
//                    };

//                    return View( model );
//                }
//            }
//            else
//            {
//                return View( new DemoClassViewModel() );
//            }
//        }

//        [HttpPost( "Edit/{classId?}" )]
//        public async Task<IActionResult> Edit( int? classId, DemoClassViewModel model )
//        {
//            if( ModelState.IsValid )
//            {
//                if( classId.HasValue )
//                {
//                    await _classGateway.Update( classId.Value, model.Name, model.Level );
//                }
//                else
//                {
//                    await _classGateway.Create( model.Name, model.Level );
//                }

//                return RedirectToAction( nameof( List ) );
//            }
//            else
//            {
//                ModelState.AddModelError( string.Empty, "Message d'erreur" );
//                return View( model );
//            }
//        }

//        [HttpGet( "Delete/{classId}" )]
//        public async Task<IActionResult> Delete( int classId )
//        {
//            var result = await _classGateway.Delete( classId );
//            return RedirectToAction( nameof( List ) );
//        }
//    }
//}
