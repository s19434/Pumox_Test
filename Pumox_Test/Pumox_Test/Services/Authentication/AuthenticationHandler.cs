using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Pumox_Test.Services.Authentication
{
    public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserDbService _userContext;
        private Logged_User user;

        public AuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IUserDbService userService)
            : base(options, logger, encoder, clock)
        {
            _userContext = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");


            try
            {
                string base64 = string.Empty;
                if (Request.Headers.TryGetValue("Authorization", out var value))
                {
                    base64 = value;
                }

                var credentialBytes = Convert.FromBase64String(base64);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(
                    new[] { ':' }, 2);

                var UserName = credentials[0];
                var Password = credentials[1];

                user = await _userContext.Authentication(UserName, Password);
            }
            catch
            {
                return AuthenticateResult.Fail("Error, authorization header is not correct ");
            }
            if (user == null)
                return AuthenticateResult.Fail("Error, user or password is not correct ");
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.IdLogged_User.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
