//#define POST_OLD


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorJob.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;



namespace BlazorJob.Services
{
    using BlazorJob.Models;
    using Microsoft.Extensions.Configuration;



#if POST_OLD
    public class PostService : PostServiceOld
    {
        public PostService(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    } 
#endif

#if !POST_OLD
    public class PostService : StandartModelService<Post>
    {
        public PostService(ApplicationDbContext dbContext, IConfiguration configuration) : base(dbContext, configuration)
        {
        }
    }
#endif

    public class PostServiceOld
    {
        ApplicationDbContext ef;

        public PostServiceOld(ApplicationDbContext dataContext/*, HttpClient client*/)
        {
            ef = dataContext;
        }

        async public Task<List<Post>> ListAsync()
        {
            // return Enumerable.Range(0, 25).Select(s =>
            // {
            //     return new Post() { Id = s, Title = $"Title {s}", Text = $"Text {s}", CreatedDate = DateTime.Now };
            // }).ToList();

            return await ef.Posts.ToListAsync();
        }

        async public Task<Post> GetAsync(int id)
        {
            return await ef.Posts.FirstOrDefaultAsync(s => s.Id == id);
        }

        async public Task<Post> GetAsync(long id)
        {
            return await ef.Posts.FirstOrDefaultAsync(s => s.Id == id);
        }

        async public Task<Post> AddAsync(Post post)
        {

            EntityEntry<Post> result = await ef.Posts.AddAsync(post);
            int id = await result.Context.SaveChangesAsync();

            Debug.WriteLine($"add post {id}");

            return result.Entity;
        }

        async public Task<Post> UpdateAsync(Post post)
        {
            Post ePost = await GetAsync(post.Id);

            if (ePost != null)
            {

                ePost.Title = post.Title;
                ePost.Content = post.Content;
                ePost.Author = post.Author;
                ePost.Type = post.Type;
                ePost.Parent = post.Parent;
                ePost.Status = post.Status;
                ePost.Modified = DateTime.Now;

                var result = ef.Posts.Update(ePost);

                int id = await result.Context.SaveChangesAsync();

                return result.Entity;
            }
            else
            {
                return null;
            }
        }

        void Test()
        {
            // ef.Model.
        }
    }


}

