using EstudosApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudosApi.Repository.DataBaseContext
{
    // A classe DBContext está herdando as caracteristicas de DbContext.
    public class DBContext : DbContext
    {

        //Aqui é onde está sendo criada a conexão.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
        }

        //Aqui é onde está sendo estabelecida a conexão com o banco de dado.
        //Estamos intanciando e depois conectando a ele.
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
    }
}
