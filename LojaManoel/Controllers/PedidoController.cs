using LojaManoel.Modelos;
using LojaManoel.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaManoel.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly Empacotador _empacotador;

        public PedidoController(Empacotador empacotador)
        {
            _empacotador = empacotador;
        }

        [HttpPost("empacotar")]
        public IActionResult EmpacotarPedidos([FromBody] List<Pedido> pedidos)
        {
            var resultado = new List<object>();
            foreach (var pedido in pedidos)
            {
                var caixas = _empacotador.Empacotar(pedido.Produtos);
                resultado.Add(new { pedido.Pedido_Id, caixas });
            }
            return Ok(resultado);
        }
    }

}
