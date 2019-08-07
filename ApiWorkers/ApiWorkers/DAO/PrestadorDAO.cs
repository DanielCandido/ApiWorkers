using ApiWorkers.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiWorkers.DAO
{
    public class PrestadorDAO
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["conexaoDB"].ConnectionString;
        private IDbConnection conexao;

        public PrestadorDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<Prestador> ListarPrestadorDb(int? id)
        {
            var listaPrestadores = new List<Prestador>();

            IDbCommand selectQuery = conexao.CreateCommand();


            if (id == null)
            {
                selectQuery.CommandText = "Select * from Prestador";
            } else
            {
                selectQuery.CommandText = $"Select * from Prestador where Id = {id}";
            }

            IDataReader resultado = selectQuery.ExecuteReader();
            while (resultado.Read())
            {
                var prest = new Prestador();

                prest.Id = Convert.ToInt32(resultado["Id"]);
                prest.Nome = Convert.ToString(resultado["Nome"]);
                prest.Sobrenome = Convert.ToString(resultado["Sobrenome"]);
                prest.NomeFantasia = Convert.ToString(resultado["NomeFantasia"]);
                prest.Email = Convert.ToString(resultado["Email"]);
                prest.Rg = Convert.ToString(resultado["Rg"]);
                prest.Cpf = Convert.ToString(resultado["Cpf"]);
                prest.CategoriaId = Convert.ToInt32(resultado["CategoriaId"]);
                prest.SubcategoriaId = Convert.ToInt32(resultado["SubcategoriaId"]);
                prest.Telefone = Convert.ToString(resultado["Telefone"]);
                prest.Celular = Convert.ToString(resultado["Celular"]);
                prest.Cep = Convert.ToString(resultado["Cep"]);
                prest.Endereco = Convert.ToString(resultado["Endereco"]);
                prest.NumeroCasa = Convert.ToInt32(resultado["Numero"]);
                prest.Complemento = Convert.ToString(resultado["Complemento"]);
                prest.Bairro = Convert.ToString(resultado["Bairro"]);
                prest.Cidade = Convert.ToString(resultado["Cidade"]);
                prest.Uf = Convert.ToString(resultado["Estado"]);
                prest.Senha = Convert.ToString(resultado["Senha"]);

                listaPrestadores.Add(prest);
            }
            conexao.Close();

            return listaPrestadores;
        }

        public void InserirPrestadorDB(Prestador prestador)
        {
            IDbCommand insertQuery = conexao.CreateCommand();
            insertQuery.CommandText = "Insert into Prestador (Nome, Sobrenome ,NomeFantasia, Email, Rg, Cpf," +
                "Categoria, Subcategoria, Telefone, Celular, Cep, Endereco, Numero, Complemento, Bairro, Cidade, Estado, Senha) " +
                "Values (@Nome, @Sobrenome, @NomeFantasia, @Email, @Rg, @Cpf, @Categoria, @Subcategoria, @Telefone, @Celular, " +
                "@Cep, @Endereco, @Numero, @Complemento, @Bairro, @Cidade, @Estado, @Senha)";

            IDbDataParameter paramNome = new SqlParameter("Nome", prestador.Nome);
            insertQuery.Parameters.Add(paramNome);
            IDbDataParameter paramSobrenome = new SqlParameter("Sobrenome", prestador.Sobrenome);
            insertQuery.Parameters.Add(paramSobrenome);
            IDbDataParameter paramNomeFantasia = new SqlParameter("NomeFantasia", prestador.NomeFantasia);
            insertQuery.Parameters.Add(paramNomeFantasia);
            IDbDataParameter paramEmail = new SqlParameter("Email", prestador.Email);
            insertQuery.Parameters.Add(paramEmail);
            IDbDataParameter paramRg = new SqlParameter("Rg", prestador.Rg);
            insertQuery.Parameters.Add(paramRg);
            IDbDataParameter paramCpf = new SqlParameter("Cpf", prestador.Cpf);
            insertQuery.Parameters.Add(paramCpf);
            IDbDataParameter paramCategoria = new SqlParameter("Categoria", prestador.CategoriaId);
            insertQuery.Parameters.Add(paramCategoria);
            IDbDataParameter paramSubcategoria = new SqlParameter("Subcategoria", prestador.SubcategoriaId);
            insertQuery.Parameters.Add(paramSubcategoria);
            IDbDataParameter paramTelefone = new SqlParameter("Telefone", prestador.Telefone);
            insertQuery.Parameters.Add(paramTelefone);
            IDbDataParameter paramCelular = new SqlParameter("Celular", prestador.Celular);
            insertQuery.Parameters.Add(paramCelular);
            IDbDataParameter paramCep = new SqlParameter("Cep", prestador.Cep);
            insertQuery.Parameters.Add(paramCep);
            IDbDataParameter paramEndereco = new SqlParameter("Endereco", prestador.Endereco);
            insertQuery.Parameters.Add(paramEndereco);
            IDbDataParameter paramNumeroCasa = new SqlParameter("Numero", prestador.NumeroCasa);
            insertQuery.Parameters.Add(paramNumeroCasa);
            IDbDataParameter paramComplemento = new SqlParameter("Complemento", prestador.Complemento);
            insertQuery.Parameters.Add(paramComplemento);
            IDbDataParameter paramBairro = new SqlParameter("Bairro", prestador.Bairro);
            insertQuery.Parameters.Add(paramBairro);
            IDbDataParameter paramCidade = new SqlParameter("Cidade", prestador.Cidade);
            insertQuery.Parameters.Add(paramCidade);
            IDbDataParameter paramUf = new SqlParameter("Estado", prestador.Uf);
            insertQuery.Parameters.Add(paramUf);
            IDbDataParameter paramSenha = new SqlParameter("Senha", prestador.Senha);
            insertQuery.Parameters.Add(paramSenha);

            insertQuery.ExecuteNonQuery();
        }

        public void AtualizarUsuarioDB(Prestador prestador)
        { 
            IDbCommand updateQuery = conexao.CreateCommand();
            updateQuery.CommandText = "update Prestador set Nome = @Nome, Sobrenome = @Sobrenome," +
                " NomeFantasia = @NomeFantasia, Email = @Email, Rg = @Rg, Cpf = @Cpf, Categoria = @Categoria, Subcategoria = @Subcategoria" +
                " Telefone = @Telefone, Celular = @Celular, Cep = @Cep, Endereco = @Endereco, Numero = @Numero," +
                " Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado, Senha = @Senha," +
                " Sexo = @Sexo where Id = @Id";

            IDbDataParameter paramNome = new SqlParameter("Nome", prestador.Nome);
            updateQuery.Parameters.Add(paramNome);
            IDbDataParameter paramSobrenome = new SqlParameter("Sobrenome", prestador.Sobrenome);
            updateQuery.Parameters.Add(paramSobrenome);
            IDbDataParameter paramNomeFantasia = new SqlParameter("NomeFantasia", prestador.Sobrenome);
            updateQuery.Parameters.Add(paramNomeFantasia);
            IDbDataParameter paramEmail = new SqlParameter("Email", prestador.Email);
            updateQuery.Parameters.Add(paramEmail);
            IDbDataParameter paramRg = new SqlParameter("Rg", prestador.Rg);
            updateQuery.Parameters.Add(paramRg);
            IDbDataParameter paramCpf = new SqlParameter("Cpf", prestador.Cpf);
            updateQuery.Parameters.Add(paramCpf);
            IDbDataParameter paramCategoria = new SqlParameter("Categoria", prestador.CategoriaId);
            updateQuery.Parameters.Add(paramCategoria);
            IDbDataParameter paramSubcategoria = new SqlParameter("Cpf", prestador.SubcategoriaId);
            updateQuery.Parameters.Add(paramSubcategoria);
            IDbDataParameter paramTelefone = new SqlParameter("Telefone", prestador.Telefone);
            updateQuery.Parameters.Add(paramTelefone);
            IDbDataParameter paramCelular = new SqlParameter("Celular", prestador.Celular);
            updateQuery.Parameters.Add(paramCelular);
            IDbDataParameter paramCep = new SqlParameter("Cep", prestador.Cep);
            updateQuery.Parameters.Add(paramCep);
            IDbDataParameter paramEndereco = new SqlParameter("Endereco", prestador.Endereco);
            updateQuery.Parameters.Add(paramEndereco);
            IDbDataParameter paramNumeroCasa = new SqlParameter("Numero", prestador.NumeroCasa);
            updateQuery.Parameters.Add(paramNumeroCasa);
            IDbDataParameter paramComplemento = new SqlParameter("Complemento", prestador.Complemento);
            updateQuery.Parameters.Add(paramComplemento);
            IDbDataParameter paramBairro = new SqlParameter("Bairro", prestador.Bairro);
            updateQuery.Parameters.Add(paramBairro);
            IDbDataParameter paramCidade = new SqlParameter("Cidade", prestador.Cidade);
            updateQuery.Parameters.Add(paramCidade);
            IDbDataParameter paramUf = new SqlParameter("Estado", prestador.Uf);
            updateQuery.Parameters.Add(paramUf);
            IDbDataParameter paramSenha = new SqlParameter("Senha", prestador.Senha);
            updateQuery.Parameters.Add(paramSenha);

            IDataParameter paramId = new SqlParameter("Id", prestador.Id);
            updateQuery.Parameters.Add(paramId);

            updateQuery.ExecuteNonQuery();
        }
    } 
}