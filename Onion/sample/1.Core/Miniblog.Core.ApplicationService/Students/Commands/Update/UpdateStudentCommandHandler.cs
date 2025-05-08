using Student.Core.Contracts.Students.Commands;
using Student.Core.RequestResponse.Student.Commands.Update;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Student.Core.ApplicationService.Students.Commands.Update;

public sealed class UpdateStudentCommandHandler : CommandHandler<UpdateStudentCommand>
{
    private readonly IStudentCommandRepository _studentCommandRepository;

    public UpdateStudentCommandHandler(
        ZaminServices zaminServices, IStudentCommandRepository studentCommandRepository
    ) : base(zaminServices)
    {
        _studentCommandRepository = studentCommandRepository;
    }

    public override async Task<CommandResult> Handle(UpdateStudentCommand command)
    {
        var stude = await _studentCommandRepository.GetAsync(command.Id);

        if (stude is null)
            throw new InvalidEntityStateException("دانش آموز یافت نشد");

        stude.Update(command.CategoryId, command.FirstName, command.LastName, command.Path);

        await _studentCommandRepository.CommitAsync();

        return Ok();
    }
}