using Student.Core.Contracts.Students.Commands;
using Student.Core.RequestResponse.Category.Commands.Delete;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Student.Core.ApplicationService.Categories.Commands.Delete;

public sealed class DeleteCommandHandler(
    ZaminServices zaminServices, 
    ICategoryCommandRepository categoryCommandRepository
) : CommandHandler<DeleteCategoryCommand>(zaminServices)
{
    public override async Task<CommandResult> Handle(DeleteCategoryCommand command)
    {
        var category = await categoryCommandRepository.GetAsync(command.Id) ?? throw new InvalidEntityStateException("دسته بندی یافت نشد");
        
        category.Delete(category.Id);

        categoryCommandRepository.Delete(category);

        await categoryCommandRepository.CommitAsync();

        return Ok();
    }
}