using AutoMapper;
using Data.Model;
using Dto;
using NHibernate;

namespace Service
{
    public class CategoryService : BaseService<CategoryDto, Category>, ICategoryService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Category> hibernateRepository;

        public CategoryService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Category>(session);
        }



    }
}
