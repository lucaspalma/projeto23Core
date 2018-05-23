using System;
using System.ComponentModel.DataAnnotations;

namespace blog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Título")]
        public string Titulo { get; set; }

        [Required]
        public string Resumo { get; set; }

        public string Categoria { get; set; }

	    [Display(Name="Data de publicação")]
        public DateTime? DataPublicacao { get; set; }
        
        public bool Publicado { get; set; }

    }
}