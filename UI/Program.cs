using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using UI.Model;
using UI.Service;
using UI.Service.Interface;

namespace UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o endereço do arquivo");
            var sourceUrl = Console.ReadLine();

            var serviceProvider = new ServiceCollection()
           .AddSingleton<IAppServiceConversao, AppServiceConversao>()
           .BuildServiceProvider();

            var service = serviceProvider.GetService<IAppServiceConversao>();
            var retorno = service.EditarArquivo(sourceUrl);

            Console.WriteLine(retorno.Descricao);
            Console.ReadKey();



        }
    }
}
