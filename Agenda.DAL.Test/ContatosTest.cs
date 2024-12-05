using Agenda.Domain;
using NUnit.Framework;
using System;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest
    {
        Contatos _contatos;

       [SetUp]
       public void SetUp()
       {
            _contatos = new Contatos();
       }

        [Test]
        public void AdicionarContatoTest()
        {
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Fabricia"
            };

            _contatos.Adicionar(contato);

            Assert.True(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Lucas"
            };
            Contato contatoResultado;

            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);

            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

        [Test]
        public void ObterTodosOsContatosTest()
        {
            var contato1 = new Contato() { Id = Guid.NewGuid(), Nome = "Maria" };
            var contato2 = new Contato() { Id = Guid.NewGuid(), Nome = "João" };

            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            var lstContatos = _contatos.ObterTodos();
            var contatoResultado = lstContatos.Where(c => c.Id == contato1.Id).First();

            Assert.IsTrue(lstContatos.Count > 1);
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }
    }
}
