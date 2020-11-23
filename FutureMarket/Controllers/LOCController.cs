using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Controllers
{
    [Route("loc")]
    [ApiController]
    public class LOCController: ControllerBase
    {
        private readonly LOCService _locservice;

        public LOCController(LOCService locservice)
        {
            _locservice = locservice;
        }

        [HttpGet]
        public ActionResult<DataCollection<LOCDto>> GetAll(int page = 1, int take = 20)
        {
            return _locservice.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public ActionResult<LOCDto> GetById(int id) => _locservice.GetById(id);

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateLOCDto model)
        {
            _locservice.UpdateLOC(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _locservice.Delete(id);
            return NoContent();
        }
    }
}
