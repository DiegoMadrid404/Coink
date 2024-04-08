using Microsoft.EntityFrameworkCore;

namespace Proyecto.Datos.Contexto
{
    public partial class ContextoProyecto
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0LR75OU;Initial Catalog=Coink;User ID=sa;Password=123456");
            }
        }
    }
}