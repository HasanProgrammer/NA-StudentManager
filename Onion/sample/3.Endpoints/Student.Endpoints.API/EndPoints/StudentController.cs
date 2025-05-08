using Microsoft.AspNetCore.Mvc;
using MiniBlog.Endpoints.API.DTOs;
using Zamin.EndPoints.Web.Controllers;
using Student.Core.RequestResponse.Student.Commands.Create;
using Student.Core.RequestResponse.Student.Commands.Delete;
using Student.Core.RequestResponse.Student.Commands.Update;
using Student.Core.RequestResponse.Student.DTOs;
using Student.Core.RequestResponse.Student.Queries.GetStudentById;

namespace Student.Endpoints.API.EndPoints;

[Route("api/[controller]")]
public class StudentController : BaseController
{
    #region Commands

    [HttpPost("Create")]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto dto)
    {
        var command = new CreateStudentCommand {
            CategoryId = dto.CategoryId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            ImagePath = dto.ImagePath,
            Code = Random.Shared.Next(10).ToString()
        };
        
        return await Create<CreateStudentCommand, bool>(command);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command) => await Edit(command);

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteStudent([FromBody] DeleteStudentCommand command) => await Delete(command);
        
    #endregion

    #region Queries
        
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(GetStudentByIdQuery query) => await Query<GetStudentByIdQuery, StudentDto?>(query);
        
    #endregion
}