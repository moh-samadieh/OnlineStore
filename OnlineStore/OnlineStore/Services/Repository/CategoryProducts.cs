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
        public bool UpdateProductCategories(int pid, List<int> cats)
        {
            try
            {
                var q = this._myContext.CategoryProducts.Where(x => x.ProductID == pid);

                this._myContext.RemoveRange(q);
                this._myContext.SaveChanges();

                foreach (var cat in cats)
                {
                    var newrow = new CategoryProduct { ProductID = pid, CategoryID = cat };
                    this._myContext.CategoryProducts.Add(newrow);

                }

                this._myContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
