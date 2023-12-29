namespace Bootstrapper.Contract.Exceptions;

public class AttributeIsWrongException : AttributeNotFoundException
{
    public AttributeIsWrongException(List<Type> listOfClasses, string expectedAttributeName) : base(listOfClasses, expectedAttributeName)
    {
        _firstErrorMessageLine = $"The following classes have the wrong attribute. Expected: '{expectedAttributeName}'";
    }
}