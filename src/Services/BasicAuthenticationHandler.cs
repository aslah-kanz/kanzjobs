using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IConfiguration _configuration;

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IConfiguration configuration)
        : base(options, logger, encoder, clock)
    {
        _configuration = configuration;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var headers = Request.Headers;
        if (!headers.ContainsKey("Authorization"))
        {
            Response.Headers["WWW-Authenticate"] = "Basic realm=\"Kanzway\"";
            return AuthenticateResult.Fail("Authorization header missing");
        }

        var authHeader = headers["Authorization"].ToString();
        if (!authHeader.StartsWith("Basic "))
        {
            Response.Headers["WWW-Authenticate"] = "Basic realm=\"Kanzway\"";
            return AuthenticateResult.Fail("Invalid authentication scheme");
        }

        var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Substring("Basic ".Length).Trim())).Split(':');
        if (credentials.Length != 2)
        {
            Response.Headers["WWW-Authenticate"] = "Basic realm=\"Kanzway\"";
            return AuthenticateResult.Fail("Invalid credentials");
        }

        var username = credentials[0];
        var password = credentials[1];

        var configUsername = _configuration["BasicAuthentication:Username"];
        var configPassword = _configuration["BasicAuthentication:Password"];

        if (username != configUsername || password != configPassword)
        {
            Response.Headers["WWW-Authenticate"] = "Basic realm=\"Kanzway\"";
            return AuthenticateResult.Fail("Invalid credentials");
        }

        var claims = new[] { new Claim(ClaimTypes.Name, username) };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}
