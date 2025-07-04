﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
    }
}
