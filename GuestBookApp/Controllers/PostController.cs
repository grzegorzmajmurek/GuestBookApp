using System;
using System.Collections.Generic;
using System.Linq;
using GuestBookApp.Models;
using GuestBookApp.Repositories;
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
        public ActionResult Index(String sortOrder, int pg=1)
        {
            List<Post> posts = _postRepository.GetAllPosts().ToList();
            ViewData["Date"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            switch (sortOrder)
            {
                case "date_desc":
                    posts = posts.AsEnumerable().OrderBy(x => x.ReleaseDate).ToList();
                    break;
                default:
                    posts = posts.AsEnumerable().OrderByDescending(a => a.ReleaseDate).ToList();
                    break;
            }
            const int pageSize = 4;
            if (pg < 1)
                pg = 1;

            int recsCount = posts.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = posts.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
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
