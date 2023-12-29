using Autofac;
using Bootstrapper.Contract.Attributes;
using Bootstrapper.Contract.Interfaces;

namespace Bootstrapper.Logic;

internal class ComponentRegister : IComponentRegister
{
    private readonly List<IConfigure> _configureModules = new();
    private readonly List<Module> _mappings = new();


    private readonly IValidateRegistrationClasses _registrationValidator;

    public ComponentRegister(IValidateRegistrationClasses registrationValidator)
    {
        _registrationValidator = registrationValidator ?? throw new ArgumentNullException(nameof(registrationValidator));
    }

    public List<Module> GetTestingMappings()
    {
        return _registrationValidator.ValidateClasses<Module, TestingRegisterAttribute>(_mappings);
    }

    public List<Module> GetBuildMappings()
    {
        return _registrationValidator.ValidateClasses<Module, BuildRegisterAttribute>(_mappings);
    }

    public TModuleInterface GetComponentMappings<TModuleInterface>() where TModuleInterface : class
    {
        return _mappings.First(mapping => mapping is TModuleInterface) as TModuleInterface;
    }

    public List<IConfigure> GetConfigureModules()
    {
        return _registrationValidator.ValidateClasses<IConfigure, BuildRegisterAttribute>(_configureModules);
    }

    public List<IConfigure> GetTestingConfigureModules()
    {
        return _registrationValidator.ValidateClasses<IConfigure, TestingRegisterAttribute>(_configureModules);
    }

    public void AddMapping(Module mapping)
    {
        _mappings.Add(mapping);
    }

    public void AddConfigureModule(IConfigure configureModule)
    {
        _configureModules.Add(configureModule);
    }
}