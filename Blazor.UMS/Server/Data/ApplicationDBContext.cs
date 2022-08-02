﻿using Blazor.UMS.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.UMS.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
