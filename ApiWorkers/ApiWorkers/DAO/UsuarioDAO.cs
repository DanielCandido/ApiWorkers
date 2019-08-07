
using ApiWorkers.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiWorkers.DAO.UsuarioDAO
{
    public class UsuarioDAO
    {

        //string stringConexao = ConfigurationManager.AppSettings["connectionDB"];
        private string stringConexao = ConfigurationManager.ConnectionStrings["conexaoDB"].ConnectionString;
        private IDbConnection conexao;

        public UsuarioDAO()
        { 
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<Usuario> ListarUsuariosDB()
        {

            var listaUsuarios = new List<Usuario>();

            IDbCommand selectQuery = conexao.CreateCommand();
            selectQuery.CommandText = "Select * from Usuarios";

            IDataReader resultado = selectQuery.ExecuteReader();
            while (resultado.Read())
            {
                var usu = new Usuario();

                usu.Id = Convert.ToInt32(resultado["Id"]);
                usu.Nome = Convert.ToString(resultado["Nome"]);
                usu.Sobrenome = Convert.ToString(resultado["Sobrenome"]);
                usu.Email = Convert.ToString(resultado["Email"]);
                usu.Rg = Convert.ToString(resultado["Rg"]);
                usu.Cpf = Convert.ToString(resultado["Cpf"]);
                usu.Telefone = Convert.ToString(resultado["Telefone"]);
                usu.Celular = Convert.ToString(resultado["Celular"]);
                usu.Cep = Convert.ToString(resultado["Cep"]);
                usu.Endereco = Convert.ToString(resultado["Endereco"]);
                usu.NumeroCasa = Convert.ToInt32(resultado["Numero"]);
                usu.Complemento = Convert.ToString(resultado["Complemento"]);
                usu.Bairro = Convert.ToString(resultado["Bairro"]);
                usu.Cidade = Convert.ToString(resultado["Cidade"]);
                usu.Uf = Convert.ToString(resultado["Estado"]);
                usu.Senha = Convert.ToString(resultado["Senha"]);

                listaUsuarios.Add(usu);

            }

            conexao.Close();

            return listaUsuarios;
        }

        public void InserirUsuarioDB(Usuario usuario)
        {
            IDbCommand insertQuery = conexao.CreateCommand();
            insertQuery.CommandText = "Insert into Usuarios (Nome, Sobrenome, Email, Rg, Cpf," +
                " Telefone, Celular, Cep, Endereco, Numero, Complemento, Bairro, Cidade, Estado, Senha) " +
                "Values (@Nome, @Sobrenome, @Email, @Rg, @Cpf, @Telefone, @Celular, @Cep, @Endereco, @Numero," +
                " @Complemento, @Bairro, @Cidade, @Estado, @Senha)";

            IDbDataParameter paramNome = new SqlParameter("Nome", usuario.Nome);
            insertQuery.Parameters.Add(paramNome);
            IDbDataParameter paramSobrenome = new SqlParameter("Sobrenome", usuario.Sobrenome);
            insertQuery.Parameters.Add(paramSobrenome);
            IDbDataParameter paramEmail = new SqlParameter("Email", usuario.Email);
            insertQuery.Parameters.Add(paramEmail);
            IDbDataParameter paramRg = new SqlParameter("Rg", usuario.Rg);
            insertQuery.Parameters.Add(paramRg);
            IDbDataParameter paramCpf = new SqlParameter("Cpf", usuario.Cpf);
            insertQuery.Parameters.Add(paramCpf);
            IDbDataParameter paramTelefone = new SqlParameter("Telefone", usuario.Telefone);
            insertQuery.Parameters.Add(paramTelefone);
            IDbDataParameter paramCelular = new SqlParameter("Celular", usuario.Celular);
            insertQuery.Parameters.Add(paramCelular);
            IDbDataParameter paramCep = new SqlParameter("Cep", usuario.Cep);
            insertQuery.Parameters.Add(paramCep);
            IDbDataParameter paramEndereco = new SqlParameter("Endereco", usuario.Endereco);
            insertQuery.Parameters.Add(paramEndereco);
            IDbDataParameter paramNumeroCasa = new SqlParameter("Numero", usuario.NumeroCasa);
            insertQuery.Parameters.Add(paramNumeroCasa);
            IDbDataParameter paramComplemento = new SqlParameter("Complemento", usuario.Complemento);
            insertQuery.Parameters.Add(paramComplemento);
            IDbDataParameter paramBairro = new SqlParameter("Bairro", usuario.Bairro);
            insertQuery.Parameters.Add(paramBairro);
            IDbDataParameter paramCidade = new SqlParameter("Cidade", usuario.Cidade);
            insertQuery.Parameters.Add(paramCidade);
            IDbDataParameter paramUf = new SqlParameter("Estado", usuario.Uf);
            insertQuery.Parameters.Add(paramUf);
            IDbDataParameter paramSenha = new SqlParameter("Senha", usuario.Senha);
            insertQuery.Parameters.Add(paramSenha);

            insertQuery.ExecuteNonQuery();
        }

        public void AtualizarUsuarioDB(Usuario usuario)
        {
            IDbCommand updateQuery = conexao.CreateCommand();
            updateQuery.CommandText = "update Usuarios set Nome = @Nome, Sobrenome = @Sobrenome," +
                " Email = @Email, Rg = @Rg, Cpf = @Cpf," +
                " Telefone = @Telefone, Celular = @Celular, Cep = @Cep, Endereco = @Endereco, Numero = @Numero," +
                " Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado, Senha = @Senha," +
                " Sexo = @Sexo where Id = @Id";

            IDbDataParameter paramNome = new SqlParameter("Nome", usuario.Nome);
            updateQuery.Parameters.Add(paramNome);
            IDbDataParameter paramSobrenome = new SqlParameter("Sobrenome", usuario.Sobrenome);
            updateQuery.Parameters.Add(paramSobrenome);
            IDbDataParameter paramEmail = new SqlParameter("Email", usuario.Email);
            updateQuery.Parameters.Add(paramEmail);
            IDbDataParameter paramRg = new SqlParameter("Rg", usuario.Rg);
            updateQuery.Parameters.Add(paramRg);
            IDbDataParameter paramCpf = new SqlParameter("Cpf", usuario.Cpf);
            updateQuery.Parameters.Add(paramCpf);
            IDbDataParameter paramTelefone = new SqlParameter("Telefone", usuario.Telefone);
            updateQuery.Parameters.Add(paramTelefone);
            IDbDataParameter paramCelular = new SqlParameter("Celular", usuario.Celular);
            updateQuery.Parameters.Add(paramCelular);
            IDbDataParameter paramCep = new SqlParameter("Cep", usuario.Cep);
            updateQuery.Parameters.Add(paramCep);
            IDbDataParameter paramEndereco = new SqlParameter("Endereco", usuario.Endereco);
            updateQuery.Parameters.Add(paramEndereco);
            IDbDataParameter paramNumeroCasa = new SqlParameter("Numero", usuario.NumeroCasa);
            updateQuery.Parameters.Add(paramNumeroCasa);
            IDbDataParameter paramComplemento = new SqlParameter("Complemento", usuario.Complemento);
            updateQuery.Parameters.Add(paramComplemento);
            IDbDataParameter paramBairro = new SqlParameter("Bairro", usuario.Bairro);
            updateQuery.Parameters.Add(paramBairro);
            IDbDataParameter paramCidade = new SqlParameter("Cidade", usuario.Cidade);
            updateQuery.Parameters.Add(paramCidade);
            IDbDataParameter paramUf = new SqlParameter("Estado", usuario.Uf);
            updateQuery.Parameters.Add(paramUf);
            IDbDataParameter paramSenha = new SqlParameter("Senha", usuario.Senha);
            updateQuery.Parameters.Add(paramSenha);

            IDataParameter paramId = new SqlParameter("Id", usuario.Id);
            updateQuery.Parameters.Add(paramId);

            updateQuery.ExecuteNonQuery();
        }
    }
}