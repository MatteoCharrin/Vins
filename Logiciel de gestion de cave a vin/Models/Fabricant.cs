using System;
using System.Collections.Generic;

namespace Logiciel_de_gestion_de_cave_a_vin.Models;

public partial class Fabricant
{
    public int IdFabricant { get; set; }

    public string NomFabricant { get; set; } = null!;

    public bool TypeFabricant { get; set; }

    public virtual ICollection<Cave> Caves { get; } = new List<Cave>();
}
