using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using AutoFixture.Kernel;
using UI.Domain;
using UI.Domain.Interface;
using UI.Model;
using UI.Service.Interface;

namespace UI.Service
{
    public class AppServiceConversao : IAppServiceConversao
    {
        private readonly AppArquivoDomain _arquivoDomain;
        public AppServiceConversao()
        {
            _arquivoDomain = new AppArquivoDomain();
        }
        public void DowloadArquivo(string fileName, string sourceUrl)
        {
            try
            {
                var fileDowload = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

                if (!System.IO.Directory.Exists(fileDowload += @"\Arquivo\"))
                    System.IO.Directory.CreateDirectory(fileDowload);

                WebClient webClient = new WebClient();
                webClient.DownloadFile(sourceUrl, fileDowload += fileName);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ResultErroModel EditarArquivo(string sourceUrl)
        {
            try
            {
                var validacao = _arquivoDomain.ValidaEntrada(sourceUrl);

                if (validacao != "")
                {
                    return new ResultErroModel
                    {
                        Codigo = 404,
                        Descricao = "O valor do sourceUrl, não pode ser nullo!"
                    };

                }

                var result = "";
                var fileName = sourceUrl.Substring(sourceUrl.LastIndexOf("/")).Replace("/", "");
                DowloadArquivo(fileName, sourceUrl);


                var newFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
                newFile += @"\Arquivo\" + fileName;

                if (File.Exists(newFile))
                {
                    try
                    {
                        var file = System.IO.File.ReadAllLines(newFile);

                        var stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine("#Versão: 1.0");
                        stringBuilder.AppendLine($"#Data: {DateTime.Now.ToString("dd/MM/yyyy")}");
                        stringBuilder.AppendLine("#Fields: provider http-method status-code uri-path time-taken");
                        stringBuilder.AppendLine("tamanho da resposta cache-status");

                        foreach (var item in file)
                        {
                            var version = item.Split('|')[3].Split('/')[0];
                            version = version.TrimStart('"');

                            var text = item.Split('/')[1];

                            var number = item.Split('|')[1];
                            var numberLast = item.Split('|')[4];
                            var numberFirst = item.Split('|')[0];
                            var numberTwo = item.Split('|')[2];

                            var line = $"MINHA CDN {version} {number} / {text} {Math.Round(double.Parse(numberLast.Replace(".", ",")))} {numberFirst} {numberTwo}";
                            stringBuilder.AppendLine(line);
                        }
                        stringBuilder.AppendLine("“MINHA CDN” criará arquivos de log por meio de URLs específicos.");



                        var fileUpdate = newFile.Replace(fileName, "");
                        fileUpdate += "update-" + fileName;

                        if (System.IO.Directory.Exists(fileUpdate))
                            System.IO.Directory.CreateDirectory(fileUpdate);

                        result = fileUpdate;

                        if (!System.IO.File.Exists(fileUpdate))
                        {
                            var fileCrete = System.IO.File.Create(fileUpdate);
                            fileCrete.Dispose();
                            fileCrete.Close();
                        }

                        System.IO.File.WriteAllText(fileUpdate, stringBuilder.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }

                else
                {
                    new ResultErroModel
                    {
                        Codigo = 404,
                        Descricao = "O diretório nâo existe!"
                    };
                }

                return new ResultErroModel
                {
                    Codigo = 200,
                    Descricao = result
                };

            }
            catch (Exception ex)
            {

                return new ResultErroModel
                {
                    Codigo = 404,
                    Descricao = ex.Message
                };
            }

        }
    }
}
