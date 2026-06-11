using SOFTFISIO.DATA.INTERFACE;
using SOFTFISIO.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTFISIO.DATA.REPOSITORY
{
    internal class RepositoryFuncionario : RepositoryBase<Funcionario>, IRepositoryFuncionario
    {
        public RepositoryFuncionario(bool SaveChanges = true) : base(SaveChanges)
        {
        }
    }
}
