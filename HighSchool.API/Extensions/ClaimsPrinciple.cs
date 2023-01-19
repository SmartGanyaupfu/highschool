using System;
using System.Security.Claims;

namespace HighSchool.API.Extensions
{
    public static class ClaimsPrinciple
    {
        public static string GetUserId(this ClaimsPrincipal claims)
        {
            return claims.FindFirst(ClaimTypes.GivenName)?.Value;
        }

    }
}

