using Autofac;

namespace Bootstrapper.Contract.Interfaces;

public interface IClassMapping
{
    IContainer Build();
}