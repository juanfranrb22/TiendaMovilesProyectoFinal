using System.ComponentModel.DataAnnotations;

namespace TiendaMovilesProyectoFinal.Models
{
    public class Valoracion
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Valoración")]
        public string Comentario { get; set; }
        public int Puntuacion { get; set; }

        public int DispositivoId { get; set; }
        public Dispositivo Dispositivo { get; set; }
    }

}