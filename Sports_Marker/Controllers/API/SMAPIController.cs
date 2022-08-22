using Microsoft.AspNetCore.Mvc;
using Sports_Marker.Business.Services;
using Sports_Marker.Web.Models;
using Sports_Marker.Web.Models.Dtos;

namespace Sports_Marker.Web.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class SMAPIController : Controller
    {
        private readonly ISMService _sMService;

        public SMAPIController(ISMService sMService)
        {
            _sMService = sMService;
        }

        [Route("setgoals")]
        [HttpPost]
        public void AddGoal([FromQuery] Guid id)
        {
            _sMService.AddGoals(id);
        }




        [Route("setfouls")]
        [HttpPost]

        public void AddFoul([FromQuery] Guid id)
        {
            
            
            _sMService.AddFouls(id); 
        }


        [Route("getPartialFouls")]
        public IActionResult GetPartialFouls(int fouls, bool trackEntity)
        {

            var _fouls = _sMService.GetFouls(fouls, true);
            var viewModel = new PartialFoulsViewModel(_fouls);

            return PartialView("Partials/FoulPartial");

        }


        [Route("getPartialGoals")]

        public IActionResult GetPartialGoals(int goals, bool trackEntity)
        {

            var _goals = _sMService.GetGoals(goals, true);
            var viewModel = new PartialFoulsViewModel(_goals);

            return PartialView("Partials/GoalPartial");

        }
    }
}
