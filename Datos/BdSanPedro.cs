using System.Data.Entity.ModelConfiguration.Conventions;

namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BdSanPedro : DbContext
    {
        public BdSanPedro()
            : base("name=BdSanPedro")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer = new InicializadorBaseDatos(modelBuilder);
            Database.SetInitializer(initializer);
        }

        public DbSet<Alumno> Alumnos { get; set; }
    }

    public class InicializadorBaseDatos : CreateDatabaseIfNotExists<BdSanPedro>
    {
        public InicializadorBaseDatos(DbModelBuilder builder) 
        {

        }

    }
}