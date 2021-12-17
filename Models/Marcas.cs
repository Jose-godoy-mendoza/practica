using System.ComponentModel.DataAnnotations;

namespace api_productos.Models
{
    public class Marcas
    {
        [Key]
        public int idmarca {get;set;}
        public string marca{get;set;}
        

    }

}