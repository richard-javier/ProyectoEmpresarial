namespace ProyectoEmpresarial.Modelos.Inventario
{
    public class Inventario
    {
        public int InventarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
