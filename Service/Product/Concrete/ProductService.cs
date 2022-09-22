using AutoMapper;
using Data.Model;
using Dto;
using NHibernate;

namespace Service
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Product> hibernateRepository;

        public ProductService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Product>(session);
        }




    }
}
