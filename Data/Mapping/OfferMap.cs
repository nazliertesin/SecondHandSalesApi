using Data.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Data.Mapping
{
    public class OfferMap : ClassMapping<Offer>
    {
        public OfferMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });
            Property(b => b.ProductId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.UserId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.IsApproved, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });

            Property(b => b.Price, x =>
            {
                x.Type(NHibernateUtil.Decimal);
                x.NotNullable(true);
            });
            ManyToOne(x => x.Product, map => map.Column("Offer_Product"));
            ManyToOne(x => x.User, map => map.Column("Offer_User"));


            Table("offer");

        }
    }
}
