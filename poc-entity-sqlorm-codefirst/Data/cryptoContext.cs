using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using poc_voya_entity.Models;

    public class cryptoContext : DbContext
    {
        public cryptoContext (DbContextOptions<cryptoContext> options)
            : base(options)
        {
        }

        public DbSet<poc_voya_entity.Models.crypto> crypto { get; set; } = default!;
    }
