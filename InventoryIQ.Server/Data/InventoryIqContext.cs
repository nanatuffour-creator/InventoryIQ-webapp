using System;
using InventoryIQ.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryIQ.Server.Data;

public class InventoryIqContext(DbContextOptions<InventoryIqContext> options) : DbContext(options)
{
    public DbSet<UserEntities> User{get;set;}
}
