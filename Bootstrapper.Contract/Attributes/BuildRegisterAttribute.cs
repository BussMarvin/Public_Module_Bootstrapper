namespace Bootstrapper.Contract.Attributes;

/// <summary>
///     Attribute to mark a class as a build register.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class BuildRegisterAttribute : Attribute
{
}