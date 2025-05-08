using Student.Core.Contracts.Students.Commands;
using Student.Core.Domain.Students.ValueObjects;
using Student.Core.RequestResponse.Student.Commands.Create;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Student.Core.ApplicationService.Students.Commands.Create;

public class CreateStudentCommandHandler : CommandHandler<CreateStudentCommand, bool>
{
    private readonly IStudentCommandRepository _studentCommandRepository;

    public CreateStudentCommandHandler(ZaminServices zaminServices, IStudentCommandRepository studentCommandRepository) 
        : base(zaminServices)
    {
        _studentCommandRepository = studentCommandRepository;
    }

    public override async Task<CommandResult<bool>> Handle(CreateStudentCommand command)
    {
        var student = new Domain.Students.Entities.Student(
            command.CategoryId, 
            Code.FromString(command.Code),
            FirstName.FromString(command.FirstName), 
            LastName.FromString(command.LastName), command.Path
        );

        await _studentCommandRepository.InsertAsync(student);

        await _studentCommandRepository.CommitAsync();

        return Ok(true);
    }
}