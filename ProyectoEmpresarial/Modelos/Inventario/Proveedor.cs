namespace ProyectoEmpresarial.Modelos.Inventario
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }

        public ICollection<Inventario> Inventarios { get; set; }
    }
}
