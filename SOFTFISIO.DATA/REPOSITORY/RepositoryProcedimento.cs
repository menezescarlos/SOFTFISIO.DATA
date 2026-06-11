using SOFTFISIO.DATA.INTERFACE;
using SOFTFISIO.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTFISIO.DATA.REPOSITORY
{
    internal class RepositoryProcedimento : RepositoryBase<Procedimento>, IRepositoryProcedimento
    {
        public RepositoryProcedimento(bool SaveChanges = true) : base(SaveChanges)
        {
        }
    }
}
