using SOFTFISIO.DATA.INTERFACE;
using SOFTFISIO.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTFISIO.DATA.REPOSITORY
{
    internal class RepositoryPaciente : RepositoryBase<Paciente>, IRepositoryPaciente
    {
        public RepositoryPaciente(bool SaveChanges = true) : base(SaveChanges)
        {
        }
    }
}
