namespace Bootstrapper.Contract.Interfaces.Api;

public interface IBootstrapperManager
{
    IApplicationBootstrapper GetApplicationBootstrapper();
}