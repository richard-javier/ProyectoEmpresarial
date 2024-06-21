using System.Collections.Generic;
namespace ProyectoEmpresarial.Modelos.Seguridad
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } // Propiedad de navegación para Users
        public ICollection<UserRole> UserRoles { get; set; } // Propiedad de navegación para UserRoles
    }
}
