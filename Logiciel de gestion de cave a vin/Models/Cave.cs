using System;
using System.Collections.Generic;

namespace Logiciel_de_gestion_de_cave_a_vin.Models;

public partial class Cave
{
    public int IdCave { get; set; }

    public string NomCave { get; set; } = null!;

    public int NombreTiroir { get; set; }

    public int? BouteillesParTiroir { get; set; }

    public string Type { get; set; } = null!;

    public decimal Temperature { get; set; }

    public int IdFabricant { get; set; }

    public virtual ICollection<Bouteille> Bouteilles { get; } = new List<Bouteille>();

    public virtual Fabricant IdFabricantNavigation { get; set; } = null!;
}
