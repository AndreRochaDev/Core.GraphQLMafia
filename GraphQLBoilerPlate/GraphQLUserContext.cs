using System.Security.Claims;

namespace GraphQLBoilerplate
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}
