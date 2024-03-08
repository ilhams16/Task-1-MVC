using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using SampleMVC.Models;

namespace SampleMVC.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleBLL _articleBLL;
        private readonly ICategoryBLL _categoryBLL;

        public ArticlesController(IArticleBLL articleBLL, ICategoryBLL categoryBLL)
        {
            _articleBLL = articleBLL;
            _categoryBLL = categoryBLL;

        }
        // GET: ArticlesController
        public ActionResult Index(int? category)
        {
            IEnumerable<ArticleDTO> articles;
            if (category == 0 || category is null)
            {
                articles = _articleBLL.GetArticleWithCategory();

            }
            else
            {
                articles = _articleBLL.GetArticleByCategory((int)category);
            }
            var categories = _categoryBLL.GetAll();
            var viewModel = new ArticleViewModel
            {
                Articles = articles,
                Categories = categories
            };
            return View(viewModel);
        }

        // GET: ArticlesController/Details/5
        public ActionResult Details(int id)
        {
            var article = _articleBLL.GetArticleById(id);
            return View(article);
        }

        // GET: ArticlesController/Create

        // POST: /Articles/FilterByCategory
        public IActionResult FilterByCategory(int category)
        {
            return RedirectToAction("Index", new { category = category });
        }
        public ActionResult Create()
        {
            var categories = _categoryBLL.GetAll();
            return View(categories);
        }

        // POST: ArticlesController/Create
        [HttpPost]
        public ActionResult Create(ArticleCreateDTO newArticle)
        {
            try
            {
                _articleBLL.Insert(newArticle);
                //ViewData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
                // return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                // return View();
            }
            return RedirectToAction("Index");
        }

        // GET: ArticlesController/Edit/5
        // public ActionResult Edit(int id, ArticleUpdateDTO updateArticle)
        // {
		// 	updateArticle.ArticleID = id;
		// 	_articleBLL.Update(updateArticle);
        //     return RedirectToAction("Index");
        // }

        // POST: ArticlesController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,ArticleUpdateDTO updateArticle)
        {
			updateArticle.ArticleID = id;
			_articleBLL.Update(updateArticle);
            return RedirectToAction("Index");
        }

        // GET: ArticlesController/Delete/5
        public ActionResult Delete(int id)
        {
            _articleBLL.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: ArticlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
