using Domain.Persistence.Events;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence
{
    public class EventStoreDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EventStoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<EventEntity> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEntity>(e =>
            {
                e.ToTable("Events");

                e.HasKey(ee => ee.Id);

                e.Property(ee => ee.Type)
                 .HasConversion<int>();

                e.Property(ee => ee.Event)
                 .HasColumnName("Serialized")
                 .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => DeserializeEvent(v));
            });

            base.OnModelCreating(modelBuilder);
        }

        private IEvent DeserializeEvent(string v)
        {
            var check = JsonConvert.DeserializeObject<BaseEvent>(v);

            return (IEvent)JsonConvert.DeserializeObject(v, EventCollection.All[check.Type]);
        }
    }
}
