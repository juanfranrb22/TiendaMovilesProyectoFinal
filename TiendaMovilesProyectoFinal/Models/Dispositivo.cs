using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TiendaMovilesProyectoFinal.Models
{
    public class Dispositivo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(300)]
        public string Descripcion { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un número positivo")]
        public decimal Precio { get; set; }

        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una marca")]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un modelo")]
        [Display(Name = "Modelo")]
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un sistema operativo")]
        [Display(Name = "Sistema Operativo")]
        public int SistemaOperativoId { get; set; }
        public SistemaOperativo SistemaOperativo { get; set; }
        public int Stock { get; set; }
        public String ItemType { get; set; } = "Dispositivo";
        public ICollection<Valoracion> Valoraciones { get; set; }
        public HttpPostedFileBase ImagenArchivo { get; set; }
    }

}