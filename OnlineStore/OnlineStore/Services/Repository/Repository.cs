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
        private readonly OnlineStoreContext _myContext;

        public Repository(OnlineStoreContext myContext)
        {
            this._myContext = myContext;
        }
    }
}
