﻿using Microsoft.EntityFrameworkCore;
using Waf.BookLibrary.Library.Domain;

namespace Waf.BookLibrary.Library.Applications.Data
{
    internal class BookLibraryContext : DbContext
    {
        private readonly string dataSourcePath;

        public BookLibraryContext(string dataSourcePath)
        {
            this.dataSourcePath = dataSourcePath;
        }

        public bool HasChanges() 
        {
            ChangeTracker.DetectChanges();
            return ChangeTracker.HasChanges(); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + dataSourcePath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(PersonMapping.Builder);
            modelBuilder.Entity<Book>(BookMapping.Builder);
        }
    }
}
