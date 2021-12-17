using Microsoft.EntityFrameworkCore;

namespace api_productos.Models
{
    class Conexion : DbContext
    {
        public Conexion(DbContextOptions<Conexion> options) : base (options){}
        public DbSet<Productos> productos {get;set;}
        public DbSet<Marcas> marcas {get;set;}

    }
    class Conectar
    {
        private const string CadenaConexion =" server=localhost;port=3309;database=db_punto_venta;userid=root;pwd=root" ;
        public static Conexion Create()
        {
            var constructor = new DbContextOptionsBuilder<Conexion>();
            constructor.UseMySQL(CadenaConexion);
            var cn= new Conexion(constructor.Options);
            return cn;
        }
    }
}