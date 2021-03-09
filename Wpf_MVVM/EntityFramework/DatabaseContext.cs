using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

using Wpf_MVVM.Enities;

namespace Wpf_MVVM.EntityFramework
{
  public class DatabaseContext : DbContext
  {
    private string connectionString = "server=localhost;port=3306;database=notedbdemo;user=root;password=";
    public DbSet<Note> Notes { get; set; }

    public Note SelectedItem { get; set; }

    public DatabaseContext()
    {
      this.Database.EnsureCreatedAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Note>(entity =>
      {
        entity.HasKey(e => e.Id);
      });
    }
  }
}
