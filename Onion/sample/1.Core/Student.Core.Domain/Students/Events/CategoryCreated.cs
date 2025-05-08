using Zamin.Core.Domain.Events;

namespace Student.Core.Domain.Students.Events;

public record CategoryCreated(int id, string name) : IDomainEvent;