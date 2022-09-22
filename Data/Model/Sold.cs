using System;

namespace Data.Model
{
    public class Sold
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual DateTime DateofPurchase { get; set; }
    }
}
