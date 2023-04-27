using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper automapperProfile;

        public StatisticService(IUnitOfWork unitOfWork, IMapper automapperProfile)
        {
            this.unitOfWork = unitOfWork;
            this.automapperProfile = automapperProfile;
        }

        public Task<IEnumerable<ProductModel>> GetCustomersMostPopularProductsAsync(int productCount, int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetIncomeOfCategoryInPeriod(int categoryId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductModel>> GetMostPopularProductsAsync(int productCount)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerActivityModel>> GetMostValuableCustomersAsync(int customerCount, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
