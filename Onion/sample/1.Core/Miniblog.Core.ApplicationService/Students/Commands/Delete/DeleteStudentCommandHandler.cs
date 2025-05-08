using Student.Core.Contracts.Students.Commands;
using Student.Core.RequestResponse.Student.Commands.Delete;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Student.Core.ApplicationService.Students.Commands.Delete;

public sealed class DeleteStudentCommandHandler(
    ZaminServices zaminServices, 
    IStudentCommandRepository studentCommandRepository
) : CommandHandler<DeleteStudentCommand>(zaminServices)
{
    public override async Task<CommandResult> Handle(DeleteStudentCommand command)
    {
        var student = await studentCommandRepository.GetAsync(command.Id) ?? throw new InvalidEntityStateException("دانش آموز یافت نشد");
        
        student.Delete(command.Id);

        studentCommandRepository.Delete(student);

        await studentCommandRepository.CommitAsync();

        return Ok();
    }
}