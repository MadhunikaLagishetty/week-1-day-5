using Data_Access_Layer;
using Domain_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IAmazonRepository _amazonRepository;

        public OrderBusiness(IAmazonRepository amazonRepository)
        {
            _amazonRepository = amazonRepository;
        }

        public async Task<List<AmazonOrders>> GetAllOrders()
        {
            return await _amazonRepository.GetAllOrders();
        }

        public async Task<AmazonOrders> GetOrderById(int Id)
        {
            return await _amazonRepository.GetOrderById(Id);
        }

        public async Task InsertOrder(AmazonOrders amazonOrders)
        {
            await _amazonRepository.InsertOrder(amazonOrders);
            
        }

        public async Task UpdateOrder(AmazonOrders amazonOrders)
        {
            await _amazonRepository.UpdateOrder(amazonOrders);
        }

        public async Task DeleteOrderById(int Id)
        {
            await _amazonRepository.DeleteOrderById(Id);
        }
    }
}
