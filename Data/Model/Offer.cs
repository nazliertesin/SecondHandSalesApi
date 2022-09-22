﻿namespace Data.Model
{
    public class Offer
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual decimal Price { get; set; }
        public virtual bool IsApproved { get; set; }
    }
}
