using Tienda;

public class PresupuestosDetalle
{
   private Productos? producto;
   private int cantidad;

    public PresupuestosDetalle()
    {
    }

    public Productos? Producto { get => producto; set => producto=value;}
    public int Cantidad { get => cantidad; set => cantidad = value; }

    public void CargarProducto( Productos prod)
    {
        producto = prod;
    }
}