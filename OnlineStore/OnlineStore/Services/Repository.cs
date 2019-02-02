using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Data.Entities;

namespace OnlineStore.Services
{
    public class Repository
    {
        private readonly OnlineStoreContext _myContext;

        public Repository(OnlineStoreContext myContext)
        {
            this._myContext = myContext;
        }

        public Product GetProduct(int ID)
        {
            return this._myContext.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.ID == ID);
        }
    }
}
