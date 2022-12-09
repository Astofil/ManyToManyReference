using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CourseController
{
    private readonly CourseService _courseService;
    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<Response<List<GetCourseDto>>> Get()
    {
        return await _courseService.Get();
    }

    [HttpPost]
    public async Task<Response<AddCourseDto>> Add(AddCourseDto course)
    {
        return await _courseService.Add(course);
    }

    [HttpPut]
    public async Task<Response<AddCourseDto>> Update(AddCourseDto course)
    {
        return await _courseService.Update(course);
    }

    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await _courseService.Delete(id);
    }
}
