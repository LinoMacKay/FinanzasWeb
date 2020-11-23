using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodYeah.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _CustomerService;

        public CustomerController(CustomerService clientService)
        {
            _CustomerService = clientService;
        }
        [HttpGet]
        public ActionResult<DataCollection<CustomerDto>> GetAll(int page = 1, int take = 20) => _CustomerService.GetAll(page, take);

        [HttpGet("simple")]
        public ActionResult<DataCollection<CustomerSimpleDto>> GetAllSimple(int page = 1, int take = 20) => _CustomerService.GetAllSimple(page, take);

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetById(int id) => _CustomerService.GetById(id);


        [HttpPut("{id}")]
        public ActionResult Update(int id, CustomerUpdateDto model)
        {
            _CustomerService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _CustomerService.Remove(id);
            return NoContent();
        }


        [HttpGet("onlycustomers")]
        public ActionResult<DataCollection<CustomerDto>> GetOnylCustomers(int page = 1, int take = 20) => _CustomerService.GetOnlyCustomers(page, take);


        [HttpGet("email/{email}")]
        public ActionResult<CustomerDto> GetByEmail(string email) => _CustomerService.GetByEmail(email);


    }



}
