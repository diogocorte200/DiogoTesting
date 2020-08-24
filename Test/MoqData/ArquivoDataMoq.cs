using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UI.Model;

namespace Test.MoqData
{
    public static class ArquivoDataMoq
    {
        public static ICollection<ResultErroModel> Listar()
        {
            var lista = new List<ResultErroModel>();

            lista.Add(new ResultErroModel { Codigo = 1, Descricao = "" });
            lista.Add(new ResultErroModel { Codigo = 2, Descricao = "https://s3.amazonaws.com/uux-itaas-/minha-cdn-logs/input-01.txt" });
            lista.Add(new ResultErroModel { Codigo = 3, Descricao = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt" });

            return lista;
        }

    }
}