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

        if (httpContext.User.Identity.IsAuthenticated)
        {
            return true;
        }

        var authHeader = httpContext.Request.Headers["Authorization"];

        if (authHeader.Count > 0)
        {
            var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderValue.Parameter)).Split(':');
            var username = credentials[0];
            var password = credentials[1];

            if (username == _username && password == _password)
            {
                var claims = new[] { new Claim("name", username), new Claim(ClaimTypes.Role, "Administrator") };
                var identity = new ClaimsIdentity(claims, "Basic");
                httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(identity));
                return true;
            }
        }

        httpContext.Response.Headers["WWW-Authenticate"] = "Basic";
        httpContext.Response.StatusCode = 401;
        return false;
    }
}
