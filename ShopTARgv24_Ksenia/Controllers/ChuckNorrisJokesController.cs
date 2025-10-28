using Microsoft.AspNetCore.Mvc;
using ShopTARgv24_Ksenia.Core.ServiceInterface;

namespace ShopTARgv24_Ksenia.Controllers
{
    public class ChuckNorrisJokesController : Controller
    {
        private readonly IChuckNorrisJokesServices _chuckNorrisJokesServices;

        public ChuckNorrisJokesController (IChuckNorrisJokesServices chuckNorrisJokesServices)
        {
            _chuckNorrisJokesServices = chuckNorrisJokesServices;
        }


        //GET : /ChuckNorrisJokes/Random
        public async Task<IActionResult> Index()
        {
            if (_chuckNorrisJokesServices == null)
                return NotFound();

            var joke = await _chuckNorrisJokesServices.GetRandomJokeAsync();
            return View(joke); // передаём модель сразу
        }


    }
}
