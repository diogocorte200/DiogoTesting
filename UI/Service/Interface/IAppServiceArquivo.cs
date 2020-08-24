using System;
using System.Collections.Generic;
using System.Text;
using UI.Model;

namespace UI.Service.Interface
{
    public interface IAppServiceArquivo
    {
        ResultErroModel ObterArquivo(int id);
    }
}
