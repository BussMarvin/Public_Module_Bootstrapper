using Autofac;
using Bootstrapper.Api;
using Bootstrapper.Contract.Interfaces;
using Bootstrapper.Contract.Interfaces.Api;
using Bootstrapper.Logic;

namespace Bootstrapper.Mapping;

public class BootstrapperMapping : IClassMapping, IRegisterComponents<BootstrapperMapping>
{
    protected readonly ContainerBuilder _builder = new();
    private bool _useDefaultComponentRegister = true;


    public IContainer Build()
    {
        RegisterComponents();
        return _builder.Build();
    }

    public BootstrapperMapping RegisterComponentRegister<T>() where T : IBaseComponentRegister
    {
        _useDefaultComponentRegister = false;

        _builder.RegisterType<T>()
            .As<IBaseComponentRegister>()
            .SingleInstance();
        return this;
    }


    protected virtual void RegisterComponents()
    {
        RegisterBootstrapper();
        RegisterComponentMapping();
        ValidateRegistrationClasses();

        RegisterBaseComponentRegister();
    }


    private void RegisterBootstrapper()
    {
        _builder.RegisterType<ApplicationBootstrapper>()
            .As<IApplicationBootstrapper>()
            .SingleInstance();
    }


    private void RegisterComponentMapping()
    {
        _builder.RegisterType<ComponentRegister>()
            .As<IComponentRegister>()
            .SingleInstance();
    }

    private void ValidateRegistrationClasses()
    {
        _builder.RegisterType<ValidateRegistrationClasses>()
            .As<IValidateRegistrationClasses>()
            .SingleInstance();
    }


    private void RegisterBaseComponentRegister()
    {
        if (!_useDefaultComponentRegister) return;

        _builder.RegisterType<BaseComponentRegister>()
            .As<IBaseComponentRegister>()
            .SingleInstance();
    }
}