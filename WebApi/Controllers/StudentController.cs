using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class StudentController
{
    private readonly StudentService _studentService;
    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }
    
    [HttpGet]
    public async Task<List<GetStudentDto>> Get()
    {
        return await _studentService.Get();
    }

    [HttpPost]
    public async Task<AddStudentDto> Add(AddStudentDto student)
    {
        return await _studentService.Add(student);
    }

    [HttpPut]
    public async Task<AddStudentDto> Update(AddStudentDto student)
    {
        return await _studentService.Update(student);
    }

    [HttpDelete]
    public async Task<string> Delete(int id)
    {
        return await _studentService.Delete(id);
    }
}

