using System;
using System.Collections.Generic;

namespace GestionRecetas.Models;

public partial class Ingrediente
{
    public int IdIngrediente { get; set; }

    public int? IdRecetas { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public string? Unidad { get; set; }

    public int? Cantidad { get; set; }

    public string? Tipo { get; set; }

    public decimal? Precio { get; set; }

    public virtual Receta? IdRecetasNavigation { get; set; }
}
