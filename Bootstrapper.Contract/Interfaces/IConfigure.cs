using Autofac;

namespace Bootstrapper.Contract.Interfaces;

/// <summary>
///     Interface to configure data.
/// </summary>
public interface IConfigure
{
    /// <summary>
    ///     Start the configuration.
    /// </summary>
    /// <param name="container">The container.</param>
    void Configure(IContainer container);
}