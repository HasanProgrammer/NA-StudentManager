#pragma warning disable CS8618, CS9264

using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Student.Core.Domain.Students.ValueObjects;

public class Code : BaseValueObject<Code>
{
    #region Properties
    
    public string Value { get; private set; }
    
    #endregion

    #region Constructors and Factories
    
    public static Code FromString(string value) => new(value);
    
    private Code(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire {0}", nameof(Code));
        
        if (value.Length != 10)
            throw new InvalidValueObjectStateException("ValidationErrorStringLength {0} {1}", nameof(Code), "10");
        
        Value = value;
    }
    
    private Code(){}
    
    #endregion


    #region Equality Check
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    #endregion

    #region Operator Overloading
    
    public static explicit operator string(Code title) => title.Value;
    
    public static implicit operator Code(string value) => new(value);
    
    #endregion

    #region Methods
    
    public override string ToString() => Value;

    #endregion
}