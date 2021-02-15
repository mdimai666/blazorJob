using BlazorJob.Data;
using BlazorJob.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJob.Services
{
    public class MetaService : StandartModelService<Meta>
    {
        public MetaService(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration,serviceProvider)
        {
        }
    }
}
