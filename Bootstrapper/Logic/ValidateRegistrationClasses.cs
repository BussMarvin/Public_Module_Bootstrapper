using Bootstrapper.Contract.Exceptions;
using Bootstrapper.Contract.Interfaces;

namespace Bootstrapper.Logic;

internal class ValidateRegistrationClasses : IValidateRegistrationClasses
{
    public List<TInterface> ValidateClasses<TInterface, TAttribute>(List<TInterface> classList)
        where TInterface : class
        where TAttribute : Attribute
    {
        var classesWithoutAttribute = FindClassesWithoutAttribute(classList);
        if (classesWithoutAttribute.Count > 0) throw new AttributeNotFoundException(GetTypesFromList(classesWithoutAttribute), typeof(TAttribute).Name);

        var classesWithAttribute = FindClassesWithAttribute<TInterface, TAttribute>(classList);

        return classesWithAttribute;
    }


    private List<TInterface> FindClassesWithAttribute<TInterface, TAttribute>(
        List<TInterface> classList)
        where TInterface : class
        where TAttribute : Attribute
    {
        Type attributeType = typeof(TAttribute);

        var classesWithAttribute = classList
            .Where(@class =>
                @class.GetType().IsDefined(attributeType, false)
            )
            .ToList();

        return classesWithAttribute;
    }


    private List<TInterface> FindClassesWithoutAttribute<TInterface>(List<TInterface> classList)
        where TInterface : class

    {
        var classesWithoutAttribute = classList
            .Where(@class => @class.GetType().GetCustomAttributes(false).Length == 0)
            .ToList();


        return classesWithoutAttribute;
    }

    private List<Type> GetTypesFromList<TInterface>(List<TInterface> list)
    {
        var types = new List<Type>();

        foreach (TInterface data in list)

        {
            types.Add(data.GetType());
        }

        return types;
    }
}