using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Data;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper automapperProfile;

        public CustomerService(IUnitOfWork unitOfWork, IMapper automapperProfile)
        {
            this.unitOfWork = unitOfWork;
            this.automapperProfile = automapperProfile;            
        }

        public Task AddAsync(CustomerModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            var customers = await unitOfWork.CustomerRepository.GetAllAsync();
            var customerModels = automapperProfile.Map<IEnumerable<CustomerModel>>(customers);
            return customerModels;
        }

        public Task<CustomerModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerModel>> GetCustomersByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomerModel model)
        {
            throw new NotImplementedException();
        }
    }
}
