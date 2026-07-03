using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaMVC.Data;
using LojaMVC.Models;

namespace LojaMVC.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Vitrine(string buscaNome, string buscaCategoria)
        {
            var produtos = _context.Produtos.AsQueryable();
            if (!string.IsNullOrEmpty(buscaNome))
                produtos = produtos.Where(p => p.Nome.Contains(buscaNome));
            if (!string.IsNullOrEmpty(buscaCategoria))
                produtos = produtos.Where(p => p.Categoria.Contains(buscaCategoria));
            ViewData["BuscaNome"] = buscaNome;
            ViewData["BuscaCategoria"] = buscaCategoria;
            return View(await produtos.ToListAsync());
        }

        public async Task<IActionResult> Index(string buscaNome, string buscaCategoria)
        {
            var produtos = _context.Produtos.AsQueryable();
            if (!string.IsNullOrEmpty(buscaNome))
                produtos = produtos.Where(p => p.Nome.Contains(buscaNome));
            if (!string.IsNullOrEmpty(buscaCategoria))
                produtos = produtos.Where(p => p.Categoria.Contains(buscaCategoria));
            ViewData["BuscaNome"] = buscaNome;
            ViewData["BuscaCategoria"] = buscaCategoria;
            return View(await produtos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var produto = await _context.Produtos.FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco,Categoria,Estoque,ImagemUrl,DataCadastro")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco,Categoria,Estoque,ImagemUrl,DataCadastro")] Produto produto)
        {
            if (id != produto.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProdutoExists(produto.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var produto = await _context.Produtos.FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
                _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProdutoExists(int id)
        {
            return await _context.Produtos.AnyAsync(e => e.Id == id);
        }
    }
}