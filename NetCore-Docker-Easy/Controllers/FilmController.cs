using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using NetCore_Docker_Easy.Models;
using NetCore_Docker_Easy.Services;

namespace NetCore_Docker_Easy.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Film flm)
        {
            if (ModelState.IsValid)
            {                
                await _filmService.Add(flm);
                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(Film flm)
        {
            if (ModelState.IsValid)
            {
                await _filmService.Update(flm);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(flm);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _filmService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var del = await _filmService.Get(id);
            return View(del);
        }
        public async Task<IActionResult> Index()
        {
            var flm = await _filmService.Get();
            return View(flm);
        }
    }
}