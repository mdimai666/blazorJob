using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using BlazorJob.Data;
using BlazorJob.Models;
using BlazorJob.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorJob.Controllers
{

    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        ApplicationDbContext _dataContext;
        PostService _postService;

        public PostController(ApplicationDbContext dataContext, PostService postService)
        {
            _dataContext = dataContext;
            _postService = postService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get(int page = 1, int perpage = 10)
        {
            return await _dataContext.Posts
                .OrderByDescending(s => s.Id)
                .Skip((page - 1) * perpage)
                .Take(perpage).ToListAsync();
        }

        [HttpGet("List")]
        public async Task<ActionResult<QPagedList<Post>>> GetList(int page = 1, int perpage = 10, bool? m_spam = null, bool? m_link = null, bool? deleted = false, bool dt_actual = false)
        {
            //return _postService

            //return await _dataContext.Jobs.OrderByDescending(s => s.Id).Skip(page * perpage).Take(perpage).ToListAsync();

            DateTime dt_lastActual = DateTime.Now - TimeSpan.FromDays(2);

            IQueryable<Post> query = _dataContext.Posts
                //.Where(s =>
                //(deleted == null || deleted == s.Deleted) &&
                //    (m_link == null || m_link == s.m_link) &&
                //    (m_spam == null || m_spam == s.m_spam) &&
                //    (dt_actual == false || s.dt_insert > dt_lastActual)
                //)
                //.Where(s => s.Id > 0)
                .AsQueryable(); // Add Where Filters Here.


            List<Post> list = await query
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * perpage)
                .Take(perpage).ToListAsync();

            //Console.WriteLine($"posts={list.Count}");

            int totalCount = await query.CountAsync();

            //await Task.WhenAll(list, totalCount);


            return new QPagedList<Post>()
            {
                totalCount = totalCount,
                data = list,
                page = page,
                perpage = perpage,
            };
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(Guid id)
        {
            //JobItem item = await _dataContext.Jobs.FindAsync(id);
            Post item = await _dataContext.Posts.FirstAsync<Post>(s => s.Id == id);

            if (item == null) return NotFound();

            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Post>> Post([FromBody] Post value)
        {
            //value.Id = 0;
            EntityEntry<Post> jobItem = await _dataContext.AddAsync<Post>(value);
            int id = await _dataContext.SaveChangesAsync();

            return jobItem.Entity;

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Post value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            _dataContext.Entry(value).State = EntityState.Modified;

            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _dataContext.FindAsync<Post>(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            Post post = await _dataContext.Posts.FirstAsync<Post>(s => s.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            _dataContext.Posts.Remove(post);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        // PATCH api/<controller>/
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<Post> patch)
        {
            if (patch != null)
            {
                //if (id < 0) return BadRequest();

                Post post = await _dataContext.Posts.FirstAsync<Post>(s => s.Id == id);

                //https://stackoverflow.com/questions/36767759/using-net-core-web-api-with-jsonpatchdocument
                patch.ApplyTo(post, ModelState);
                /*
                 * Without ths not work 
                 * ConfigureServices
                 * services.AddControllers()
                    .AddNewtonsoftJson();//json patch
                 */

                await _dataContext.SaveChangesAsync();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return new ObjectResult(post);

            }

            else
            {
                return BadRequest(ModelState);
            }


        }

        /// <summary>
        /// XML comments is support on swagger
        /// </summary>
        /// <returns></returns>
        //[Route("[Action]")]
        [HttpGet("List22")]
        public async Task<ActionResult<IEnumerable<Post>>> List()
        {

            List<Post> list = await _dataContext.Posts.Take(10).ToListAsync();

            //list.ForEach(s => s.Id = 0);

            return list;
        }


        //[HttpGet("{id}.{format?}")]


        //[FromBody] Текст запроса
        //[FromForm]  Данные формы в тексте запроса
        //[FromHeader] Заголовок запроса
        //[FromQuery] Параметры строки запроса для запроса
        //[FromRoute] Данные маршрута из текущего запроса
        //[FromServices] Служба запросов, внедренная в качестве параметра действия
    }
}