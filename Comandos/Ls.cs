using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnixUtilities.Comandos {
    internal class Ls {


        public static void List() {
            Console.Clear();
            string defaultDirectory = @"C:\Users\" + Environment.UserName;
            //Console.Write("Esse é o diretorio atual no qual voce esta " + defaultDirectory);
            bool rodando = true;
            while (rodando) {
                if(Directory.Exists(defaultDirectory)) {
                    Console.WriteLine("O diretorio atual é " 
                        + defaultDirectory);

                    string[] files = Directory.GetFiles(defaultDirectory);
                    Console.WriteLine("Arquivos no Diretorio");
                    foreach (string file in files) {
                        Console.WriteLine(file);

                    }
                    string[] directories = Directory.GetDirectories(defaultDirectory);
                    Console.WriteLine("Pastas no Diretorio");
                    foreach (string directory in directories) {
                        Console.WriteLine(directory);
                    }

                    Console.WriteLine(@"Para retornar ao menu pressione 0.
Para voltar um diretorio pressione ../
Ou digite o nome de um diretório válido para navegar para ele.

");

                    string reply = Console.ReadLine();
                    switch (reply) {
                        case "0":
                            rodando = false;
                            break;
                        case "../":

                            string parentDiretory = Path.Combine(defaultDirectory, "..");
                            if (Directory.Exists(parentDiretory)) {
                                
                                defaultDirectory =  parentDiretory;

                            }

                            break;

                        default:
                            if (Directory.Exists(reply)) {
                                defaultDirectory = reply;
                            }
                            break;

                    }


                }
            }
            


        }

        public static void List(string comando) { 
            
        }
    }
}
