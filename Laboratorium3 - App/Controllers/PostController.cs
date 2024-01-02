using Microsoft.AspNetCore.Mvc;
using Laboratorium3___App.Models;
namespace Laboratorium3___App.Controllers
{
    public class PostController : Controller
    {
        static Dictionary<int, Post> _posts = new Dictionary<int, Post>();
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_posts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                int id = _posts.Keys.Count != 0 ? _posts.Keys.Max() : 0;
                model.Id = id + 1;
                _posts.Add(model.Id, model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_posts.ContainsKey(id))
            {
                return View(_posts[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_posts.ContainsKey(id))
            {
                _posts.Remove(id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Details(int id)
        {
            if (_posts.ContainsKey(id))
            {
                return View(_posts[id]);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_posts.ContainsKey(id))
            {
                return View(_posts[id]);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_posts.ContainsKey(id))
                {
                    _posts[id] = post;
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(post);
        }

    }
}
