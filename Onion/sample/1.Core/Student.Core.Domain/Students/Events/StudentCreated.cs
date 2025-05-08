using Zamin.Core.Domain.Events;

namespace Student.Core.Domain.Students.Events;

public record StudentCreated(int id,
    int categoryId,
    string Code,
    string FirstName,
    string LastName,
    string ImagePath) : IDomainEvent;