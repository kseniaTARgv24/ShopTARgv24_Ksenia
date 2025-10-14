using Microsoft.EntityFrameworkCore;
using ShopTARgv24_Ksenia.Core.Domain;

namespace ShopTARgv24_Ksenia.Data
{

    public class ShopContext : DbContext 
    {

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }


        public DbSet<FileToApi> FileToApis { get; set; }
        public DbSet<Spaceship> Spaceships { get; set; }

        public DbSet<Kindergarten> Kindergartens { get; set; }

        public DbSet<FileToDatabase> FileToDatabases { get; set; }


    }
}




//ShopContext is a class that inherits from DbContext (Entity Framework Core’s main class for working with a database).

//The constructor ShopContext(DbContextOptions<ShopContext> options) takes in configuration options (like which database to use, connection string, etc.).

//: base(options) means it passes those options to the parent DbContext constructor, so EF Core knows how to set up this context.

//The body { } is empty because you don’t need to add anything extra — the base constructor already handles it.

//A DbSet<T> represents a table in the database.

//Here, Spaceship is the table that will store data for the Spaceship class (which is your entity/model).

//With this line, EF Core will let you do things like: