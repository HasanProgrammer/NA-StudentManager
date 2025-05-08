using Microsoft.AspNetCore.Mvc;
using Student.Core.RequestResponse.Category.Commands.Create;
using Student.Core.RequestResponse.Category.Commands.Delete;
using Student.Core.RequestResponse.Category.Queries.GetStudentById;
using Zamin.EndPoints.Web.Controllers;
using Student.Core.RequestResponse.Category.DTOs;

namespace Student.Endpoints.API.EndPoints;

[Route("api/[controller]")]
public class CategoryController : BaseController
{
    #region Commands
        
    [HttpPost("Create")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command) => await Create<CreateCategoryCommand, bool>(command);

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand command) => await Delete(command);
        
    #endregion

    #region Queries
        
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(GetCategoryByIdQuery query) => await Query<GetCategoryByIdQuery, CategoryDto?>(query);
        
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(GetCategoryByIdQuery query) => await Query<GetCategoryByIdQuery, CategoryDto?>(query);
    
    #endregion
}