using Data.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Data.Mapping
{
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.ProductName, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Description, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Color, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Brand, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Price, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Decimal);
                x.NotNullable(true);
            });

            Property(b => b.CategoryId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.IsOfferable, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });

            Property(b => b.IsSold, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });

            Property(b => b.SupplierId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });
            ManyToOne(x => x.Category, map => map.Column("Product_Category"));
            ManyToOne(x => x.User, map => map.Column("Product_User"));
            Bag(x => x.Offers, map => map.Key(k => k.Column("Offer_Product")), rel => rel.OneToMany());


            Table("product");

        }
    }
}
