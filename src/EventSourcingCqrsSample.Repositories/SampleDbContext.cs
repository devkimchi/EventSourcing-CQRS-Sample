namespace EventSourcingCqrsSample.Repositories
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SampleDbContext : DbContext
    {
        public SampleDbContext()
            : base("name=SampleDbContext")
        {
        }

        public virtual IDbSet<EventStream> EventStreams { get; set; }
        public virtual IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
