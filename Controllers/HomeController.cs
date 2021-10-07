using Blog.Data;
using Blog.Data.Repository;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _data;

        
        public HomeController(IRepository data)
        {
            _data = data;
        }
        public IActionResult Index()
        {
            var posts = _data.GetPosts();
            return View(posts);
        }
       
        public IActionResult Post(int id)
        {
            var post = _data.GetPost(id);
            return View(post);
            
        }
       
    }
}
