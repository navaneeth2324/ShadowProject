﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerAppDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CustomerAppEntities : DbContext
    {
        public CustomerAppEntities()
            : base("name=CustomerAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LoginDB> LoginDBs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    
        public virtual int usp_AddProduct(string sl, string name, Nullable<int> price)
        {
            var slParameter = sl != null ?
                new ObjectParameter("sl", sl) :
                new ObjectParameter("sl", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddProduct", slParameter, nameParameter, priceParameter);
        }
    }
}
