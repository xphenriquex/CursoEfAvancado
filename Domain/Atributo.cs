using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEfAvancado.Domain
{
    [Table("TabelaAtributos")]
    public class Atributo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("MinhaDescricao", TypeName = "VARCHAR(100)")]
        public string Descricao { get; set; } 

        //[Required]
        [MaxLength(255)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Observacao { get; set; } 
    }

    public class Aeroporto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [NotMapped]
        public string PropriedadeTeste { get; set; }
        
        [InverseProperty("AeroportoPartida")]
        public ICollection<Voo> VoosDePartida { get; set; }

        [InverseProperty("AeroportoChegada")]
        public ICollection<Voo> VoosDeChegada { get; set; }
    }
    
    [NotMapped]
    public class Voo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Aeroporto AeroportoPartida { get; set; }
        public Aeroporto AeroportoChegada { get; set; }
    }
}