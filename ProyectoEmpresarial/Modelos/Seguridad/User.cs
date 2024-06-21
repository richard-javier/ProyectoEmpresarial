using System.Collections.Generic;
namespace ProyectoEmpresarial.Modelos.Seguridad
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } // Propiedad de navegación para UserRole
    }
}
