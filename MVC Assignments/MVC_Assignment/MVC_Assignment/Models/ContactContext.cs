using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MVC_Assignment.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactContext() : base("DefaultConnection") { }
    }
}