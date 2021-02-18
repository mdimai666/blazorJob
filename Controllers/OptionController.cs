using BlazorJob.Data;
using BlazorJob.Models;
using BlazorJob.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace BlazorJob.Controllers
{

    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class OptionController : StandartController<OptionsService, Option>
    {
        public OptionController(ApplicationDbContext dataContext, IServiceProvider serviceProvider) : base(dataContext, serviceProvider)
        {

        }

        [HttpGet("/someapi/path1/path2")]
        public async Task<ActionResult<List<Option>>> SomeApi()
        {
            var list = await modelService.List();

            List<Option> list2 = new List<Option>();

            list2.Add(list.First());
            list2.Add(list.First());
            list2.Add(list.First());

            return list2;

        }
    }
}
