﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_A53C6D_lapiscinatestEntities : DbContext
    {
        public DB_A53C6D_lapiscinatestEntities()
            : base("name=DB_A53C6D_lapiscinatestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_Acciones> Tbl_Acciones { get; set; }
        public virtual DbSet<Tbl_AreaDeImpresion> Tbl_AreaDeImpresion { get; set; }
        public virtual DbSet<Tbl_Areas> Tbl_Areas { get; set; }
        public virtual DbSet<Tbl_Categorias> Tbl_Categorias { get; set; }
        public virtual DbSet<Tbl_Clientes> Tbl_Clientes { get; set; }
        public virtual DbSet<Tbl_Cuentas> Tbl_Cuentas { get; set; }
        public virtual DbSet<Tbl_DetalleOrden> Tbl_DetalleOrden { get; set; }
        public virtual DbSet<Tbl_Empleados> Tbl_Empleados { get; set; }
        public virtual DbSet<Tbl_Estado> Tbl_Estado { get; set; }
        public virtual DbSet<Tbl_Mesas> Tbl_Mesas { get; set; }
        public virtual DbSet<Tbl_MesasReservas> Tbl_MesasReservas { get; set; }
        public virtual DbSet<Tbl_Ordenes> Tbl_Ordenes { get; set; }
        public virtual DbSet<Tbl_Productos> Tbl_Productos { get; set; }
        public virtual DbSet<Tbl_Relacion> Tbl_Relacion { get; set; }
        public virtual DbSet<Tbl_Roles> Tbl_Roles { get; set; }
        public virtual DbSet<Tbl_TipoProductos> Tbl_TipoProductos { get; set; }
        public virtual DbSet<Tbl_Transacciones> Tbl_Transacciones { get; set; }
        public virtual DbSet<Tbl_UnionMesas> Tbl_UnionMesas { get; set; }
        public virtual DbSet<Tbl_Usuarios> Tbl_Usuarios { get; set; }
    }
}