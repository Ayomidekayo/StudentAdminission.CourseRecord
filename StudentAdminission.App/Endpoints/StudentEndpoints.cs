using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using StudentAdminission.App.DTOs.Enrollment;
using StudentAdminission.App.DTOs.Student;
using StudentAdminission.App.Services;
using StudentAdmission.Data;
using StudentAdmission.Data.Contracts;
using System.ComponentModel.DataAnnotations;
namespace StudentAdminission.App.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Student", async (IStudentRepository  repo,IMapper mapper) =>
        {
            var model = await repo.GetAllAsyn();
            return mapper.Map<List<StudentDto>>(model);
        })
            .AllowAnonymous()
              .WithTags(nameof(Student))
        .WithName("GetAllStudents")
        .Produces<List<StudentDto>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Student/{Id}", async (int Id, IStudentRepository  repo,IMapper mapper) =>
        {
            return await repo.GetByIdAsync(Id)
                is Student model
                    ? Results.Ok(mapper.Map<StudentDto>(model))
                    : Results.NotFound();
        })
            .AllowAnonymous()
              .WithTags(nameof(Student))
        .WithName("GetStudentDetailsById")
        .Produces<StudentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapGet("/api/Student/GetDetails/{Id}", async (int Id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.GetStudentDetails(Id)
                is Student model
                    ? Results.Ok(mapper.Map<StudentDetailsDto>(model))
                    : Results.NotFound();
        })
            .AllowAnonymous()
             .WithTags(nameof(Student))
       .WithName("GetStudentById")
       .Produces<StudentDetailsDto>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status404NotFound); 

        routes.MapPut("/api/Student/{Id}", [Authorize(Roles = "Administrator")] async (int Id, StudentDto studentDto, 
            IStudentRepository  repo, IMapper mapper, IFileUpload fileUpload, IValidator<StudentDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(studentDto);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }
            var foundModel = await repo.GetByIdAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            var student = mapper.Map(studentDto, foundModel);

            if (studentDto.ProfilePicture != null)
            {
                student.Picture = fileUpload.uploadStudentFile(studentDto.ProfilePicture, studentDto.OriginalFileName);
            }
            await repo.UpdateAsync(foundModel);

            return Results.NoContent();
        })
              .WithTags(nameof(Student))
        .WithName("UpdateStudent")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Student/", [Authorize(Roles = "Administrator")] async (CreateStudentDto createStudentDto, 
            IStudentRepository  repo, IMapper mapper, IFileUpload fileUpload, IValidator<CreateStudentDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(createStudentDto);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }
            var model=mapper.Map<Student>(createStudentDto);
            model.Picture = fileUpload.uploadStudentFile(createStudentDto.ProfilePicture, createStudentDto.OriginalFileName);
            await repo.AddAsync(model);
            
            return Results.Created($"/Students/{model.Id}", model);
        })
              .WithTags(nameof(Student))
        .WithName("CreateStudent")
        .Produces<Student>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Student/{Id}", [Authorize(Roles = "Administrator")] async (int Id, IStudentRepository  repo) =>
        {
            return await repo.DeleteAsync(Id)? Results.NoContent(): Results.NotFound();
        })
              .WithTags(nameof(Student))
        .WithName("DeleteStudent")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
