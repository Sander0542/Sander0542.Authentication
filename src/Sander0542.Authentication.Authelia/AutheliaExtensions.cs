using Microsoft.AspNetCore.Authentication;

namespace Sander0542.Authentication.Authelia;

/// <summary>
/// Extensions for enabling Authelia authentication.
/// </summary>
public static class AutheliaExtensions
{
    /// <summary>
    /// Configures the <see cref="AuthenticationBuilder"/> to use Authelia authentication
    /// using the default scheme from <see cref="AutheliaDefaults.AuthenticationScheme"/>.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/>.</param>
    /// <returns>The original builder.</returns>
    public static AuthenticationBuilder AddAuthelia(this AuthenticationBuilder builder)
        => builder.AddAuthelia(AutheliaDefaults.AuthenticationScheme, _ => {});

    /// <summary>
    /// Configures the <see cref="AuthenticationBuilder"/> to use Authelia authentication
    /// using the default scheme. The default scheme is specified by <see cref="AutheliaDefaults.AuthenticationScheme"/>.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/>.</param>
    /// <param name="configureOptions">Allows for configuring the authentication handler.</param>
    /// <returns>The original builder.</returns>
    public static AuthenticationBuilder AddAuthelia(this AuthenticationBuilder builder, Action<AutheliaOptions> configureOptions)
        => builder.AddAuthelia(AutheliaDefaults.AuthenticationScheme, configureOptions);

    /// <summary>
    /// Configures the <see cref="AuthenticationBuilder"/> to use Authelia authentication
    /// using the specified authentication scheme.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/>.</param>
    /// <param name="authenticationScheme">The scheme name used to identify the authentication handler internally.</param>
    /// <param name="configureOptions">Allows for configuring the authentication handler.</param>
    /// <returns>The original builder.</returns>
    public static AuthenticationBuilder AddAuthelia(this AuthenticationBuilder builder, string authenticationScheme, Action<AutheliaOptions> configureOptions)
        => builder.AddAuthelia(authenticationScheme, displayName: null, configureOptions: configureOptions);

    /// <summary>
    /// Configures the <see cref="AuthenticationBuilder"/> to use Authelia authentication
    /// using the specified authentication scheme.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/>.</param>
    /// <param name="authenticationScheme">The scheme name used to identify the authentication handler internally.</param>
    /// <param name="displayName">The name displayed to users when selecting an authentication handler. The default is null to prevent this from displaying.</param>
    /// <param name="configureOptions">Allows for configuring the authentication handler.</param>
    /// <returns>The original builder.</returns>
    public static AuthenticationBuilder AddAuthelia(this AuthenticationBuilder builder, string authenticationScheme, string? displayName, Action<AutheliaOptions> configureOptions)
    {
        return builder.AddScheme<AutheliaOptions, AutheliaHandler>(authenticationScheme, displayName, configureOptions);
    }
}
