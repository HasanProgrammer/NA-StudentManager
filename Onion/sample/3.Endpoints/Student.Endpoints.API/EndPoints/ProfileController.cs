using Microsoft.AspNetCore.Mvc;
using Zamin.EndPoints.Web.Controllers;

namespace Student.Endpoints.API.EndPoints;

[Route("api/[controller]")]
public class ProfileController : BaseController
{
    [HttpPost("Upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("تصویری انتخاب نشده است.");

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "Images");

        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        
        await file.CopyToAsync(stream);

        var imageUrl = $"/Storage/Images/{uniqueFileName}";
        
        return Ok(new { filePath = imageUrl });
    }
}