using System;
using Microsoft.Extensions.Configuration.DockerSecrets;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Extension methods for registering <see cref="DockerSecretsConfigurationProvider"/> with <see cref="IConfigurationBuilder"/>.
    /// </summary>
    public static class DockerSecretsConfigurationBuilderExtensions
    {
        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from docker secrets.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddDockerSecrets(this IConfigurationBuilder builder) =>
            builder.AddDockerSecrets(configureSource: null);

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from docker secrets.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="secretsPath">The path to the secrets directory.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddDockerSecrets(this IConfigurationBuilder builder, string secretsPath) 
            => builder.AddDockerSecrets(source => source.SecretsDirectory = secretsPath);

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from docker secrets.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="configureSource">Configures the source secrets.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddDockerSecrets(this IConfigurationBuilder builder, Action<DockerSecretsConfigurationSource> configureSource)
        {
            var source = new DockerSecretsConfigurationSource();
            configureSource?.Invoke(source);
            return builder.Add(source);
        }
    }
}
