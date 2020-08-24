using System;
using System.Collections.Generic;
using System.Text;
using UI.Model;

namespace UI.Service.Interface
{
    public interface IAppServiceConversao
    {
        ResultErroModel EditarArquivo(string sourceUrl);
        void DowloadArquivo(string fileName, string sourceUrl);
    }
}
