using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeechTherapyCenter.Controllers
{
    public class PostController : Controller
    {
        public PostService servicePost { get; set; }

        public PostController(PostService service)
        {
            servicePost = service;
        }

        // Shows all posts
        public async Task<IActionResult> Index()
        {
            return View(await servicePost.GetAll());
        }

        public async Task<IActionResult> GetPost()
        {
            List<PostViewModel> result = await servicePost.GetAll();
            return View("Index");
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost([Bind("Title, Body")] PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                await servicePost.AddPost(post);
                return RedirectToAction(nameof(Index));
            }
            return Redirect("~/Home/Index");
        }

        // Deleting post
        public async Task<IActionResult> DeletePost(string? id)
        {
            await servicePost.DeletePost(id);
            return Redirect("~/Home/Index");
        }
    }
}
