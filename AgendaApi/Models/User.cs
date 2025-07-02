using Microsoft.AspNetCore.Identity;

namespace AgendaApi.Models
{
    public class User : IdentityUser
    {
        public string NomeCompleto { get; set; }
        public string TipoUsuario { get; set; }
        public string Cpf { get; set; }
        public string? Especialidade { get; set; }
        public string? Endereco { get; set; }
        public bool? Aprovado { get; set; }

    }
}
