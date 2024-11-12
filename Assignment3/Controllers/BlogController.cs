using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    public class BlogController : Controller
    {
        private IDataEntityRepository<BlogPost> posts;

        public BlogController(IConfiguration configuration)
        {
            posts = new BlogDBRepository(configuration);
        }

        public IActionResult Index()
        {
            return View(posts.GetList());
        }
        public IActionResult Add() 
        { 
            return View(new BlogPostModel());
        }

        [HttpPost]
        public IActionResult Add(BlogPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            BlogPost post = new();
            post.Author = model.Author;
            post.ID = model.ID;
            post.Content = model.Content;
            post.Title = model.Title;
            posts.Save(post);

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var post = posts.Get(id);
            var model = new BlogPostModel()
            {
                Author = post.Author,
                ID = post.ID,
                Content = post.Content,
                Title = post.Title
            };
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(BlogPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            BlogPost post = new()
            {
                Author = model.Author,
                ID = model.ID,
                Content = model.Content,
                Title = model.Title
            };
            posts.Save(post);
            return RedirectToAction("Index");
        }
    }
}
