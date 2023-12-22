using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Logiciel_de_gestion_de_cave_a_vin.Models;

public partial class MlmvinContext : DbContext
{
    public MlmvinContext()
    {
    }

    public MlmvinContext(DbContextOptions<MlmvinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bouteille> Bouteilles { get; set; }

    public virtual DbSet<Cave> Caves { get; set; }

    public virtual DbSet<DescriptionBouteilleAppelation> DescriptionBouteilleAppelations { get; set; }

    public virtual DbSet<DescriptionBouteilleCouleur> DescriptionBouteilleCouleurs { get; set; }

    public virtual DbSet<Fabricant> Fabricants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = TERMINAL-YUI\\SQLEXPRESS; Initial Catalog = MLMVin ; Integrated Security = SSPI; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bouteille>(entity =>
        {
            entity.HasKey(e => e.IdBouteille).HasName("PK__Bouteill__6FC7A266A37A4DBC");

            entity.ToTable("Bouteille");

            entity.Property(e => e.IdBouteille).HasColumnName("ID_Bouteille");
            entity.Property(e => e.EmplacementBouteille).HasColumnName("Emplacement_Bouteille");
            entity.Property(e => e.GardeConseilleDebut).HasColumnName("Garde_Conseille_Debut");
            entity.Property(e => e.GardeConseilleFin).HasColumnName("Garde_Conseille_Fin");
            entity.Property(e => e.IdAppelation).HasColumnName("ID_Appelation");
            entity.Property(e => e.IdCave).HasColumnName("ID_Cave");
            entity.Property(e => e.IdCouleur).HasColumnName("ID_Couleur");
            entity.Property(e => e.Millesime).HasColumnType("date");
            entity.Property(e => e.NomCompletVin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nom_Complet_Vin");
            entity.Property(e => e.NumeroTiroir).HasColumnName("Numero_Tiroir");

            entity.HasOne(d => d.IdAppelationNavigation).WithMany(p => p.Bouteilles)
                .HasForeignKey(d => d.IdAppelation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bouteille__ID_Ap__440B1D61");

            entity.HasOne(d => d.IdCaveNavigation).WithMany(p => p.Bouteilles)
                .HasForeignKey(d => d.IdCave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bouteille__ID_Ca__4316F928");

            entity.HasOne(d => d.IdCouleurNavigation).WithMany(p => p.Bouteilles)
                .HasForeignKey(d => d.IdCouleur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bouteille__ID_Co__44FF419A");
        });

        modelBuilder.Entity<Cave>(entity =>
        {
            entity.HasKey(e => e.IdCave).HasName("PK__cave__72095535DC794EDC");

            entity.ToTable("cave");

            entity.HasIndex(e => e.NomCave, "UQ__cave__CF270701BB50B9D6").IsUnique();

            entity.Property(e => e.IdCave).HasColumnName("ID_Cave");
            entity.Property(e => e.BouteillesParTiroir).HasColumnName("Bouteilles_Par_Tiroir");
            entity.Property(e => e.IdFabricant).HasColumnName("ID_Fabricant");
            entity.Property(e => e.NomCave)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nom_Cave");
            entity.Property(e => e.NombreTiroir).HasColumnName("Nombre_Tiroir");
            entity.Property(e => e.Temperature).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdFabricantNavigation).WithMany(p => p.Caves)
                .HasForeignKey(d => d.IdFabricant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cave__ID_Fabrica__403A8C7D");
        });

        modelBuilder.Entity<DescriptionBouteilleAppelation>(entity =>
        {
            entity.HasKey(e => e.IdAppelation).HasName("PK__Descript__B6D292150A490AD1");

            entity.ToTable("Description_Bouteille_Appelation");

            entity.Property(e => e.IdAppelation).HasColumnName("ID_Appelation");
            entity.Property(e => e.Appelation)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DescriptionBouteilleCouleur>(entity =>
        {
            entity.HasKey(e => e.IdCouleur).HasName("PK__Descript__5F2C5AB42C9DA6A1");

            entity.ToTable("Description_Bouteille_Couleur");

            entity.HasIndex(e => e.CouleurVin, "UQ__Descript__F50BCF19F8B5931F").IsUnique();

            entity.Property(e => e.IdCouleur).HasColumnName("ID_Couleur");
            entity.Property(e => e.CouleurVin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Couleur_Vin");
        });

        modelBuilder.Entity<Fabricant>(entity =>
        {
            entity.HasKey(e => e.IdFabricant).HasName("PK__Fabrican__DE7676E2663B1D3B");

            entity.ToTable("Fabricant");

            entity.HasIndex(e => e.NomFabricant, "UQ__Fabrican__DBED82CAB0A0A38D").IsUnique();

            entity.Property(e => e.IdFabricant).HasColumnName("ID_Fabricant");
            entity.Property(e => e.NomFabricant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nom_Fabricant");
            entity.Property(e => e.TypeFabricant).HasColumnName("Type_Fabricant");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
