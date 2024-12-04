using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using StudentAdminission.App.DTOs.Enrollment;
using StudentAdmission.Data;
using StudentAdmission.Data.Contracts;
namespace StudentAdminission.App.Endpoints;

public static class EnrollmentEndpoints
{
    public static void MapEnrollmentEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Enrollment", async (IEnrollmentRepository  repo, IMapper mapper) =>
        {
            return mapper.Map<List<EntrollmentDto>>( await repo.GetAllAsyn());
        })
             .AllowAnonymous()
              .WithTags(nameof(Enrollment))
        .WithName("GetAllEnrollments")
        .Produces<List<EntrollmentDto>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Enrollment/{Id}", async (int Id, IEnrollmentRepository  repo, IMapper mapper) =>
        {
            return await repo.GetByIdAsync(Id)
                is Enrollment model
                    ? Results.Ok(mapper.Map<EntrollmentDto>(model))
                    : Results.NotFound();
        })
             .AllowAnonymous()
             .WithTags(nameof(Enrollment))
        .WithName("GetEnrollmentById")
        .Produces<EntrollmentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Enrollment/{Id}", async (int Id, EntrollmentDto EntrollmentDto, IEnrollmentRepository  repo, IMapper mapper, IValidator<EntrollmentDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(EntrollmentDto);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }
            var foundModel = await repo.GetByIdAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            mapper.Map(EntrollmentDto,foundModel);

            await repo.UpdateAsync(foundModel);

            return Results.NoContent();
        })
              .WithTags(nameof(Enrollment))
        .WithName("UpdateEnrollment")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Enrollment/", async (CreateEntrollmentDto createEntrollmentDto, IEnrollmentRepository  repo, IMapper mapper,
            IValidator<CreateEntrollmentDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(createEntrollmentDto);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }
            var model = mapper.Map<Enrollment>(createEntrollmentDto);
           await repo.AddAsync(model);
            return Results.Created($"/Enrollments/{model.Id}", model);
        })
              .WithTags(nameof(Enrollment))
        .WithName("CreateEnrollment")
        .Produces<Enrollment>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Enrollment/{Id}", [Authorize(Roles = "Administrator")] async (int Id, IEnrollmentRepository  repo) =>
        {
            return await repo.DeleteAsync(Id)? Results.NoContent(): Results.NotFound();
        })
              .WithTags(nameof(Enrollment))
        .WithName("DeleteEnrollment")
        .Produces<Enrollment>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
