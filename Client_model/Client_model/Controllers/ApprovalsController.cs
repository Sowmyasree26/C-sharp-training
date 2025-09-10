using System.Linq;
using System.Web.Mvc;
using Client_model.Helpers;
using Client_model.Models;

namespace Client_model.Controllers
{
    public class ApprovalsController : Controller
    {
        private readonly InsuranceDB1Entities _db = new InsuranceDB1Entities();

        public ActionResult Index()
        {
            var list = _db.UserPolicies
                .Where(up => up.Policy.ClientID == ClientContext.CurrentClientId && up.Status == "Pending")
                .OrderByDescending(up => up.CreatedAt)
                .Select(up => new {
                    Policy = up.Policy.PolicyName,
                    Holder = up.User.FullName,
                    up.Status,
                    up.PaymentStatus,
                    up.StartDate,
                    up.EndDate
                }).ToList();
            return View(list);
        }
    }
}
