using Autofac;

namespace Bootstrapper.Contract.Interfaces.Api;

/// <summary>
///     Bootstrapper for the application.
/// </summary>
public interface IApplicationBootstrapper
{
    /// <summary>
    ///     Gets the component module mappings.
    /// </summary>
    /// <returns>A TModuleInterface.</returns>
    TModuleInterface GetComponentMappings<TModuleInterface>() where TModuleInterface : class;

    /// <summary>
    ///     Configure the Bootstrapper register the Testing Modules.
    /// </summary>
    void IsTestingBuild();

    /// <summary>
    ///     Starts the bootstrapping.
    /// </summary>
    /// <returns>An IContainer.</returns>
    IContainer StartBootstrapping();
}