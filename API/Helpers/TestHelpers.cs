using System;
using System.IO;
using API.Controllers;

namespace Exemplo_2.Helpers
{

    public class ExemploLeituraArquivo
    {

       
    }



    public static class TestHelpers
	{
		public static string PastaDoExecutavel => (".");

       // public static string caminhoArquivo;
        //public static string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Caminhos.txt");

        //public static string caminhoEmail;
        //public static string caminhoLink;


        public static string pasta;
        public static string email;
        public static string linkSistema;


       // public static string pasta = LerLinhaArquivo(caminhoArquivo, 1);
        //public static string email = LerLinhaArquivo(caminhoArquivo, 2);
        //public static string linkSistema = LerLinhaArquivo(caminhoArquivo, 3);

        /*public static string LerLinhaArquivo(string caminho, int numLinha)
        {
            using (StreamReader reader = new StreamReader(caminho))
            {
                for (int i = 1; i < numLinha; i++)
                {
                    reader.ReadLine();
                }
                return reader.ReadLine();
            }
        }*/
    }

}

