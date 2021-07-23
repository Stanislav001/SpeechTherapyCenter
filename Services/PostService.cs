using Date;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PostService
    {
        private readonly SpeechCenterDbContext context;
        public PostService(SpeechCenterDbContext post)
        {
            context = post;
        }

        // Show all posts
        public async Task<List<PostViewModel>> GetAll()
        {
            return await context.Posts.Select(x => new PostViewModel()
            {
                Title = x.Title,
                Body = x.Body
            }).ToListAsync();
        }

        // Add a new post
        public async Task AddPost(PostViewModel post)
        {
            var postDb = new Post();
            postDb.Id = Guid.NewGuid().ToString();
            postDb.Title = post.Title;
            postDb.Body = post.Body;

            if (post.Title != null)
            {
                context.Add(postDb);
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Eror!");
            }
        }

        // Delete post
        public async Task DeletePost(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Eror!");
            }
            if (id != null)
            {
                var postDb = context.Posts.FirstOrDefault(x => x.Id == id);
                context.Posts.Remove(postDb);
                await context.SaveChangesAsync();
            }
        }
    }
}
