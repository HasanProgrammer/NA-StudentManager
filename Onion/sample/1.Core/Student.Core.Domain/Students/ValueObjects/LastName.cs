#pragma warning disable CS8618, CS9264

using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Student.Core.Domain.Students.ValueObjects;

public class LastName : BaseValueObject<LastName>
{
    #region Properties
    
    public string Value { get; private set; }
    
    #endregion

    #region Constructors and Factories
    
    public static LastName FromString(string value) => new(value);
    
    private LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire {0}", nameof(LastName));
        
        if (value.Length < 5 || value.Length > 20)
            throw new InvalidValueObjectStateException("ValidationErrorStringLength {0} {1} {2}", nameof(LastName), "5", "20");
        
        Value = value;
    }
    
    private LastName(){}
    
    #endregion


    #region Equality Check
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    #endregion

    #region Operator Overloading
    
    public static explicit operator string(LastName title) => title.Value;
    
    public static implicit operator LastName(string value) => new(value);
    
    #endregion

    #region Methods
    
    public override string ToString() => Value;

    #endregion
}