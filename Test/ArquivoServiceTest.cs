using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Test.MoqData;
using Test.Service;
using UI.Service;
using UI.Service.Interface;

namespace Test
{
    public class ArquivoServiceTest
    {
        private IAppServiceArquivo _appServiceArquivo;
        private IAppServiceConversao _appServiceConversao;

        [SetUp]
        public void Setup()
        {
            _appServiceArquivo = ArquivoServiceMoq.GetInstance();
            _appServiceConversao = new AppServiceConversao();

        }

        [Test]
        public void EditarArquivo_EnderecoSourceUrlCorreto_Sucesso()
        {
            // arrange
            var data = _appServiceArquivo.ObterArquivo(3);
            var expected = 200;

            // act
            var result = _appServiceConversao.EditarArquivo(data.Descricao);

            // assert
            Assert.IsTrue(result.Codigo == expected);
        }

        [Test]
        public void EditarArquivo_EnderecoSourceUrlNullo_Erro()
        {
            // arrange
            var data = _appServiceArquivo.ObterArquivo(1);
            var expected = "O valor do sourceUrl, não pode ser nullo!";

            // act
            var result = _appServiceConversao.EditarArquivo(data.Descricao);

            // assert
            Assert.IsTrue(result.Descricao == expected || result.Codigo != 200);
        }

        [Test]
        public void EditarArquivo_EnderecoSourceUrlInesistente_Erro()
        {
            // arrange
            var data = _appServiceArquivo.ObterArquivo(2);
            var expected = 404;

            // act
            var result = _appServiceConversao.EditarArquivo(data.Descricao);

            // assert
            Assert.IsTrue(result.Codigo == expected);
        }

    }
}
