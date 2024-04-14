using System.ComponentModel.DataAnnotations;

namespace RedeSocialAT.Models {
    public class Comentario {

        [Key]
        public int CommentId { get; set; }

        public int PostId { get; set; }
        public virtual Post? Post { get; set; }

        public string Comment { get; set; }
    }
}
