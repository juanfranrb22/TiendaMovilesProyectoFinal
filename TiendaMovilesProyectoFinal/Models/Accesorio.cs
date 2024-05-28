using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaMovilesProyectoFinal.Models
{
    public class Accesorio
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del accesorio es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(300)]
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un número positivo")]
        public decimal Precio { get; set; }

        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [Display(Name = "IdMarca")]
        public Marca Marca_id { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        [Display(Name = "Modelo")]
        public int ModeloId { get; set; }

        [Display(Name = "IdModelo")]
        public Modelo Modelo_id { get; set; }

        public int Stock { get; set; }
        public String ItemTyoe { get; set; }

        public ICollection<Valoracion> Valoraciones { get; set; }
    }

}