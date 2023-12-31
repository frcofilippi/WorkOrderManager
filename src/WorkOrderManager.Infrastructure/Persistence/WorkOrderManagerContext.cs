﻿using Microsoft.EntityFrameworkCore;
using WorkOrderManager.Domain.Common;

namespace WorkOrderManager.Infrastructure.Persistence
{
    public class WorkOrderManagerContext : DbContext
    {
        public WorkOrderManagerContext(DbContextOptions<WorkOrderManagerContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
    }
}
