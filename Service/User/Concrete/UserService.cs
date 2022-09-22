using AutoMapper;
using Data.Model;
using Dto;
using NHibernate;

namespace Service
{
    public class UserService : BaseService<UserDto, User>, IUserService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<User> hibernateRepository;

        public UserService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<User>(session);
        }




    }
}
