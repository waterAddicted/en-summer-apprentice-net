using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Ticket_Management.Api.Models;

namespace TMS.Api.DbContext
{
    public class TicketManagementDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Event> Event { get; set; } = null!;
        public DbSet<EventType> EventType { get; set; } = null!;
        public DbSet<Venue> Venue { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<TicketCategory> TicketCategory { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;


        public TicketManagementDbContext(DbContextOptions<TicketManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var concertId = 1;
            var musicalId = 2;
            var playId = 3;
            var conferenceId = 4;

            modelBuilder.Entity<EventType>().HasData(new EventType { EventtypeId = concertId, EventTypeName = "Concerts" });
            modelBuilder.Entity<EventType>().HasData(new EventType { EventtypeId = musicalId, EventTypeName = "Musicals" });
            modelBuilder.Entity<EventType>().HasData(new EventType { EventtypeId = playId, EventTypeName = "Plays" });
            modelBuilder.Entity<EventType>().HasData(new EventType { EventtypeId = conferenceId, EventTypeName = "Conferences" });

            modelBuilder.Entity<Venue>().HasData(new Venue { VenueId = 1, Location = "Remote", Capacity = 20 });
            modelBuilder.Entity<Venue>().HasData(new Venue { VenueId = 2, Location = "Physical", Capacity = 20 });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = 1,
                EventName = "John Egbert Live",
                StartDate = DateTime.Now.AddMonths(6),
                EndDate = DateTime.Now.AddMonths(7),
                EventDescription = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                EventTypeId = concertId,
                VenueId = 1
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = 2,
                EventName = "The State of Affairs: Michael Live!",
                StartDate = DateTime.Now.AddMonths(6),
                EndDate = DateTime.Now.AddMonths(7),
                EventDescription = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                EventTypeId = concertId,
                VenueId = 1
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = 3,
                EventName = "John Egbert Live",
                StartDate = DateTime.Now.AddMonths(6),
                EndDate = DateTime.Now.AddMonths(7),
                EventDescription = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                EventTypeId = concertId,
                VenueId = 2
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = 4,
                EventName = "Clash of the DJs",
                StartDate = DateTime.Now.AddMonths(6),
                EndDate = DateTime.Now.AddMonths(7),
                EventDescription = "DJs from all over the world will compete in this epic battle for eternal fame.",
                EventTypeId = concertId,
                VenueId = 1
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = 6,
                EventName = "Techorama 2021",
                StartDate = DateTime.Now.AddMonths(6),
                EndDate = DateTime.Now.AddMonths(7),
                EventDescription = "The best tech conference in the world",
                EventTypeId = conferenceId,
                VenueId = 1
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = 5,
                EventName = "To the Moon and Back",
                StartDate = DateTime.Now.AddMonths(6),
                EndDate = DateTime.Now.AddMonths(7),
                EventDescription = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                EventTypeId = musicalId,
                VenueId = 1
            });

            modelBuilder.Entity<TicketCategory>().HasData(new TicketCategory { TicketCategoryId = 1, Description = "Regular", EventId = 1, Price=10 });
            modelBuilder.Entity<TicketCategory>().HasData(new TicketCategory { TicketCategoryId = 2, Description = "VIP", EventId = 1, Price = 20 });

            modelBuilder.Entity<User>().HasData(new User { UserId = 1, UserName = "John Doe", Email="test@test.com"});

            base.OnModelCreating(modelBuilder);
        }
    }
}
