using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;

namespace Student.Core.RequestResponse.Category.Commands.Create;

public class CreateCategoryCommand : ICommand<bool>, IWebRequest
{
    public string Name { get; set; } = string.Empty;

    public string Path => "/api/Category/Create";
}