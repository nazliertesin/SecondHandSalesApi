using AutoMapper;
using Data.Model;
using Dto;
using NHibernate;

namespace Service
{
    public class SoldService : BaseService<SoldDto, Sold>, ISoldService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Sold> hibernateRepository;

        public SoldService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Sold>(session);
        }




    }
}
