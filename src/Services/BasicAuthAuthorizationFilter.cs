using Hangfire.Annotations;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class BasicAuthAuthorizationFilter : IDashboardAuthorizationFilter
{
    private readonly string _authenticationScheme;

    public BasicAuthAuthorizationFilter(string authenticationScheme)
    {
        _authenticationScheme = authenticationScheme;
    }

    public bool Authorize([NotNull] DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        return Task.Run(() => httpContext.AuthenticateAsync(_authenticationScheme)).Result.Succeeded;
    }
}
