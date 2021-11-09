using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestBookApp.Models;

namespace GuestBookApp.Repositories
{
    public interface IPostRepository
    {
        Post Get(int Id);
        List <Post> GetAllPosts();
        void Add(Post post);
        void Update(int id, Post post);
        void Delete(int id);
    }
}
