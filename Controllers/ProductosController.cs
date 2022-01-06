using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using api_productos.Models;


namespace api_productos.Controllers
{
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private Conexion dbConexion;
        public ProductosController()
        {
            dbConexion = Conectar.Create();
        }
        [HttpGet]
        public ActionResult GetActionResult()
        {
            var producto = from p in dbConexion.productos join m in dbConexion.marcas on p.idmarca equals m.idmarca select new 
           {
                Id_producto=p.idproducto,
                Producto = p.producto,
                Marca = m.marca,
                Descripcion = p.descripcion,
                Imagen = p.imagen,
                precio_Costo = p.precio_costo,
                Precio_Venta = p.precio_venta,
                Existencias = p.existencia,
                Fecha_ingreso = p.fecha_ingreso
           };

            return Ok(producto.ToArray());
        }

        [HttpGet("{id}")]
        public async Task <ActionResult> GetActionResult(int id)
        {
            var productos=await dbConexion.productos.FindAsync(id);
            if(productos !=null)
            {
                return Ok(productos);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBodyAttribute] Productos productos)
        {
            if(ModelState.IsValid)
            {
                //pro.Add(productos);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }
            else{
                return BadRequest();
            }
        }


        public async Task<ActionResult> Put([FromBodyAttribute] Productos productos)
        {
            //update clientes set where id
            var v_clientes = dbConexion.productos.SingleOrDefault( p => p.idproducto == productos.idproducto);
            if( v_clientes !=null && ModelState.IsValid)
            {
                dbConexion.Entry(v_clientes).CurrentValues.SetValues(productos);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }
            else{
                return BadRequest();
            }
        }
        



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var clientes = dbConexion.productos.SingleOrDefault(p => p.idproducto == id);
            if(clientes !=null)
            {
                dbConexion.productos.Remove(clientes);
                await  dbConexion.SaveChangesAsync();
                return Ok();
            }
            else{
                return BadRequest();
            }
        }
    }
}
