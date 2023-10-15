using EPS.Utils.Repository.Audit;
using System.Security.Claims;

namespace EPS.API.Helpers
{
    public class UserIdentity : IUserIdentity<int>
    {
        private readonly ClaimsPrincipal _claimsPrincipal;

        public UserIdentity(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }

        private string GetClaimValue(string claimType)
        {
            var claim = _claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
            return claim == null ? "" : claim.Value;
        }
        private List<string> GetPrivileges(string claimType)
        {
            List<string> lstPrivileges = new List<string>();
            var claim = _claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
            if (claim!= null && !string.IsNullOrEmpty(claim.Value))
            {
                lstPrivileges = claim.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                //int start = 0;
                //while (start < claim.Value.Length)
                //{
                //    lstPrivileges.Add(claim.Value.Substring(start, 8));
                //    start += 9;
                //}
            }
            return lstPrivileges;
        }
        public int UserId { get => Convert.ToInt32(GetClaimValue(CustomClaimTypes.UserId)); }
        public string Username { get => GetClaimValue(ClaimTypes.NameIdentifier); }
        public List<string> Privileges { get => GetPrivileges(CustomClaimTypes.Privileges); }
        //public bool IsAdministrator { get => Convert.ToBoolean(GetClaimValue(CustomClaimTypes.Privileges)); }
        public bool IsAdministrator
        {
            get => Convert.ToBoolean(GetClaimValue(CustomClaimTypes.IsAdministrator));
        }
        public string UnitId { get => GetClaimValue(CustomClaimTypes.UnitId); }
        public string UnitCode { get => GetClaimValue(CustomClaimTypes.UnitCode); }
        public int TaiKhoanID { get => Convert.ToInt32(GetClaimValue(CustomClaimTypes.TaiKhoanID)); }
        public string FullName { get => GetClaimValue(ClaimTypes.GivenName); }
    }
}
