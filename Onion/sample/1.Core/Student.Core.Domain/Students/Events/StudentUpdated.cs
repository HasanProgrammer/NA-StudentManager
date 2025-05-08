using Zamin.Core.Domain.Events;

namespace Student.Core.Domain.Students.Events;

public record StudentUpdated(int id,
    int categoryId,
    string Code,
    string FirstName,
    string LastName,
    string ImagePath) : IDomainEvent;