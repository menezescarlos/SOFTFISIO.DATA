using Microsoft.EntityFrameworkCore;
using SOFTFISIO.DATA.INTERFACE;
using SOFTFISIO.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTFISIO.DATA.REPOSITORY
{
    public class RepositoryCooperativa : RepositoryBase<Cooperativa>, IRepositoryCooperativa
    {
        public RepositoryCooperativa(bool SaveChanges = true)
            : base(SaveChanges)
        {
        }

        public List<Cooperativa> SelecionarTodosComCooperativa()
        {
            return _DATAFISIOContexto.Cooperativas
                .Include(u => u.IdEmpresaNavigation)
                .ToList();
        }
    }
}
