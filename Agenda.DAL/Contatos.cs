using System.Data.SqlClient;
using System;
using Agenda.Domain;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using System.Linq;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _connectionString;

        public Contatos()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        public void Adicionar(Contato contato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("INSERT INTO Contato (Id, Nome) VALUES (@Id, @Nome)", contato);
            }
        }

        public Contato Obter(Guid id)
        {
            Contato contato;

            using (var connection = new SqlConnection(_connectionString))
            {
                contato = connection.QueryFirst<Contato>("SELECT Id, Nome FROM Contato WHERE Id = @Id", new {Id = id});                
            }

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            using (var connection = new SqlConnection(_connectionString))
            {
                contatos = connection.Query<Contato>("SELECT Id, Nome FROM Contato").ToList();             
            }

            return contatos;
        }
    }
}
