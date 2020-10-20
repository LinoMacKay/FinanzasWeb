using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using System.Threading.Tasks;

namespace FoodYeah.Service
{
    public class CardServiceImpl : CardService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private static int id;
        public CardServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            id = 0;
            _context = context;
            _mapper = mapper;
        }
        private bool ValidateCard(Card entry) {
            bool validation =  true;

            if (entry.CardNumber < 1000000000000000 && entry.CardNumber > 9999999999999999)
                validation = false;
            else if (entry.CardCvi < 100 && entry.CardCvi > 9999)
                validation = false;

            return validation;
        }

        public CardDto Create(CardCreateDto model)
        {
            Customer Customer = _context.Customers.Single(x => x.CustomerId == model.CustomerId);

            var entry = new Card
            {
                CardId = id++,
                CardNumber = model.CardNumber,
                CustomerId = model.CustomerId,
                Customer = Customer,
                CardType = model.CardType,
                CardCvi = model.CardCvi,
                CardOwnerName = Customer.CustomerName,
                CardExpireDate = model.CardExpireDate,
                Money = 100 //no hay manera de extraer el valor del dinero de una tarjeta por el momento, por lo que le coloco 100 por defecto.
            };
            
            bool validation = ValidateCard(entry);


            if (validation) 
            {
                _context.Cards.Add(entry);
                _context.SaveChanges();
                return _mapper.Map<CardDto>(entry);
            }
            
            CardDto nullEntry = new CardDto();
            return nullEntry;
        }

        public void Remove(int id)
        {
            _context.Remove(new Card
            {
                CardId = id
            });
            _context.SaveChanges();
        }

        public void Update(int id, CardUpdateDto model)
        {
            var entry = _context.Cards.Single(x => x.CardId == id);

            entry.CardOwnerName = model.CardOwnerName;

            _context.SaveChanges();
        }

        public  DataCollection<CardDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<CardDto>>(
                  _context.Cards
                              .Include(x => x.Customer)
                              .OrderByDescending(x => x.CustomerId)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }

        public DataCollection<CardSimpleDto> GetAllSimple(int page, int take)
        {
            return _mapper.Map<DataCollection<CardSimpleDto>>(
                 _context.Cards
                              .OrderByDescending(x => x.CustomerId)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }

        public CardDto GetById(int id)
        {
            return _mapper.Map<CardDto>(
                 _context.Cards.Single(x => x.CardId == id)
            );
        }

        public CardDto GetByCustomerId(int id)
        {
            return _mapper.Map<CardDto>(
                 _context.Cards.Single(x => x.CustomerId == id)
            );
        }
    }
}
