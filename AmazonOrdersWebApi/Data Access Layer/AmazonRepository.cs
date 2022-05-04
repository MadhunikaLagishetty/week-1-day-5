using Data_Access_Layer.Models;
using Domain_Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class AmazonRepository : IAmazonRepository
    {
        public async Task<List<AmazonOrders>> GetAllOrders()
        {

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var amazonOrders = await dbContext.Orders.ToListAsync();

                List<AmazonOrders> domainModels = new List<AmazonOrders>();
                foreach (var ord in amazonOrders)
                {
                    domainModels.Add(new AmazonOrders
                    {
                        Id = ord.Id,
                        UserName = ord.UserName,
                        Cost = (int)ord.Cost,
                        ItemQty = ord.ItemQty,
                        CreatedDate = ord.CreatedDate,
                        UpdatedDate = ord.UpdatedDate,
                        AmazonId = ord.AmazonId
                    });
                }
                return domainModels;
            }
        }

        public async Task InsertOrder(AmazonOrders amazonOrders)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Order
                {
                    UserName = amazonOrders.UserName,
                    Cost = amazonOrders.Cost,
                    ItemQty = amazonOrders.ItemQty,
                    CreatedDate = amazonOrders.CreatedDate,
                    UpdatedDate = amazonOrders.UpdatedDate,
                    AmazonId = amazonOrders.AmazonId
                };

                dbContext.Orders.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateOrder(AmazonOrders amazonOrders)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == amazonOrders.Id);

                findOrder.UserName = amazonOrders.UserName;
                findOrder.Cost = amazonOrders.Cost;
                findOrder.ItemQty = amazonOrders.ItemQty;

                dbContext.Orders.Update(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderById(int Id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
                dbContext.Orders.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<AmazonOrders> GetOrderById(int id)
        {
            // return TempData.Data.Find(x => x.Id == id);
            // return TempData.Data.FirstOrDefault(x => x.Id == id);

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var amazonOrders = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

                AmazonOrders domainModel = new AmazonOrders
                {
                    AmazonId = amazonOrders.AmazonId,
                    UserName = amazonOrders.UserName,
                    Cost = (int)amazonOrders.Cost,
                    ItemQty = amazonOrders.ItemQty,
                    CreatedDate = amazonOrders.CreatedDate,
                    UpdatedDate = amazonOrders.UpdatedDate,

                };

                return domainModel;
            }
        }

    }
}


