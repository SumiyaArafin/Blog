using Blog.Data;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }
        public void AddPost(Post post)
        {
            _db.Posts.Add(post);
           
        }



        public List<Post> GetPosts()
        {
            return _db.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return _db.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            _db.Posts.Remove(GetPost(id));
        }

       

        public void UpdatePost(Post post)
        {
            _db.Posts.Update(post);
        }
        public async Task<bool> SaveChangesAsync()
        {
            if(await _db.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
