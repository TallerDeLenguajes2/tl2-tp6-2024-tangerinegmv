using SQLitePCL;
using Tienda;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tl2_tp6_2024_tangerinegmv.Controllers;

[ApiController]
[Route("[controller]")]


public class ProductosController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ProductosRepository prodRep = new ProductosRepository();

     public ProductosController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<Productos>> Index()
    {
        return View(prodRep.ListarProductos());
    }

    // [HttpGet]
    // public IActionResult CrearProducto()
    // {
    //     return View();
    // }

    // [HttpPost]
    // public IActionResult CrearProducto(Productos producto)
    // {
    //     prodRep.CrearNuevo(producto);
    //     return RedirectToAction("Index");
    // }
}
