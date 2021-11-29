using HF.Domain.Models;
using HF.Infrastracture.DataAccess;
using HFS.Infrastracture.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace HF.Infrastructure.Domain
{
    public class ExampleRepository : BaseRepository<Example>, IExampleRepository
    {
        public ExampleRepository(HfDbContext dbContext) : base(dbContext)
        {
        }
    }
}
