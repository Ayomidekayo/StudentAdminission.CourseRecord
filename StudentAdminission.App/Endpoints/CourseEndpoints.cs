using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using StudentAdminission.App.DTOs.Course;
using StudentAdmission.Data;
using StudentAdmission.Data.Contracts;
namespace StudentAdminission.App.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Course", async (ICourseRepository repo,IMapper mapper) =>
        {
            var model= await repo.GetAllAsyn();
          return mapper.Map<List<CourseDto>>(model);
        })
             .WithTags(nameof(Course))
        .WithName("GetAllCourses")
        .Produces<List<CourseDto>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Course/{id}", async (int id, ICourseRepository repo,IMapper mapper) =>
        {
            return  await repo.GetByIdAsync(id)
                is Course model
                    ? Results.Ok(mapper.Map<CourseDto>( model))
                    : Results.NotFound();
        })
            .WithTags(nameof(Course))
        .WithName("GetCourseById")
        .Produces<CourseDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapGet("/api/Course/GetStudents/{id}", [Authorize] async (int id, ICourseRepository repo, IMapper mapper) =>
        {
            
            return await repo.GetStudentList(id)
                is Course model
                    ? Results.Ok(mapper.Map<CourseDetailsDto>(model))
                    : Results.NotFound();
        })
          .WithTags(nameof(Course))
      .WithName("GetCourseStudentsById")
      .Produces<CourseDetailsDto>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status404NotFound);
        routes.MapPut("/api/Course/{id}",[Authorize] async (int id, CourseDto CourseDto, ICourseRepository repo,IMapper mapp, IValidator<CourseDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(CourseDto);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }
            var foundModel = await repo.GetByIdAsync(id);
           
            if (foundModel is null)
            {
                return Results.NotFound();
            }
           
            mapp.Map(CourseDto, foundModel);
            await repo.UpdateAsync(foundModel);

            return Results.NoContent();
        })
             .WithTags(nameof(Course))
        .WithName("UpdateCourse")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Course/", [Authorize] async ( CreateCourseDto createCourseDto,ICourseRepository repo,
            IMapper mapper, IValidator<CreateCourseDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(createCourseDto);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }
            var model=mapper.Map<Course>(createCourseDto);
            await repo.AddAsync(model);
            return Results.Created($"/Courses/{model.Id}", model);
        })
             .WithTags(nameof(Course))
        .WithName("CreateCourse")
        .Produces<Course>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Course/{id}", [Authorize(Roles = "Administrator")] async (int id, ICourseRepository repo) =>
        {
            return await repo.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();   
        })
             .WithTags(nameof(Course))
        .WithName("DeleteCourse")
        .Produces<Course>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
