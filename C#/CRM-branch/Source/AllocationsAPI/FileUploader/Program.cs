using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Service.Api.DTOs;

namespace FileUploader
{
    class Program
    {
        private string filePath = "C:\\Users\\firthp\\Desktop\\New folder";
        private string logPath = "C:\\Users\\firthp\\Desktop\\New folder\\log";
        private string apiURL = "http://localhost:5020/api/VBL";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to File Uploader. Would you like to convert the files? (Y/N)");
            new Program().BeginApp();
            Console.Read();
        }

        public void BeginApp()
        {
            string answer = Console.ReadLine();
            bool response = answer.ToUpper().StartsWith("Y");
            bool response2 = answer.ToUpper().StartsWith("N");
            if (response)
            {
                System.IO.Directory.CreateDirectory(logPath);
                System.IO.Directory.CreateDirectory(filePath + "\\Converted");
                FetchFiles(filePath);
            }
            else if (response2)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Incorrect input. Would you like to convert the files? (Y/N)");
                BeginApp();
            }

        }

        public void FetchFiles(string filePath)
        {

            TextPipe("Start: " + DateTime.Now);
            string[] files =
            Directory.GetFiles(filePath, "*", SearchOption.TopDirectoryOnly);


        string strHostName = Dns.GetHostName();
        string ipEntry = Dns.GetHostEntry(strHostName).ToString();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var stop = fileName.IndexOf('_');
                if (stop > 0)
                {
                    var application = fileName.Substring(0, stop);
                    int number;

                    bool canParse = Int32.TryParse(application, out number);
                    if (canParse)
                    {
                        var fileContent = File.ReadAllBytes(file);


                        var docDTO = new VBLDocumentDTO
                        {
                            ApplicationId = number,
                            DocumentName = fileName,
                            DocumentType = DocumentType.Upload,
                            DocumentPath = "VBL",
                            FileContent = fileContent,
                            UserId = "Document Migration",
                            CreatedBy = "Document Migration",
                            ModifiedBy = "Document Migration",
                            CreatedDate = DateTime.Now,
                            UserIPAddress = ipEntry
                        };
                        
                            var response = CreateDocument(docDTO);
                            var result = response.Result.StatusCode;
                            if (response.Result.IsSuccessStatusCode)
                            {
                                TextPipe(fileName + " : " + result);
                            }
                            else
                            {
                                TextPipe("----------------------" + fileName + " : " + result);
                            }
                   
                    }
                    else
                    {
                        TextPipe("Cannot Parse " + fileName);
                    }
                }
                else
                {
                    TextPipe("Poorly formatted file name: " + fileName);
                }
            }

            TextPipe("End: " + DateTime.Now);
        }

        public async Task<HttpResponseMessage> CreateDocument(VBLDocumentDTO document)
        {
            var url = apiURL + "/Document/Upload";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = null;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));
                    MediaTypeFormatter bsonFormatter = new BsonMediaTypeFormatter();
                    response = await httpClient.PostAsync(url, document, bsonFormatter);
                    return response;
                }
                catch (Exception ex)
                {
                    TextPipe(ex.ToString());
                    throw;
                }
            }
        }

        public void TextPipe(string line)
        {
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(logPath + "\\log.txt", true))
            {
                file.WriteLine(line);
            }
            Console.WriteLine(line);
        }

    }
}
