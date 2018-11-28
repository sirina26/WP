using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingPlanner.DAL;
using WeddingPlanner.WebApp.Authentication;
using WeddingPlanner.WebApp.Models.EMailViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.WebApp.Controllers;
using WeddingPlanner.WebApp.Services;

namespace WeddingPlanner.WebApp.Controllers
{
    [Route( "/api/mailing" )]
    public class EMailController : Controller
    {
        readonly EMailService _emailService = new EMailService();

        [HttpPost]
        public async Task CreateMail( [FromBody] EMailViewModels model )
        {
            await _emailService.Mail( model.MailAdress, model.ObjectMail, model.Mail );
        }

    }
}
