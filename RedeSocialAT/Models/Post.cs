

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedeSocialAT.Models {
    public class Post {
        
        public int PostId { get; set; }
        [Column("PerfilId")]
        [Display(Name = "Id da conta")]
        public int PerfilId { get; set; }
        public DateTime DataPost { get; set; }
        public string Texto { get; set; }
        public string? ImagemPost { get; set; }
        public virtual Perfil? Perfil { get; set; }
        public virtual ICollection<Perfil>? Perfis { get; set; }
    }
}
