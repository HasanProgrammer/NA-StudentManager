using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;

namespace Student.Core.RequestResponse.Category.Commands.Delete;

public class DeleteCategoryCommand : ICommand, IWebRequest
{
    public int Id { get; set; }

    public string Path => "/api/Category/Delete";
}