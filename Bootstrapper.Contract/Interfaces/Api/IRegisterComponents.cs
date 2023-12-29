namespace Bootstrapper.Contract.Interfaces.Api;

/// <summary>
///     Interface for register components register.
/// </summary>
public interface IRegisterComponents<TReturnValue> where TReturnValue : class
{
    /// <summary>
    ///     Registers the component register.
    /// </summary>
    /// <returns>A TReturnValue.</returns>
    TReturnValue RegisterComponentRegister<T>() where T : IBaseComponentRegister;
}