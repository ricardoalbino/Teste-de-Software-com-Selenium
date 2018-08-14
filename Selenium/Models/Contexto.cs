using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Selenium.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> DbUsuario { get; set; }
    }
}