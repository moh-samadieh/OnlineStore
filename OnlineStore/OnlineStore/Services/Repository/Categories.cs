using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Data.Entities;

namespace OnlineStore.Services
{
    public partial class Repository
    {
        public IQueryable<Category> GetCategories()
        {
            return this._myContext.Categories;
        }
    }
}
