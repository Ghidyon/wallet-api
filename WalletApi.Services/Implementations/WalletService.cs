using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApi.Data.Interfaces;
using WalletApi.Models.Entities;
using WalletApi.Services.Interfaces;

namespace WalletApi.Services.Implementations
{
    public class WalletService : IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceFactory _serviceFactory;
        private readonly IRepository<Wallet> _walletRepo;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        public WalletService(IUnitOfWork unitOfWork,
            IServiceFactory serviceFactory,
            IMapper mapper,
            ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _serviceFactory = serviceFactory;
            _walletRepo = _unitOfWork.GetRepository<Wallet>();
            _mapper = mapper;
            _loggerService = loggerService;
        }

        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            return await _walletRepo.AddAsync(wallet);
        }
    }
}
