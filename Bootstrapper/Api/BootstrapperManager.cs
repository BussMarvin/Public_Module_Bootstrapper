using Autofac;
using Bootstrapper.Contract.Interfaces;
using Bootstrapper.Contract.Interfaces.Api;
using Bootstrapper.Mapping;

namespace Bootstrapper.Api;

public class BootstrapperManager : IBootstrapperManager, IRegisterComponents<BootstrapperManager>
{
    private readonly IClassMapping _bootstrapperMapping = new BootstrapperMapping();

    private IContainer _container;

    public IApplicationBootstrapper GetApplicationBootstrapper()
    {
        return GetContainer().Resolve<IApplicationBootstrapper>();
    }

    public BootstrapperManager RegisterComponentRegister<T>() where T : IBaseComponentRegister
    {
        if (_bootstrapperMapping is IRegisterComponents<BootstrapperMapping> registerComponents)
            registerComponents.RegisterComponentRegister<T>();
        return this;
    }

    private IContainer GetContainer()
    {
        if (_container == null) InitializeComponents();

        return _container;
    }


    private void InitializeComponents()
    {
        _container = _bootstrapperMapping.Build();
        _container.Resolve<IBaseComponentRegister>().StartRegister();
    }
}