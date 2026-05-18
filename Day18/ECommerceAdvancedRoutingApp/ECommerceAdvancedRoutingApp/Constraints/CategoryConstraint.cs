using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq;



namespace ECommerceAdvancedRoutingApp.Constraints
{
    public class CategoryConstraint : IRouteConstraint
    {
        private readonly string[] validCategories =
            { "Electronics", "Clothing", "Books" };

        public bool Match(HttpContext httpContext, IRouter route,
            string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return validCategories.Contains(values[routeKey]?.ToString());
        }
    }
}
