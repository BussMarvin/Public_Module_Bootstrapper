using Bootstrapper.Contract.Interfaces;
using Bootstrapper.Contract.Interfaces.Api;

namespace Bootstrapper.Api;

public class BaseComponentRegister : IBaseComponentRegister
{
    public BaseComponentRegister(IComponentRegister componentRegister)
    {
        ComponentRegister = componentRegister ?? throw new ArgumentNullException(nameof(componentRegister));
    }

    public IComponentRegister ComponentRegister { get; }


    public void StartRegister()
    {
    }
}