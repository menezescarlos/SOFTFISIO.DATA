using Microsoft.EntityFrameworkCore;
using SOFTFISIO.DATA.INTERFACE;
using SOFTFISIO.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTFISIO.DATA.REPOSITORY
{
    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        //Campo protegido para o contexto do Entity Framework, que será utilizado para realizar
        //as operações de banco de dados.
        protected DATAFISIOContext _DATAFISIOContexto;
        public bool _SaveChanges = true;

        //Construtor para o RepositoryBase, que recebe um parâmetro opcional para determinar se
        //as alterações devem ser salvas automaticamente.
        public RepositoryBase(bool saveChanges = true)
        {
            _SaveChanges = saveChanges;
            _DATAFISIOContexto = new DATAFISIOContext();
        }

        // Método para alterar um objeto no banco de dados. Ele marca o estado do objeto como modificado
        public T Alterar(T objeto)
        {
            _DATAFISIOContexto.Entry(objeto).State = EntityState.Modified;

            if (_SaveChanges)
            {
                _DATAFISIOContexto.SaveChanges();
            }
            return objeto;
        }

        // Implementação do método Dispose para liberar os recursos do contexto do Entity Framework.
        public void Dispose()
        {
            _DATAFISIOContexto.Dispose();
        }

        // Método para excluir um objeto do banco de dados. Ele remove o objeto do conjunto
        // de entidades e salva as alterações se necessário.
        public void Excluir(T objeto)
        {
            _DATAFISIOContexto.Set<T>().Remove(objeto);

            if (_SaveChanges)
            {
                _DATAFISIOContexto.SaveChanges();
            }
        }

        // Sobrecarga do método Excluir para excluir um objeto com base em sua chave primária.
        // Ele seleciona o objeto usando a chave primária e, em seguida, chama o método
        // Excluir para removê-lo do banco de dados.
        public void Exclusao(params object[] variavel)
        {
            var obj = SelecionarPorPK(variavel);
            Excluir(obj);
        }

        // Método para incluir um novo objeto no banco de dados. Ele adiciona o objeto ao conjunto
        public T Incluir(T objeto)
        {
            _DATAFISIOContexto.Set<T>().Add(objeto);

            if (_SaveChanges)
            {
                _DATAFISIOContexto.SaveChanges();
            }
            return objeto;
        }

        // Método para salvar as alterações no banco de dados. Ele chama o método SaveChanges do contexto   
        public void SaveChanges()
        {
            _DATAFISIOContexto.SaveChanges();
        }

        // Método para selecionar um objeto do banco de dados com base em sua chave primária.
        // Ele utiliza o método Find do conjunto de entidades para localizar o objeto.
        public T SelecionarPorPK(params object[] variavel)
        {
            return _DATAFISIOContexto.Set<T>().Find(variavel);
        }

        // Método para selecionar todos os objetos do banco de dados. Ele retorna uma lista de objetos
        public List<T> SelecionarTodos()
        {
            return _DATAFISIOContexto.Set<T>().ToList();
        }

        // Implementação do método SaveChanges da interface IRepositoryModel, que lança uma exceção
        bool IRepositoryModel<T>.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
