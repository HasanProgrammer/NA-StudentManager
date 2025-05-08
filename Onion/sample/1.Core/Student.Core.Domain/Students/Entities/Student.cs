#pragma warning disable CS8618, CS9264
#pragma warning disable CS8604 // Possible null reference argument.

using Student.Core.Domain.Students.Events;
using Student.Core.Domain.Students.ValueObjects;
using Zamin.Core.Domain.Entities;

namespace Student.Core.Domain.Students.Entities;

public class Student : AggregateRoot<int>
{
    #region Properties
    
    public int CategoryId { get; private set; }
    public Code Code { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public string ImagePath { get; private set; }
    public bool IsDeleted { get; private set; }
    
    //navigation
    public Category Category { get; set; }
    
    #endregion

    #region Constructors
    
    private Student(){}
    
    public Student(int categoryId, Code code, FirstName firstName, LastName lastName, string imagePath)
    {
        CategoryId = categoryId;
        Code = code;
        FirstName = firstName;
        LastName = lastName;
        ImagePath = imagePath;

        AddEvent(new StudentCreated(Id, categoryId, Code.Value, FirstName.Value, LastName.Value, ImagePath));
    }
    
    #endregion

    #region Commands
    
    public static Student Create(int categoryId, Code code, FirstName firstName, LastName lastName, string imagePath) 
        => new(categoryId, code, firstName, lastName, imagePath);

    public void Update(int categoryId, FirstName firstName, LastName lastName, string imagePath)
    {
        CategoryId = categoryId;
        FirstName = firstName;
        LastName = lastName;
        ImagePath = imagePath;

        AddEvent(new StudentUpdated(Id, categoryId, Code.Value, FirstName.Value, LastName.Value, ImagePath));
    }
    
    public void Delete(int id)
    {
        IsDeleted = true;

        AddEvent(new StudentDeleted(id));
    }
    
    #endregion
}