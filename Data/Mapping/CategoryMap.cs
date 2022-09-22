using Data.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Data.Mapping
{
    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {

            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.CategoryName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Bag(x => x.Products, map => map.Key(k => k.Column("Product_Category")), rel => rel.OneToMany());


            Table("category");
        }
    }
}
