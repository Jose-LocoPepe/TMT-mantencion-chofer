﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TMT_mantencion_chofer;

public partial class TransporteContext : DbContext
{
    public TransporteContext()
    {
    }

    public TransporteContext(DbContextOptions<TransporteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Chofer> Chofers { get; set; }

    public virtual DbSet<Kilometraje> Kilometrajes { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=transporte;user=usr_transporte;password=pass123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bus");

            entity.HasIndex(e => e.Patente, "patente").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .HasColumnName("codigo");
            entity.Property(e => e.Disponibilidad).HasColumnName("disponibilidad");
            entity.Property(e => e.Patente)
                .HasMaxLength(50)
                .HasColumnName("patente");
        });

        modelBuilder.Entity<Chofer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chofer");

            entity.HasIndex(e => e.IdBus, "id_bus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Disponibilidad).HasColumnName("disponibilidad");
            entity.Property(e => e.IdBus).HasColumnName("id_bus");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdBusNavigation).WithMany(p => p.Chofers)
                .HasForeignKey(d => d.IdBus)
                .HasConstraintName("chofer_ibfk_1");
        });

        modelBuilder.Entity<Kilometraje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kilometraje");

            entity.HasIndex(e => e.IdViaje, "id_viaje");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DistanciaRecorrida).HasColumnName("distancia_recorrida");
            entity.Property(e => e.IdViaje).HasColumnName("id_viaje");

            entity.HasOne(d => d.IdViajeNavigation).WithMany(p => p.Kilometrajes)
                .HasForeignKey(d => d.IdViaje)
                .HasConstraintName("kilometraje_ibfk_1");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("viaje");

            entity.HasIndex(e => e.IdBus, "id_bus");

            entity.HasIndex(e => e.IdChofer, "id_chofer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CiudadDestino)
                .HasMaxLength(50)
                .HasColumnName("ciudad_destino");
            entity.Property(e => e.CiudadOrigen)
                .HasMaxLength(50)
                .HasColumnName("ciudad_origen");
            entity.Property(e => e.Distancia).HasColumnName("distancia");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaTermino)
                .HasColumnType("date")
                .HasColumnName("fecha_termino");
            entity.Property(e => e.IdBus).HasColumnName("id_bus");
            entity.Property(e => e.IdChofer).HasColumnName("id_chofer");

            entity.HasOne(d => d.IdBusNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdBus)
                .HasConstraintName("viaje_ibfk_1");

            entity.HasOne(d => d.IdChoferNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdChofer)
                .HasConstraintName("viaje_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}