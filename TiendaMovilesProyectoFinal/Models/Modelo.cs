using System.ComponentModel.DataAnnotations;

namespace TiendaMovilesProyectoFinal.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Modelo")]
        public string Nombre { get; set; }

    }

}