using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTFISIO.DATA.INTERFACE
{
    public interface IRepositoryModel<T> where T : class
    {
        // Método para selecionar todos os objetos do banco de dados.Ele retorna uma lista de objetos
        List<T> SelecionarTodos();

        // Método para selecionar um objeto específico do banco de dados usando sua chave primária (PK).
        T SelecionarPorPK(params object[] variavel);

        // Método para incluir um novo objeto no banco de dados. Ele recebe um objeto do tipo T
        // e retorna o objeto incluído.
        T Incluir(T objeto);

        // Método para alterar um objeto existente no banco de dados. Ele recebe um objeto do tipo T
        T Alterar(T objeto);

        // Método para excluir um objeto do banco de dados. Ele recebe um objeto do tipo T a ser excluído.
        void Excluir(T objeto);

        // Método para excluir um objeto do banco de dados usando sua chave primária (PK). Ele recebe
        void Exclusao(params object[] variavel);

        // Método para salvar as alterações no banco de dados. Ele retorna um valor booleano indicando
        bool SaveChanges();
    }
}
