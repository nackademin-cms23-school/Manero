using System.Security.Claims;

namespace Frontend.Helpers
{
    public class ClaimConvert
    {
        public static string GetIdFromUserClaim(ClaimsPrincipal user)
        {
            if (user != null)
            {
                var id = user.FindFirstValue(ClaimTypes.NameIdentifier);
                return id!;
            }
            return null!;
        }
    }
}
