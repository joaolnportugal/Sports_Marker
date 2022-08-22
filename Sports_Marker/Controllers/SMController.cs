using Microsoft.AspNetCore.Mvc;
using Sports_Marker.Business.Services;
using Sports_Marker.Data.Models;
using Sports_Marker.Data.Models.Shared;
using Sports_Marker.Web.Models;

namespace Sports_Marker.Web.Controllers
{
    public class SMController : Controller
    {
        private ISMService _sMService;

        public SMController(ISMService sMService)
        {
            _sMService = sMService;
        }

        public IActionResult Index()
        {
            var model = new EnterGameViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] EnterGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var marker = new Marker()
            {
                team = model.Team,
                teamColor = (Color)model.SelectedColor,
                Id = model.Id,
            };

            var enterTeam = _sMService.CreateMarker(marker);
            return RedirectToAction("View", enterTeam);
        }

        public IActionResult View(Marker marker)
        {
            if (marker.Id == null )
            {
                return RedirectToAction("Index");
            }
            var markerList = _sMService.GetMarkers();
            var model = new ViewSMViewModel(marker, markerList.ToList());
            return View(model);
        }

        public IActionResult LogOut([FromForm] ViewSMViewModel model)
        {
            var marker = _sMService.GetId(model.markerId);
            _sMService.LogOut(marker.Id);

            return RedirectToAction("Index");
        }
    }
}
