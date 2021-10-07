using Blog.Data.Repository;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private readonly IRepository _data;

        public PanelController(IRepository data)
        {
            _data = data;
        }
        public IActionResult Index()
        {
            var posts = _data.GetPosts();
            return View(posts);
        }

       
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return View(new PostViewModel());
            else
            {
                var post = _data.GetPost((int)id);
                return View(new PostViewModel { 
                
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.Id > 0)
            {
                _data.UpdatePost(post);
            }
            else
            {
                _data.AddPost(post);
            }

            if (await _data.SaveChangesAsync())

                return RedirectToAction("Index");
            else
                return View(post);
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _data.RemovePost(id);
            await _data.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
