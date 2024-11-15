using Tienda;
public class Presupuestos
{
    private int idPresupuesto;
    private string? nombreDestinatario;
    private string? fechaCreacion;
    private List<PresupuestosDetalle> detalle;
    public const double IVA = 0.21;

    public Presupuestos()
    {
        detalle = new List<PresupuestosDetalle>();
    }

    public string? NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public int IdPresupuesto { set => idPresupuesto = value; }
    public List<PresupuestosDetalle> Detalle { get => detalle; }
    public string? FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }

    public int MontoPresupuesto(){
        return detalle.Sum(p => p.Producto.Precio * p.Cantidad);
    }
    public double MontoPresupuestoConIva(){
        return detalle.Sum(p => p.Producto.Precio*(1 + IVA) * p.Cantidad);
    }
    public int CantidadProductos(){
        return detalle.Sum(p => p.Cantidad);
    }
    
}
