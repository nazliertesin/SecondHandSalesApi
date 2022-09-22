using System.Collections.Generic;

namespace Data.Model
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual IList<Offer> Offers { get; set; }
        public virtual IList<Sold> SoldProducts { get; set; }
        public virtual IList<Product> Products { get; set; }


    }
}
