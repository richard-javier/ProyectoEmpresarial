namespace ProyectoEmpresarial.Modelos.Compras
{
    public class SolicitudCompra
    {
        public int SolicitudCompraId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; } // Por ejemplo: "Pendiente", "Aprobada", "Rechazada"
        public string Descripcion { get; set; }

        public ICollection<OrdenCompra> OrdenesCompra { get; set; }
    }
}
