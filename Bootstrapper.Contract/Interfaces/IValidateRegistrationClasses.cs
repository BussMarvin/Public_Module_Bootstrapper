namespace Bootstrapper.Contract.Interfaces;

/// <summary>
///     Validate the registration classes with the attribute.
/// </summary>
public interface IValidateRegistrationClasses
{
    /// <summary>
    ///     Validates the classes.
    /// </summary>
    /// <param name="classList">The class list.</param>
    /// <returns>A list of TInterfaces.</returns>
    List<TInterface> ValidateClasses<TInterface, TAttribute>(List<TInterface> classList)
        where TInterface : class
        where TAttribute : Attribute;
}