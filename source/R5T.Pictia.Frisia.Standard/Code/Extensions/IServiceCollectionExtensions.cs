using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Frisia.Standard;
using R5T.Frisia.Suebia;


namespace R5T.Pictia.Frisia.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ISftpClientWrapperProvider"/> service.
        /// </summary>>
        public static IServiceCollection AddSftpClientWrapperProvider(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            services.AddFrisiaSftpClientWrapperProvider(
                services.AddAwsEc2ServerSecretsProviderAction(addAwsEc2ServerHostFriendlyNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISftpClientWrapperProvider"/> service.
        /// </summary>>
        public static IServiceAction<ISftpClientWrapperProvider> AddSftpClientWrapperProviderAction(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            var serviceAction = new ServiceAction<ISftpClientWrapperProvider>(() => services.AddSftpClientWrapperProvider(addAwsEc2ServerHostFriendlyNameProvider));
            return serviceAction;
        }
    }
}
