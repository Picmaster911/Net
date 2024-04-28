﻿using Microsoft.EntityFrameworkCore;

namespace MovieManager.Tests
{
    public static class Utilities
    {
        public static DbContextOptions<TContext> CreateInMemoryDbOptions<TContext>() where TContext : DbContext
        {
            return new DbContextOptionsBuilder<TContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }
    }
}
