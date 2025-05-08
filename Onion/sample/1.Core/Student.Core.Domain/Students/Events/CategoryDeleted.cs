using Zamin.Core.Domain.Events;

namespace Student.Core.Domain.Students.Events;

public record CategoryDeleted(int id) : IDomainEvent;