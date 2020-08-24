using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Test.MoqData;
using UI.Model;
using UI.Service.Interface;

namespace Test.Service
{
    public class ArquivoServiceMoq
    {
        public static IAppServiceArquivo GetInstance()
        {
            var moqArquivo = new Mock<IAppServiceArquivo>();
            moqArquivo.Setup(s => s.ObterArquivo(It.IsAny<int>()))
            .Returns((int i) => ArquivoDataMoq.Listar().FirstOrDefault(x => x.Codigo == i));

            return moqArquivo.Object;
        }
    }
}
