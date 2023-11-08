using AppControleFinanceiro.Models;
using LiteDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AppControleFinanceiro.Repositorio
{
    
    public class RepositorioDeTransacao : IRepositorioDeTransacao
    {
        private readonly LiteDatabase _database;
        private string nomeTransacao = "transação";

        public RepositorioDeTransacao(LiteDatabase db)
        {
            _database = db;
        }
        public List<Transacao> PegarTudo()
        {
            return _database
                .GetCollection<Transacao>(nomeTransacao)
                .Query()
                .OrderByDescending(a => a.Data)
                .ToList();
        }
        public void Add(Transacao transacao)
        {
            var col = _database.GetCollection<Transacao>(nomeTransacao);
            col.Insert(transacao);
        }

        public void Update(Transacao transacao)
        {
            var col = _database.GetCollection<Transacao>(nomeTransacao);
            col.Update(transacao);
        }
        public void Deletar(Transacao transacao)
        {
            var col = _database.GetCollection<Transacao>(nomeTransacao);
            col.Update(transacao);
        }

    }
}
