using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kiga.domain.Entities{
    public class UsuarioDomain{

        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(250)]
        public string NomeUsuario { get; set; }
        [Required]
        public string FaceUsuario { get; set; }
    }
}