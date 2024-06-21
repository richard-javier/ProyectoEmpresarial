namespace ProyectoEmpresarial.Modelos.Ventas
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Cliente { get; set; } // Nombre del cliente o referencia

        public ICollection<DetalleFactura> Detalles { get; set; }
    }
}
