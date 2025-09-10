using System.Web.Mvc;
using Client_model.Helpers;
using Client_model.Services;

namespace Client_model.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly ClaimsService _service;

        public ClaimsController()
        {
            _service = new ClaimsService(new Models.InsuranceDB1Entities());
        }

        public ActionResult Index()
        {
            var clientId = ClientContext.CurrentClientId;
            if (clientId == null) return RedirectToAction("Login", "Account");

            var claims = _service.GetClaims(clientId.Value);
            return View(claims);
        }
    }
}
