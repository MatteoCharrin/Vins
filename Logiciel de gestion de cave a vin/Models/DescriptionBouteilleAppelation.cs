using System;
using System.Collections.Generic;

namespace Logiciel_de_gestion_de_cave_a_vin.Models;

public partial class DescriptionBouteilleAppelation
{
    public int IdAppelation { get; set; }

    public string Appelation { get; set; } = null!;

    public virtual ICollection<Bouteille> Bouteilles { get; } = new List<Bouteille>();
}
