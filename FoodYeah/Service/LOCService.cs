using FoodYeah.Commons;
using FoodYeah.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Service
{
    public interface LOCService
    {
        DataCollection<LOCDto> GetAll(int page, int take);
        LOCDto CreateLOC(CreateLOCDto model);
        LOCDto GetById(int id);
        void UpdateLOC(int id,UpdateLOCDto model);
        void Delete(int id);

    }
}
