namespace ProyectoEmpresarial.Modelos.Compras
{
    public class OrdenCompra
    {
        public int OrdenCompraId { get; set; }
        public DateTime FechaOrden { get; set; }
        public string Estado { get; set; } // Por ejemplo: "Pendiente", "Completada", "Cancelada"
        public decimal Total { get; set; }

        public int SolicitudCompraId { get; set; }
        public SolicitudCompra SolicitudCompra { get; set; }
    }
}
