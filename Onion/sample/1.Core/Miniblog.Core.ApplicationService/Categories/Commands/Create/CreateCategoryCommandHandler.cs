using Student.Core.Contracts.Students.Commands;
using Student.Core.Domain.Students.Entities;
using Student.Core.RequestResponse.Category.Commands.Create;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Student.Core.ApplicationService.Categories.Commands.Create;

public class CreateCategoryCommandHandler : CommandHandler<CreateCategoryCommand, bool>
{
    private readonly ICategoryCommandRepository _categoryCommandRepository;

    public CreateCategoryCommandHandler(ZaminServices zaminServices, ICategoryCommandRepository categoryCommandRepository) 
        : base(zaminServices)
    {
        _categoryCommandRepository = categoryCommandRepository;
    }

    public override async Task<CommandResult<bool>> Handle(CreateCategoryCommand command)
    {
        var category = new Category(command.Name);

        await _categoryCommandRepository.InsertAsync(category);

        await _categoryCommandRepository.CommitAsync();

        return Ok(true);
    }
}