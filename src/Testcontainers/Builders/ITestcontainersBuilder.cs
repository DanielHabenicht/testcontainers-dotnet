namespace DotNet.Testcontainers.Builders
{
  using System;
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Docker.DotNet.Models;
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using DotNet.Testcontainers.Images;
  using DotNet.Testcontainers.Networks;
  using DotNet.Testcontainers.Volumes;
  using JetBrains.Annotations;

  /// <summary>
  /// A fluent Testcontainer builder.
  /// </summary>
  /// <typeparam name="TContainerEntity">Type of <see cref="ITestcontainersContainer" />.</typeparam>
  [PublicAPI]
  public interface ITestcontainersBuilder<out TContainerEntity> : IAbstractBuilder<ITestcontainersBuilder<TContainerEntity>>
    where TContainerEntity : ITestcontainersContainer
  {
    /// <summary>
    /// Sets the module configuration of the Testcontainer to override custom properties.
    /// </summary>
    /// <param name="moduleConfiguration">Module configuration action.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> ConfigureContainer(Action<TContainerEntity> moduleConfiguration);

    /// <summary>
    /// Sets the Docker image, which is used to create the Testcontainer instances.
    /// </summary>
    /// <param name="image">The Docker image.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithImage(string image);

    /// <summary>
    /// Sets the Docker image, which is used to create the Testcontainer instances.
    /// </summary>
    /// <param name="image">The Docker image.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithImage(IDockerImage image);

    /// <summary>
    /// Sets the name of the Testcontainer.
    /// </summary>
    /// <param name="name">Testcontainers name.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithName(string name);

    /// <summary>
    /// Sets the hostname of the Testcontainer.
    /// </summary>
    /// <param name="hostname">Testcontainers hostname.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithHostname(string hostname);

    /// <summary>
    /// Overrides the working directory of the Testcontainer for the instruction sets.
    /// </summary>
    /// <param name="workingDirectory">Working directory.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithWorkingDirectory(string workingDirectory);

    /// <summary>
    /// Overrides the entrypoint of the Testcontainer to configure an executable.
    /// </summary>
    /// <param name="entrypoint">Entrypoint executable.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithEntrypoint(params string[] entrypoint);

    /// <summary>
    /// Overrides the command of the Testcontainer to provide defaults for an executing.
    /// </summary>
    /// <param name="command">List of commands, "executable", "param1", "param2" or "param1", "param2".</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithCommand(params string[] command);

    /// <summary>
    /// Exports the environment variable in the Testcontainer.
    /// </summary>
    /// <param name="name">Environment variable name.</param>
    /// <param name="value">Environment variable value.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithEnvironment(string name, string value);

    /// <summary>
    /// Exports the environment variables in the Testcontainer.
    /// </summary>
    /// <param name="environments">Dictionary of environment variables.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithEnvironment(IReadOnlyDictionary<string, string> environments);

    /// <summary>
    /// Sets the port of the Testcontainer to expose, without publishing the port to the host system’s interfaces.
    /// </summary>
    /// <param name="port">Port to expose.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithExposedPort(int port);

    /// <summary>
    /// Exposes the port of the Testcontainer, without publishing the port to the host system’s interfaces.
    /// </summary>
    /// <param name="port">Port to expose.</param>
    /// <remarks>Append /tcp|udp|sctp to change the protocol e.g. "53/udp". Default: tcp.</remarks>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithExposedPort(string port);

    /// <summary>
    /// Binds the port of the Testcontainer to the same port of the host machine.
    /// </summary>
    /// <param name="port">Port to bind between Testcontainer and host machine.</param>
    /// <param name="assignRandomHostPort">True, Testcontainer will bind the port to a random host port, otherwise the host and container ports are the same.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithPortBinding(int port, bool assignRandomHostPort = false);

    /// <summary>
    /// Binds the port of the Testcontainer to the specified port of the host machine.
    /// </summary>
    /// <param name="hostPort">Port of the host machine.</param>
    /// <param name="containerPort">Port of the Testcontainer.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithPortBinding(int hostPort, int containerPort);

    /// <summary>
    /// Binds the port of the Testcontainer to the same port of the host machine.
    /// </summary>
    /// <param name="port">Port to bind between Testcontainer and host machine.</param>
    /// <param name="assignRandomHostPort">True, Testcontainer will bind the port to a random host port, otherwise the host and container ports are the same.</param>
    /// <remarks>Append /tcp|udp|sctp to change the protocol e.g. "53/udp". Default: tcp.</remarks>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithPortBinding(string port, bool assignRandomHostPort = false);

    /// <summary>
    /// Binds the port of the Testcontainer to the specified port of the host machine.
    /// </summary>
    /// <param name="hostPort">Port of the host machine.</param>
    /// <param name="containerPort">Port of the Testcontainer.</param>
    /// <remarks>Append /tcp|udp|sctp to <paramref name="containerPort" /> to change the protocol e.g. "53/udp". Default: tcp.</remarks>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithPortBinding(string hostPort, string containerPort);

    /// <summary>
    /// Binds and mounts the specified host machine volume into the Testcontainer.
    /// </summary>
    /// <param name="source">An absolute path or a name value within the host machine.</param>
    /// <param name="destination">An absolute path as destination in the container.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    [Obsolete("Use WithBindMount(string source, string destination) instead.")]
    ITestcontainersBuilder<TContainerEntity> WithMount(string source, string destination);

    /// <summary>
    /// Binds and mounts the specified host machine volume into the Testcontainer.
    /// </summary>
    /// <param name="source">An absolute path or a name value within the host machine.</param>
    /// <param name="destination">An absolute path as destination in the container.</param>
    /// <param name="accessMode">Volume access mode.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    [Obsolete("Use WithBindMount(string source, string destination, AccessMode accessMode) instead.")]
    ITestcontainersBuilder<TContainerEntity> WithMount(string source, string destination, AccessMode accessMode);

    /// <summary>
    /// Binds and mounts the specified host machine volume into the Testcontainer.
    /// </summary>
    /// <param name="source">An absolute path or a name value within the host machine.</param>
    /// <param name="destination">An absolute path as destination in the container.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithBindMount(string source, string destination);

    /// <summary>
    /// Binds and mounts the specified host machine volume into the Testcontainer.
    /// </summary>
    /// <param name="source">An absolute path or a name value within the host machine.</param>
    /// <param name="destination">An absolute path as destination in the container.</param>
    /// <param name="accessMode">Volume access mode.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithBindMount(string source, string destination, AccessMode accessMode);

    /// <summary>
    /// Mounts the specified managed volume into the Testcontainer.
    /// </summary>
    /// <param name="source">Name of the managed volume.</param>
    /// <param name="destination">An absolute path as destination in the container.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithVolumeMount(string source, string destination);

    /// <summary>
    /// Mounts the specified managed volume into the Testcontainer.
    /// </summary>
    /// <param name="source">Name of the managed volume.</param>
    /// <param name="destination">An absolute path as destination in the container.</param>
    /// <param name="accessMode">Volume access mode.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithVolumeMount(string source, string destination, AccessMode accessMode);

    /// <summary>
    /// Mounts the specified managed volume into the Testcontainer.
    /// </summary>
    /// <param name="source">Name of the managed volume.</param>
    /// <param name="destination">An absolute path as destination in the container.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithVolumeMount(IDockerVolume source, string destination);

    /// <summary>
    /// Mounts the specified managed volume into the Testcontainer.
    /// </summary>
    /// <param name="source">Name of the managed volume.</param>
    /// <param name="destination">An absolute path as destination in the container.</param>
    /// <param name="accessMode">Volume access mode.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithVolumeMount(IDockerVolume source, string destination, AccessMode accessMode);

    /// <summary>
    /// Mounts the specified tmpfs (temporary file system) volume into the Testcontainer.
    /// </summary>
    /// <param name="destination">An absolute path as destination in the container.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithTmpfsMount(string destination);

    /// <summary>
    /// Mounts the specified tmpfs (temporary file system) volume into the Testcontainer.
    /// </summary>
    /// <param name="destination">An absolute path as destination in the container.</param>
    /// <param name="accessMode">Volume access mode.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithTmpfsMount(string destination, AccessMode accessMode);

    /// <summary>
    /// Connects to the specified network.
    /// </summary>
    /// <param name="id">Id of the network to connect to.</param>
    /// <param name="name">Name of the network to connect to.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithNetwork(string id, string name);

    /// <summary>
    /// Connects to the specified network.
    /// </summary>
    /// <param name="dockerNetwork">Network to connect container to.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithNetwork(IDockerNetwork dockerNetwork);

    /// <summary>
    /// Assigns the specified network-scoped aliases to the container.
    /// </summary>
    /// <param name="networkAliases">Network-scoped aliases.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithNetworkAliases(params string[] networkAliases);

    /// <summary>
    /// Assigns the specified network-scoped aliases to the container.
    /// </summary>
    /// <param name="networkAliases">Network-scoped aliases.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithNetworkAliases(IEnumerable<string> networkAliases);

    /// <summary>
    /// If true, the Docker daemon will remove the stopped Testcontainer automatically. Otherwise, the Testcontainer will be kept.
    /// </summary>
    /// <param name="autoRemove">True, the Docker daemon will remove the stopped Testcontainer automatically. Otherwise, the Testcontainer will be kept.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithAutoRemove(bool autoRemove);

    /// <summary>
    /// If true, the Testcontainer will get extended privileges. Otherwise, the Testcontainer will be unprivileged.
    /// </summary>
    /// <param name="privileged">The Testcontainer will get extended privileges. Otherwise, the Testcontainer will be unprivileged.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithPrivileged(bool privileged);

    /// <summary>
    /// Sets the Docker registry authentication configuration to authenticate against private Docker registries.
    /// </summary>
    /// <param name="registryEndpoint">Docker registry endpoint.</param>
    /// <param name="username">Username to authenticate.</param>
    /// <param name="password">Password to authenticate.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    [Obsolete("Use the local Docker credential store.")]
    ITestcontainersBuilder<TContainerEntity> WithRegistryAuthentication(string registryEndpoint, string username, string password);

    /// <summary>
    /// Sets the output consumer to capture the Testcontainer stdout and stderr messages.
    /// </summary>
    /// <param name="outputConsumer">Output consumer to capture stdout and stderr.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithOutputConsumer(IOutputConsumer outputConsumer);

    /// <summary>
    /// Sets the wait strategies to complete the Testcontainer asynchronous start task.
    /// </summary>
    /// <param name="waitStrategy">Wait strategy to complete the Testcontainer start, default wait strategy implementation is <see cref="UntilContainerIsRunning" />.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    /// <remarks>Multiple wait strategies are executed one after the other.</remarks>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithWaitStrategy(IWaitForContainerOS waitStrategy);

    /// <summary>
    /// Allows low level modifications of <see cref="CreateContainerParameters" /> after the builder configuration has been applied.
    /// Multiple modifiers will be executed in order of insertion.
    /// </summary>
    /// <param name="parameterModifier">The action that invokes modifying the <see cref="CreateContainerParameters" /> instance.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    /// <remarks>This exposes the underlying Docker.DotNet API, it might change. Scope is outside this project.</remarks>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithCreateContainerParametersModifier(Action<CreateContainerParameters> parameterModifier);

    /// <summary>
    /// Sets the startup callback to invoke after the Testcontainer start.
    /// </summary>
    /// <param name="startupCallback">The callback method to invoke.</param>
    /// <returns>A configured instance of <see cref="ITestcontainersBuilder{TDockerContainer}" />.</returns>
    /// <remarks>Is invoked once after the Testcontainer is started and before the wait strategies are executed.</remarks>
    [PublicAPI]
    ITestcontainersBuilder<TContainerEntity> WithStartupCallback(Func<IRunningDockerContainer, CancellationToken, Task> startupCallback);

    /// <summary>
    /// Builds the instance of <see cref="ITestcontainersContainer" /> with the given configuration.
    /// </summary>
    /// <returns>A configured instance of <see cref="ITestcontainersContainer" />.</returns>
    [PublicAPI]
    TContainerEntity Build();
  }
}
