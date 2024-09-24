using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Context;

public class SQLContextFactory:IDesignTimeDbContextFactory<SQLContext>
{
    public SQLContext CreateDbContext(string[] args)
    {
        // Lendo a connection string do appsettings.json
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<SQLContext>();
        var connectionString = config.GetConnectionString("DefaultConnection");

        // Configurando o DbContext com a connection string
        optionsBuilder.UseSqlServer(connectionString);

        return new SQLContext(optionsBuilder.Options);
    }
}