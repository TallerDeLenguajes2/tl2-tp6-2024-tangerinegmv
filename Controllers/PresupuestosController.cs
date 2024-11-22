using SQLitePCL;
using Tienda;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tl2_tp6_2024_tangerinegmv.Controllers;

public class PresupuestosController : Controller
{
     private readonly ILogger<HomeController> _logger;
    private PresupuestosRepository presRep = new PresupuestosRepository();

     public PresupuestosController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

     public IActionResult Index()
    {
        return View(presRep.ListarPresupuestos());
    }
}
