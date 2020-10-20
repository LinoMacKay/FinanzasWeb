using Microsoft.AspNetCore.Mvc;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;

namespace FoodYeah.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService OrderService)
        {
            _orderService = OrderService;
        }

        [HttpGet]
        public ActionResult<DataCollection<OrderDto>> GetAll(int page = 1, int take = 20) => _orderService.GetAll(page, take);

        [HttpGet("simple")]
        public ActionResult<DataCollection<OrderSimpleDto>> GetAllSimple(int page = 1, int take = 20) => _orderService.GetAllSimple(page, take);

        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetById(int id)
        {
            return _orderService.GetById(id);
        }

        [HttpGet("simple/{id}")]
        public ActionResult<OrderSimpleDto> GetByIdSimple(int id)
        {
            return _orderService.GetByIdSimple(id);
        }

        [HttpPost]
        public ActionResult Create(OrderCreateDto model)
        {
            var result = _orderService.Create(model);

            return new JsonResult(new
            {
                Message = "Su Pedido se ha realizado correctamente. Espere aproximadamente "
                + _orderService.GetAverageTime()
                + " para recibir su orden",
                DetalleDeOrden = result
            });
        }

        [HttpPut("updateEndTime/{id}")]
        public ActionResult UpdateEndTime(int id)
        {
            _orderService.SetEndTime(id);
            return NoContent();
        }

        [HttpGet("OrderDelivered/{id}")]
        public ActionResult isOrderDelivered(int id)
        {
            string message;
            message = _orderService.GetDeliveredOrder(id);
            return new JsonResult(new
            {
                Message = message
            });
        }

        [HttpGet("getAverageTime")]
        public ActionResult GetAverageTime()
        {
            return new JsonResult(new
            {
                AverageTime = _orderService.GetAverageTime()
            });
        }

    }
}
