using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Sander0542.Authentication.Authelia;

public class AutheliaHandler : AuthenticationHandler<AutheliaOptions>
{
    public AutheliaHandler(IOptionsMonitor<AutheliaOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var userHeader = Context.Request.Headers[HeaderNames.RemoteUser].ToString();

        if (string.IsNullOrEmpty(userHeader))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        var groupsHeader = Context.Request.Headers[HeaderNames.RemoteGroups].ToString();
        var groups = groupsHeader.Split(",");

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userHeader),
            new(ClaimTypes.Name, Context.Request.Headers[HeaderNames.RemoteName].ToString()),
            new(ClaimTypes.Email, Context.Request.Headers[HeaderNames.RemoteEmail].ToString()),
        };
        claims.AddRange(groups.Select(group => new Claim(ClaimTypes.Role, group)));
        claims.RemoveAll(claim => string.IsNullOrEmpty(claim.Value));

        var claimsIdentity = new ClaimsIdentity(claims, nameof(AutheliaHandler));

        var ticket = new AuthenticationTicket(new(claimsIdentity), Scheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
