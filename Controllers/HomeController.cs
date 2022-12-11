using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GestionRecetas.Models;
using GestionRecetas.Models.ViewModels;

namespace GestionRecetas.Controllers;

public class HomeController : Controller
{
    private readonly BdrecetasContext _dbContext;

    public HomeController(BdrecetasContext context)
    {
        _dbContext = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index([FromBody] RecetaVM oRecetaVM )
    {
        Receta oReceta = oRecetaVM.oReceta;
        oReceta.Ingredientes = oRecetaVM.oIngrediente;

        _dbContext.Recetas.Add(oReceta);
        _dbContext.SaveChanges();
        return Json(new{respuesta = true});
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
