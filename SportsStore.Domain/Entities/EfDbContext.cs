﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace SportsStore.Domain.Entities
{
   public class EfDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
