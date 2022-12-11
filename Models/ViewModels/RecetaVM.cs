using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRecetas.Models.ViewModels
{
    public class RecetaVM
    {
        public Receta? oReceta { get; set; }
        public List<Ingrediente>? oIngrediente {get; set;}
    }

    
}