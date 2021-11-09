using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestBookApp.Models;
using GuestBookApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuestBookApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        //GET: PostController
        public ActionResult Index()
        {
            return View(_postRepository.GetAllPosts());
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View(new Post());
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            _postRepository.Add(post);
            return RedirectToAction(nameof(Index));
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_postRepository.Get(id));
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post post)
        {
            _postRepository.Update(id, post);
            return RedirectToAction(nameof(Index));
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_postRepository.Get(id));
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Post post)
        {
            _postRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
