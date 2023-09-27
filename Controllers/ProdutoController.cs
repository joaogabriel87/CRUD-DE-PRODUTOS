using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dev.Data;
using dev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dev.Controllers
{

    public class ProdutoController : Controller
    {

        readonly private ApplicationDbContext _db;
        public ProdutoController(ApplicationDbContext db) { _db = db; }

        public IActionResult Index()
        {
            IEnumerable<ProdutoModel> produtos = _db.Produto;
            return View(produtos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ProdutoModel produtos)
        {
            if (ModelState.IsValid)
            {
                _db.Produto.Add(produtos);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ProdutoModel produto = _db.Produto.FirstOrDefault(x => x.Id == id);

            if (id == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                _db.Produto.Update(produto);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(produto);
        }
        [HttpGet]
        public IActionResult Deletar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ProdutoModel produto = _db.Produto.FirstOrDefault(x => x.Id == id);

            if (id == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        public IActionResult Deletar(ProdutoModel produto)
        {
            if (produto == null)
            {
                return NotFound();
            }

            _db.Produto.Remove(produto);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}