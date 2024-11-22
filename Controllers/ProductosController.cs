using SQLitePCL;
using Tienda;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tl2_tp6_2024_tangerinegmv.Controllers;





public class ProductosController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ProductosRepository prodRep = new ProductosRepository();

     public ProductosController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        return View(prodRep.ListarProductos());
    }

    [HttpGet]
    public IActionResult CrearProducto()
    {
        return View(new Productos());
    }

    [HttpPost]
    public IActionResult CrearProducto(Productos producto)
    {
        prodRep.CrearNuevo(producto);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult ModificarProducto(int id)
    {
        return View(prodRep.DetallesProducto(id));
    }
    [HttpPost]
    public ActionResult ModificarProducto(int id, Productos prod)
    {
      prodRep.ModificarProducto(id, prod);
      return RedirectToAction("Index");
    }
}
