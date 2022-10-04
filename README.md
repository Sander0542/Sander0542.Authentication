# Sander0542.Authentication
![Last commit](https://img.shields.io/github/last-commit/Sander0542/Sander0542.Authentication?style=for-the-badge)
![License](https://img.shields.io/github/license/Sander0542/Sander0542.Authentication?style=for-the-badge)

Packages for adding authentication to your ASP.NET Core application.

## Packages

| Package                                | NuGet Latest | Downloads |
|----------------------------------------|--------------|-----------|
| Sander0542.Authentication.Authelia | ![Current release](https://img.shields.io/nuget/v/Sander0542.Authentication.Authelia) | ![Downloads](https://img.shields.io/nuget/dt/Sander0542.Authentication.Authelia) |

## Usage

### Authelia

```c#
builder.Services.AddAuthentication(AutheliaDefaults.AuthenticationScheme)
    .AddAuthelia();

app.UseAuthentication();
```

## Contributors
![Contributors](https://contrib.rocks/image?repo=Sander0542/Sander0542.Authentication)