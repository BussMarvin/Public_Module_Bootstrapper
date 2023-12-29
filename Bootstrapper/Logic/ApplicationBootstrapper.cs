using Autofac;
using Bootstrapper.Contract.Interfaces;
using Bootstrapper.Contract.Interfaces.Api;

namespace Bootstrapper.Logic;

internal class ApplicationBootstrapper : IApplicationBootstrapper
{
    private readonly IComponentRegister _componentRegister;

    private IContainer? _applicationContainer;

    private bool _isTesting;

    public ApplicationBootstrapper(IBaseComponentRegister baseComponentRegister)
    {
        _componentRegister = baseComponentRegister.ComponentRegister;
    }


    public TMappingInterface GetComponentMappings<TMappingInterface>() where TMappingInterface : class
    {
        return _componentRegister.GetComponentMappings<TMappingInterface>();
    }

    public void IsTestingBuild()
    {
        _isTesting = true;
    }


    public IContainer StartBootstrapping()
    {
        if (_applicationContainer != null) return _applicationContainer;


        _applicationContainer = BuildComponents(HarvestMappings());

        return HarvestComponentsConfigure(_applicationContainer);
    }


    private IContainer BuildComponents(List<Module> componentsContainer)
    {
        ContainerBuilder builder = new();

        foreach (Module componentContainer in componentsContainer)
        {
            builder.RegisterModule(componentContainer);
        }

        return builder.Build();
    }

    private List<Module> HarvestMappings()
    {
        if (_isTesting) return _componentRegister.GetTestingMappings();

        return _componentRegister.GetBuildMappings();
    }

    private List<IConfigure> HarvestConfigure()
    {
        if (_isTesting) return _componentRegister.GetTestingConfigureModules();

        return _componentRegister.GetConfigureModules();
    }

    private IContainer HarvestComponentsConfigure(IContainer container)
    {
        var harvestConfigure = HarvestConfigure();

        foreach (IConfigure configure in harvestConfigure)
        {
            configure.Configure(container);
        }

        return container;
    }
}