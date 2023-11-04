using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro
{
    public class AppSettings
    {
        private static string nomeArquivoDB = "database.db";
        private static string diretorioArquivoDB = FileSystem.AppDataDirectory;
        public static string caminhoArquivoDB = Path.Combine(nomeArquivoDB, diretorioArquivoDB);
    }
}
