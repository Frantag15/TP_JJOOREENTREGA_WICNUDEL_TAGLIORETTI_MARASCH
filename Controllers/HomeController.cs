using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_JJOOREENTREGA_WICNUDEL_TAGLIORETTI_MARASCH.Models;

namespace TP_JJOOREENTREGA_WICNUDEL_TAGLIORETTI_MARASCH.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Deportes()
    {
        ViewBag.Deportes = BD.ListarDeportes();
        return View();
    }

    public IActionResult Paises()
    {
        ViewBag.Paises = BD.ListarPaises();
        return View();
    }

    public IActionResult VerDetalleDeporte(int idDeporte)
    {
        ViewBag.Deporte = BD.VerInfoDeporte(idDeporte);
        ViewBag.Deportistas = BD.ListarDeportistasPorDeporte(idDeporte);
        return View();
    }

    public IActionResult VerDetallePais(int idPais)
    {
        ViewBag.Pais = BD.VerInfoPais(idPais);
        ViewBag.Deportistas = BD.ListarDeportistasPorPais(idPais);
        return View();
    }

    public IActionResult VerDetalleDeportista(int idDeportista)
    {
        ViewBag.Deportista = BD.VerInfoDeportista(idDeportista);
        return View();
    }

    public IActionResult AgregarDeportista()
    {
        ViewBag.Paises = BD.ListarPaises();
        ViewBag.Deportes = BD.ListarDeportes();
        return View();
    }

    [HttpPost]
    public IActionResult GuardarDeportista(Deportistas dep)
    {
        BD.AgregarDeportista(dep);
        return View("Index");
    }

    public IActionResult EliminarDeportista(int idDeportista)
    {
        BD.EliminarDeportista(idDeportista);
        return View("Index");
    }

    public IActionResult Creditos()
    {
        return View();
    }
}
