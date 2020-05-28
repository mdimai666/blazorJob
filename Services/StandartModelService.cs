//#define POST_OLD


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlazorJob.Data;
using BlazorJob.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorJob.Services
{

    public class StandartModelService<TEntity> : BasicModelService<TEntity> where TEntity : class, IBasicEntity
    {
        public StandartModelService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }

}