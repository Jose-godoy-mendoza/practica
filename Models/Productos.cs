using System.ComponentModel.DataAnnotations;

namespace api_productos.Models
{
    public class Productos
    {
        [Key]
        public int idproducto {get;set;}
        public string producto{get;set;}
        public int idmarca{get;set;}
        public string descripcion{get;set;}
        public string imagen{get;set;}
        public double precio_costo{get;set;}
        public double precio_venta{get;set;}
        public int existencia{get;set;}
        public string fecha_ingreso{get;set;}

    }

}