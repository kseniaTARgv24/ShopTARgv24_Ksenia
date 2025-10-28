using Microsoft.AspNetCore.Mvc;
using ShopTARgv24_Ksenia.Core.ServiceInterface;


namespace ShopTARgv24_Ksenia.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ICocktailService _cocktailService;
        public CocktailsController(ICocktailService cocktailService)
        {
            _cocktailService = cocktailService;
        }

        // GET: /Cocktails
        public IActionResult Index()
        {
            return View(); // показывает форму поиска
        }

        // GET: /Cocktails/Search?name=margarita (имя коктейля)
        public async Task<IActionResult> Search(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return View("SearchResults", null); // почему вью
            }
            var result = await _cocktailService.SearchByNameAsync(name);
            return View("SearchResults", result); // передаем результат в представление
        }

        // GET: /Cocktails/Details/11007
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var drink = await _cocktailService.GetByIdAsync(id);
            if (drink == null) return NotFound();
            return View(drink); // передаем коктейль в представление
        }
    }
}

//IActionResult is an interface defined in the Microsoft.
//AspNetCore.Mvc namespace.It represents the result of an action method in a controller,
//abstracting the details of the HTTP response.
//This allows developers to focus on the application logic without worrying about
//the specifics of response generation.