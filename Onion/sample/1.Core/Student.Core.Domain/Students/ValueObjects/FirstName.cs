#pragma warning disable CS8618, CS9264

using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Student.Core.Domain.Students.ValueObjects;

public class FirstName : BaseValueObject<FirstName>
{
    #region Properties
    
    public string Value { get; private set; }
    
    #endregion

    #region Constructors and Factories
    
    public static FirstName FromString(string value) => new(value);
    
    private FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire {0}", nameof(FirstName));
        
        if (value.Length < 5 || value.Length > 15)
            throw new InvalidValueObjectStateException("ValidationErrorStringLength {0} {1} {2}", nameof(FirstName), "5", "15");
        
        Value = value;
    }
    
    private FirstName(){}
    
    #endregion


    #region Equality Check
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    #endregion

    #region Operator Overloading
    
    public static explicit operator string(FirstName title) => title.Value;
    
    public static implicit operator FirstName(string value) => new(value);
    
    #endregion

    #region Methods
    
    public override string ToString() => Value;

    #endregion
}