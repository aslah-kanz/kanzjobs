using System.Text;
using Hangfire.Dashboard;

public class BasicAuthAuthorizationFilter : IDashboardAuthorizationFilter
{
    private readonly string _username;
    private readonly string _password;

    public BasicAuthAuthorizationFilter(string username, string password)
    {
        _username = username;
        _password = password;
    }

    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();

        if (httpContext.Request.Headers.ContainsKey("Authorization"))
        {
            var authHeader = httpContext.Request.Headers["Authorization"].ToString();
            if (authHeader.StartsWith("Basic "))
            {
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Substring("Basic ".Length).Trim())).Split(':');
                if (credentials.Length == 2)
                {
                    var username = credentials[0];
                    var password = credentials[1];
                    return username == _username && password == _password;
                }
            }
        }

        httpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"Kanzway\"";
        httpContext.Response.StatusCode = 401;
        return false;
    }
}
