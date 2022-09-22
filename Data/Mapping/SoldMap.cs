using Data.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace Data
{
    public class SoldMap : ClassMapping<Sold>
    {
        public SoldMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.CustomerId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.ProductId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.DateofPurchase, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });
            ManyToOne(x => x.User, map => map.Column("User_Sold"));
            Table("sold");
        }
    }
}

