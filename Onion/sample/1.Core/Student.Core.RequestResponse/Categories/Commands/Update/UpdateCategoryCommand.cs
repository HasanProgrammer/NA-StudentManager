
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;

namespace Student.Core.RequestResponse.Category.Commands.Update;

public class UpdateCategoryCommand : ICommand, IWebRequest
{ 
    public string Name { get; set; } = string.Empty;

    public string Path => "/api/Category/Update";
}