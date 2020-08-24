using System;
using System.Collections.Generic;
using System.Text;
using UI.Domain.Interface;

namespace UI.Domain
{
    public class AppArquivoDomain : IArquivoDomain
    {
        public string ValidaEntrada(string valor)
        {
            var result = "";

            if (valor == null || valor == "")
            {
                result = "O valor nao pode ser nullo";
            }
            return result;
        }
    }
}
