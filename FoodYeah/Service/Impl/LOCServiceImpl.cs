using AutoMapper;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FoodYeah.Service.Impl
{
    public class LOCServiceImpl : LOCService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LOCServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public LOCDto CreateLOC(CreateLOCDto model)
        {
            var entry = new LOC
            {
                TCEA = model.TCEA,
                TotalLineOfCredit = model.TotalLineOfCredit,
                Customer = _context.Customers.Single(x=>x.CustomerId == model.CustomerId),
                CustomerId = model.CustomerId
            };
            _context.LOCs.Add(entry);
            _context.SaveChanges();
            return _mapper.Map<LOCDto>(entry);
        }

        public void Delete(int id)
        {
            var target = _context.LOCs.Single(x => x.LOCId == id);
            _context.Remove(target);
            _context.SaveChanges();
        }

        public DataCollection<LOCDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<LOCDto>>(
                 _context.LOCs.OrderByDescending(x => x.LOCId)
                               .Include(x=>x.Customer)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }

        public LOCDto GetById(int id)
        {
            return _mapper.Map<LOCDto>(
                _context.LOCs.Single(x => x.LOCId == id)
           );
        }

        public void UpdateLOC(int id,UpdateLOCDto model)
        {


            var target = _context.LOCs.Single(x => x.LOCId == id);
            target.TCEA = model.TCEA;
            target.TotalLineOfCredit = model.TotalLineOfCredit;
            _context.SaveChanges();
        }
    }
}
