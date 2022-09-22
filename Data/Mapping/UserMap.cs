using Data.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Data.Mapping
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.UserName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Email, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Password, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Bag(x => x.Offers, map => map.Key(k => k.Column("Offer_User")), rel => rel.OneToMany());
            Bag(x => x.Products, map => map.Key(k => k.Column("Product_User")), rel => rel.OneToMany());
            Bag(x => x.SoldProducts, map => map.Key(k => k.Column("User_Sold")), rel => rel.OneToMany());


            Table("user");
        }
    }
}
