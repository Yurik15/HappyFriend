using HF.Domain.Models;
using HF.Infrastracture.DataAccess;
using HFS.Infrastracture.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace HF.Infrastructure.Repositories
{
    public class OrdersRepository : BaseRepository<Order>
    {
        public OrdersRepository(HfDbContext dbContext) : base(dbContext)
        {
        }
    }
}
