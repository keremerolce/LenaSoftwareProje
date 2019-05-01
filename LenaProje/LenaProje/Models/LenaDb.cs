namespace LenaProje.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LenaDb : DbContext
    {
        public LenaDb()
            : base("name=LenaDb")
        {
        }

        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
