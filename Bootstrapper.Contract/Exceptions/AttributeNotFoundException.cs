using System.Text;

namespace Bootstrapper.Contract.Exceptions;

/// <summary>
///     Exception thrown when a class is missing a required attribute.
/// </summary>
public class AttributeNotFoundException : Exception
{
    protected string _firstErrorMessageLine;

    public AttributeNotFoundException(List<Type> listOfClasses, string expectedAttributeName)
    {
        _firstErrorMessageLine = $"The following classes are missing the required '{expectedAttributeName}':";
        Message = GetErrorMessage(listOfClasses);
        ListOfClasses = listOfClasses;
    }

    public List<Type> ListOfClasses { get; }
    public override string Message { get; }


    private string GetErrorMessage(List<Type> listOfClasses)
    {
        StringBuilder sb = new();
        sb.AppendLine(_firstErrorMessageLine);
        foreach (Type type in listOfClasses)
        {
            sb.AppendLine(type.Name);
        }

        return sb.ToString();
    }
}