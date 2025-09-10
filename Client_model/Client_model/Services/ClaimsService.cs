using System.Linq;
using Client_model.Models;


namespace Client_model.Services
{
    public class ClaimsService
    {
        private readonly InsuranceDB1Entities _db;
        public ClaimsService(InsuranceDB1Entities db) { _db = db; }

        public IQueryable<Claim> GetClaims(int clientId)
        {
            return _db.Claims.Where(c => c.UserPolicy.Policy.ClientID == clientId)
                             .OrderByDescending(c => c.ClaimDate);
        }
    }
}
