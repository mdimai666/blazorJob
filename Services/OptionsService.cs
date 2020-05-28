using BlazorJob.Data;
using BlazorJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJob.Services
{
    public class OptionsService : StandartModelService<OptionEntity>
    {
        public OptionsService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
