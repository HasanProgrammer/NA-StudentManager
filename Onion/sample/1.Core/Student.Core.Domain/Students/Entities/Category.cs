#pragma warning disable CS8618, CS9264
#pragma warning disable CS8604 // Possible null reference argument.

using Student.Core.Domain.Students.Events;
using Zamin.Core.Domain.Entities;

namespace Student.Core.Domain.Students.Entities;

public class Category : AggregateRoot<int>
{
    #region Properties
    
    public string Name { get; private set; }
    public bool IsDeleted { get; private set; }
    
    //navigation
    public ICollection<Student> Students { get; set; }
    
    #endregion

    #region Constructors
    
    private Category(){}

    public Category(string name)
    {
        Name = name;
        
        AddEvent(new CategoryCreated(Id, name));
    }
    
    #endregion

    #region Commands

    public static Category Create(string name) => new(name);
    
    public void Delete(int id)
    {
        IsDeleted = true;

        AddEvent(new CategoryDeleted(id));
    }
    
    #endregion
}