using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Frisia.Standard;


namespace R5T.Pictia.Frisia.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ISftpClientWrapperProvider"/> service.
        /// </summary>>
        public static IServiceCollection AddSftpClientWrapperProvider(this IServiceCollection services, string hostFriendlyName)
        {
            services.AddFrisiaSftpClientWrapperProvider(
                services.AddAwsEc2ServerSecretsProviderAction(hostFriendlyName));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISftpClientWrapperProvider"/> service.
        /// </summary>>
        public static ServiceAction<ISftpClientWrapperProvider> AddSftpClientWrapperProviderAction(this IServiceCollection services, string hostFriendlyName)
        {
            var serviceAction = new ServiceAction<ISftpClientWrapperProvider>(() => services.AddSftpClientWrapperProvider(hostFriendlyName));
            return serviceAction;
        }
    }
}
