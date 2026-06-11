using SOFTFISIO.DATA.INTERFACE;
using SOFTFISIO.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTFISIO.DATA.REPOSITORY
{
    public class RepositorySala : RepositoryBase<Sala>, IRepositorySala
    {
        public RepositorySala(bool SaveChanges = true) : base(SaveChanges)
        {
        }
    }
}
