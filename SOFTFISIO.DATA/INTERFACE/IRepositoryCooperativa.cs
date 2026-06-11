using SOFTFISIO.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTFISIO.DATA.INTERFACE
{
    public interface IRepositoryCooperativa : IRepositoryModel<Cooperativa>
    {
        List<Cooperativa> SelecionarTodosComCooperativa();
    }

}
