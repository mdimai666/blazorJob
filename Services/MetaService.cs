using BlazorJob.Data;
using BlazorJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJob.Services
{
    public class MetaService : StandartModelService<Meta>
    {
        public MetaService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
