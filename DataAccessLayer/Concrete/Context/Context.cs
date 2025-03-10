﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete

{
    public class Context:IdentityDbContext<AppUser, AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =ERAY\\SQLEXPRESS; database=BlogLiveDb; integrated security=true;TrustServerCertificate=True");

            //optionsBuilder.UseSqlServer("server =205.144.171.18; database=db_a88619_smtblog; user=smtcoder-001; Password=Akca1975");

            //optionsBuilder.UseSqlServer("Data Source = SQL5109.site4now.net; Initial Catalog = db_a88619_smtblog; User Id = db_a88619_smtblog_admin; Password =Akca1975");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                   .HasOne(x => x.HomeTeam)
                   .WithMany(y => y.HomeMatches)
                   .HasForeignKey(z => z.HomeTeamID)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Match>()
                .HasOne(x => x.GuestTeam)
                .WithMany(y => y.AwayMatches)
                .HasForeignKey(z => z.GuestTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
            /// HomeMatches =>>> WriterSender
            /// AwayMatches =>>> WriterReceiver


            /// HomeTeam =>>> SenderUser
            /// GuestTeam =>>> ReceiverUser


        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message2> message2s { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
