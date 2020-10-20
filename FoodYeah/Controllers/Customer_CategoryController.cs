using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodYeah.Controllers
{
    [Route("customer_categories")]
    [ApiController]
    public class Customer_CategoryController : ControllerBase
    {
        private readonly Customer_CategoryService _Customer_CategoryService;

        public Customer_CategoryController(Customer_CategoryService clientService)
        {
            _Customer_CategoryService = clientService;
        }
        [HttpGet]
        public ActionResult<DataCollection<Customer_CategoryDto>> GetAll(int page=1, int take = 20) => _Customer_CategoryService.GetAll(page, take);
        
        [HttpGet("simple")]
        public ActionResult<DataCollection<Customer_CategorySimpleDto>> GetAllSimple(int page=1, int take = 20) => _Customer_CategoryService.GetAllSimple(page, take);
        
        [HttpGet("{id}")]
        public ActionResult<Customer_CategoryDto> GetById(int id) => _Customer_CategoryService.GetById(id);
        
        [HttpPost]
        public ActionResult Create(Customer_CategoryCreateDto Customer_Category)
        {
            _Customer_CategoryService.Create(Customer_Category);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Customer_CategoryUpdateDto model)
        {
            _Customer_CategoryService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _Customer_CategoryService.Remove(id);
            return NoContent();
        }
    }
}