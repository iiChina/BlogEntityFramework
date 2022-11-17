using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEntityFramework.Models
{
    // [Table("Post")]
    public class Post
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /* 
            O EF usa dessa anotação para identificar que essa prop faz referencia a uma prop 
            de outro objeto: CategoryId: Category = Classe; Id = Propriedade
        */
        // [ForeignKey("CategoryId")] 
        public int CategoryId { get; set; }

        /*
            Fazendo nesse formato o EF é inteligente o suficiente pra entender que essa
            é uma propriedade de navegação para os casos que vc quiser carregar uma
            categoria dentro de post ao invés de só o id da categoria
        */
        public Category Category { get; set; } 

        // [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public User Author { get; set; }

        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public IList<Tag> Tags { get; set; }
    }
}