using Autofac;

namespace Bootstrapper.Contract.Interfaces;

/// <summary>
///     The Register for the Mapping Modules.
/// </summary>
public interface IComponentRegister
{
    /// <summary>
    ///     Gets the testing mappings.
    /// </summary>
    /// <returns>A list of Mapping Modules.</returns>
    List<Module> GetTestingMappings();

    /// <summary>
    ///     Gets the build mappings.
    /// </summary>
    /// <returns>A list of Mapping Modules.</returns>
    List<Module> GetBuildMappings();

    /// <summary>
    ///     Gets the configure modules.
    /// </summary>
    /// <returns>A list of IConfigures.</returns>
    List<IConfigure> GetConfigureModules();

    /// <summary>
    ///     Gets the testing configure modules.
    /// </summary>
    /// <returns>A list of IConfigures.</returns>
    List<IConfigure> GetTestingConfigureModules();

    /// <summary>
    ///     Gets the component mappings.
    /// </summary>
    /// <returns>A TMappingInterface.</returns>
    TMappingInterface GetComponentMappings<TMappingInterface>() where TMappingInterface : class;

    /// <summary>
    ///     Adds the mapping.
    /// </summary>
    /// <param name="mapping">The mapping.</param>
    void AddMapping(Module mapping);

    /// <summary>
    ///     Adds the configure module.
    /// </summary>
    /// <param name="configureModule">The configure module.</param>
    void AddConfigureModule(IConfigure configureModule);
}