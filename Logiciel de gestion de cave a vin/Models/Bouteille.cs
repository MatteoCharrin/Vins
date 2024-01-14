using System;
using System.Collections.Generic;

namespace Logiciel_de_gestion_de_cave_a_vin.Models;

public partial class Bouteille
{

    public int IdBouteille { get; set; }

    public string NomCompletVin { get; set; } = null!;

    public DateTime Millesime { get; set; }

    public int GardeConseilleDebut { get; set; }

    public int GardeConseilleFin { get; set; }

    public int? NumeroTiroir { get; set; }

    public int EmplacementBouteille { get; set; }

    public int IdCave { get; set; }

    public int IdAppelation { get; set; }

    public int IdCouleur { get; set; }

    public override string ToString()
    {
        return NomCompletVin;
    }

    public virtual DescriptionBouteilleAppelation IdAppelationNavigation { get; set; } = null!;

    public virtual Cave IdCaveNavigation { get; set; } = null!;

    public virtual DescriptionBouteilleCouleur IdCouleurNavigation { get; set; } = null!;
}
