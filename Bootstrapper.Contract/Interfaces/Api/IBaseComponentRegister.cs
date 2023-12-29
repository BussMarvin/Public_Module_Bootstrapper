namespace Bootstrapper.Contract.Interfaces.Api;

/// <summary>
///     The base component register.
/// </summary>
public interface IBaseComponentRegister
{
    /// <summary>
    ///     Gets the component register.
    /// </summary>
    public IComponentRegister ComponentRegister { get; }

    /// <summary>
    ///     Starts the register.
    /// </summary>
    void StartRegister();
}