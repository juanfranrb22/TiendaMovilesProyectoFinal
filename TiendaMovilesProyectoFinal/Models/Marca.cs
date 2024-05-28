using System.ComponentModel.DataAnnotations;

namespace TiendaMovilesProyectoFinal.Models
{
    public class Marca
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Marca")]
        public string Nombre { get; set; }

    }

}