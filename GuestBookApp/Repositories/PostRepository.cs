using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestBookApp.Models;

namespace GuestBookApp.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostManagerContext _context;
        public PostRepository(PostManagerContext context)
        {
            _context = context;
        }
        public void Add(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public List <Post> GetAllPosts()
            => _context.Posts.ToList();

        public void Delete(int id)
        {
            var result = _context.Posts.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                _context.Posts.Remove(result);
                _context.SaveChanges();
            }
        }

        public Post Get(int Id)
            => _context.Posts.SingleOrDefault(x => x.Id == Id);

        public void Update(int id, Post post)
        {
            var result = _context.Posts.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Name = post.Name;
                result.Comment = post.Comment;
                _context.SaveChanges();
            }
        }
    }
}
