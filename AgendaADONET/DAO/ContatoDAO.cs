﻿using AgendaADONET.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaADONET.DAO
{
    public class ContatoDAO
    {
        public DataTable GetContatos()
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM CONTATOS";
            DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)comando);
            DbDataReader reader = DAOUtils.GetDbDataReader(comando);
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
        }

        public void Excluir(int id)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM CONTATOS WHERE ID = @id";
            comando.Parameters.Add(new SqlParameter("@id", id));
            comando.ExecuteNonQuery();
        }

        public void Inserir(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO CONTATOS(NOME, EMAIL, TELEFONE) VALUES (@nome, @email, @telefone)";
            comando.Parameters.Add(new SqlParameter("@nome", contato.Nome));
            comando.Parameters.Add(new SqlParameter("@email", contato.Email));
            comando.Parameters.Add(new SqlParameter("@telefone", contato.Telefone));
            comando.ExecuteNonQuery();
        }

        public void Atualizar(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE CONTATOS SET NOME = @nome, EMAIL = @email, TELEFONE = @telefone WHERE ID = @id";
            comando.Parameters.Add(new SqlParameter("@nome", contato.Nome));
            comando.Parameters.Add(new SqlParameter("@email", contato.Email));
            comando.Parameters.Add(new SqlParameter("@telefone", contato.Telefone));
            comando.Parameters.Add(new SqlParameter("@id", contato.Id));
            comando.ExecuteNonQuery();
        }
    }
}
