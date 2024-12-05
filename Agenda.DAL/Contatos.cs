using System.Data.SqlClient;
using System;
using Agenda.Domain;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _connectionString;
        SqlConnection _connection;

        public Contatos()
        {
            _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=true;";
            _connection = new SqlConnection(_connectionString);
        }

        public void Adicionar(Contato contato)
        {
            _connection.Open();

            var sql = String.Format("INSERT INTO Contato (Id, Nome) VALUES ('{0}', '{1}');", contato.Id, contato.Nome);

            var cmd = new SqlCommand(sql, _connection);
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public Contato Obter(Guid id)
        {
            _connection.Open();

            var sql = String.Format("SELECT Id, Nome FROM Contato WHERE Id = '{0}'", id);

            var cmd = new SqlCommand(sql, _connection); 

            var sqlDataReader = cmd.ExecuteReader();
            sqlDataReader.Read();

            var contato = new Contato()
            {
                Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                Nome = sqlDataReader["Nome"].ToString()
            };

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();
            _connection.Open();

            var sql = String.Format("SELECT Id, Nome FROM Contato");

            var cmd = new SqlCommand(sql, _connection);

            var sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var contato = new Contato()
                {
                    Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                    Nome = sqlDataReader["Nome"].ToString()
                };

                contatos.Add(contato);
            }

            return contatos;
        }
    }
}
