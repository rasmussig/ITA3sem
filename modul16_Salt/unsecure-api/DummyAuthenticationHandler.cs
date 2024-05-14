using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

public class DummyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public DummyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
        ) : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // Vi undersøge lige om anonym adgang er tilladt
        var endpoint = Context.GetEndpoint();
        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        {
            // Hvis anonym adgang er tilladt, skal vi ikke lave authentication
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        // Vi fisker en header ud hvor key er "Authorization"
        var authHeader = Request.Headers["Authorization"].ToString();

        // Vi tjekker efterfølgende på om "Authorization" findes, og på om dens value starte med "Password".
        if (authHeader != null && authHeader.StartsWith("Password", StringComparison.OrdinalIgnoreCase))
        {
            var password = authHeader.Substring("Password ".Length).Trim();

            var adminsalt = "9sPF4BfrfY8gTSc/JGFSDA==";
            var cakesalt = "9DvUqynyKp8oSWGwWP/Y1g==";

            string adminhashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(adminsalt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            string cakehashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(cakesalt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            // Nu tjekkes om password er korrekt
            // if (password == "password123")
            if(adminhashed == "M4UsoTAXz5FaCrxhN9MOeSWXVk0eUQBcZEy8xR+diIs=")
            {
                // Vi opretter et "claim"
                var claims = new[] { new Claim("Role", "Admin") };
                var identity = new ClaimsIdentity(claims);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                // Claim returneres og giver nu adgang til endpoints der i deres 
                // policty har "Role = Admin".
                return Task.FromResult(AuthenticateResult.Success(
                    new AuthenticationTicket(claimsPrincipal, "DummyAuthentication")));
            }

            // if (password == "cake123")
            if(cakehashed == "HlYi0rsxYYqb3PMH51puig2KgkbtHv2Z0VGAy1UgdfM=")
            {
                // Vi opretter et "claim"
                var claims = new[] { new Claim("Role", "CakeLover") };
                var identity = new ClaimsIdentity(claims);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                // Claim returneres og giver nu adgang til endpoints der i deres 
                // policty har "Role = Admin".
                return Task.FromResult(AuthenticateResult.Success(
                    new AuthenticationTicket(claimsPrincipal, "DummyAuthentication")));
            }
        }

        Response.StatusCode = 401;
        return Task.FromResult(AuthenticateResult.Fail("Invalid Password"));
    }
}