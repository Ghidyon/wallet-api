using System;
using WalletApi.Services.Interfaces;

namespace WalletApi.Services.Implementations
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>() where T : class
        {
            var service = _serviceProvider.GetService(typeof(T));
            return (T)service;
        }
    }
}
