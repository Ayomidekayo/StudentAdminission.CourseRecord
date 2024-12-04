using StudentAdminission.App.DTOs.Authentication;
using StudentAdminission.App.Services;
using StudentAdminission.App.DTOs;
using FluentValidation;

namespace StudentAdminission.App.Endpoints
{
    public static partial class AuthenticationEndpoint
    {
        public static void MapAuthenticationEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/Login/", async (LogInDto loginDto, IAuthManager authManager, IValidator<LogInDto> validator) =>
            {   
                var validationResult= await  validator. ValidateAsync(loginDto);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.ToDictionary());
                }
               var user=await authManager.Login(loginDto);
                if (user is null)
                    return Results.Unauthorized();
               
                return Results.Ok(user);
            })
                //Generate token.....
                .AllowAnonymous()
            .WithTags("Authurization")
            .WithName("Login")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized);

            routes.MapPost("/api/Register/", async (RegistrationDto registrationDto, IAuthManager authManager,IValidator<LogInDto> validator) =>
            {
                var validationResult = await validator.ValidateAsync(registrationDto);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.ToDictionary());
                }
                var response = await authManager.Registration(registrationDto);
                if (!response.Any())
                    return Results.Ok();
                var errors=new List<ErrorResponseDto>();
                foreach (var error in response)
                {
                    errors.Add(new ErrorResponseDto
                    { 
                        Code=error.Code,
                        Description=error.Description,

                    });
                }
                return Results.BadRequest(errors);
            })
              //Generate token.....
           .AllowAnonymous()
          .WithTags("Authurization")
          .WithName("Register")
          .Produces(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status400BadRequest);
        }
    }
}