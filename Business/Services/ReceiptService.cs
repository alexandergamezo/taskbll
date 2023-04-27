using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper automapperProfile;

        public ReceiptService(IUnitOfWork unitOfWork, IMapper automapperProfile)
        {
            this.unitOfWork = unitOfWork;
            this.automapperProfile = automapperProfile;
        }

        public async Task AddAsync(ReceiptModel model)
        {            
            var receipt = automapperProfile.Map<Receipt>(model);
            await unitOfWork.ReceiptRepository.AddAsync(receipt);
            await unitOfWork.SaveAsync();
        }

        public async Task AddProductAsync(int productId, int receiptId, int quantity)
        {
            var receiptDetailModel = new ReceiptDetailModel
            {
                ProductId = productId,
                ReceiptId = receiptId,
                Quantity = quantity
            };

            var receiptDetail = automapperProfile.Map<ReceiptDetail>(receiptDetailModel);
            await unitOfWork.ReceiptDetailRepository.AddAsync(receiptDetail);
            await unitOfWork.SaveAsync();
        }

        public Task CheckOutAsync(int receiptId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int modelId)
        {
            var receipt = await unitOfWork.ReceiptRepository.GetByIdAsync(modelId);
            if (receipt == null)
            {
                throw new ArgumentException("Receipt not found");
            }

            foreach (var detail in receipt.ReceiptDetails.ToList())
            {
                await unitOfWork.ReceiptDetailRepository.DeleteByIdAsync(detail.Id);
            }

            await unitOfWork.ReceiptRepository.DeleteByIdAsync(modelId);
            await unitOfWork.SaveAsync();


            //await unitOfWork.ReceiptRepository.DeleteByIdAsync(modelId);
            //await unitOfWork.ReceiptDetailRepository.DeleteByIdAsync(modelId);
            //await unitOfWork.SaveAsync();

            //await unitOfWork.ReceiptDetailRepository.DeleteByIdAsync(modelId);
            //await unitOfWork.ReceiptRepository.DeleteByIdAsync(modelId);
            //await unitOfWork.SaveAsync();

            //await unitOfWork.ReceiptDetailRepository.DeleteByIdAsync(modelId);
            //await unitOfWork.ReceiptRepository.DeleteByIdAsync(modelId);            
            //await unitOfWork.SaveAsync();


            //var receipt = await unitOfWork.ReceiptRepository.GetByIdAsync(modelId);
            //unitOfWork.ReceiptRepository.Delete(receipt);
            //await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ReceiptModel>> GetAllAsync()
        {
            var receipt = await unitOfWork.ReceiptRepository.GetAllAsync();
            var receiptModels = automapperProfile.Map<IEnumerable<ReceiptModel>>(receipt);
            return receiptModels;
        }

        public async Task<ReceiptModel> GetByIdAsync(int id)
        {
            var receipt = await unitOfWork.ReceiptRepository.GetByIdWithDetailsAsync(id);
            var receiptModel = automapperProfile.Map<ReceiptModel>(receipt);
            return receiptModel;           
        }

        public async Task<IEnumerable<ReceiptDetailModel>> GetReceiptDetailsAsync(int receiptId)
        {
            var receiptDetails = await unitOfWork.ReceiptDetailRepository.GetAllWithDetailsAsync();
            var receiptDetailModels = automapperProfile.Map<IEnumerable<ReceiptDetailModel>>(receiptDetails.Where(x => x.ReceiptId == receiptId));
            return receiptDetailModels;
        }

        public async Task<IEnumerable<ReceiptModel>> GetReceiptsByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            var receipts = await unitOfWork.ReceiptRepository.GetAllWithDetailsAsync();
            var receiptModels = automapperProfile.Map<IEnumerable<ReceiptModel>>(receipts.Where(x => x.OperationDate >= startDate && x.OperationDate <= endDate));
            return receiptModels;
        }

        public async Task RemoveProductAsync(int productId, int receiptId, int quantity)
        {
            var receiptDetailModel = new ReceiptDetailModel
            {
                ProductId = productId,
                ReceiptId = receiptId,
                Quantity = quantity
            };

            var receiptDetail = automapperProfile.Map<ReceiptDetail>(receiptDetailModel);
            unitOfWork.ReceiptDetailRepository.Delete(receiptDetail);
            await unitOfWork.SaveAsync();
        }

        public Task<decimal> ToPayAsync(int receiptId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ReceiptModel model)
        {
            var receipt = automapperProfile.Map<Receipt>(model);
            unitOfWork.ReceiptRepository.Update(receipt);
            await unitOfWork.SaveAsync();
        }
    }
}
