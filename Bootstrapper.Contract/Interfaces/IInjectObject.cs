namespace Bootstrapper.Contract.Interfaces;

/// <summary>
///     Interface to Inject objects in the mappings.
/// </summary>
public interface IInjectObject
{
    /// <summary>
    ///     Injects the object.
    /// </summary>
    /// <param name="injectObject">The inject object.</param>
    /// <returns>An IInjectObject.</returns>
    IInjectObject InjectObject<T>(T injectObject) where T : class;
}