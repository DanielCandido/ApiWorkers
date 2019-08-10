using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Workers.Domain;

namespace Workers.Repository
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

        public List<UsuarioDTO> ListarUsuariosDB(int ?id)
        {
            var listaUsuarios = new List<UsuarioDTO>();
            try
            {

                IDbCommand selectQuery = conexao.CreateCommand();
                if (id == null)
                {
                    selectQuery.CommandText = "Select * from Usuarios";
                }
                else
                {
                    selectQuery.CommandText = $"Select * from Usuarios where Id = {id}";
                }

                IDataReader resultado = selectQuery.ExecuteReader();
                while (resultado.Read())
                {
                    var usu = new UsuarioDTO
                    {

                        Id = Convert.ToInt32(resultado["Id"]),
                        Nome = Convert.ToString(resultado["Nome"]),
                        Sobrenome = Convert.ToString(resultado["Sobrenome"]),
                        Email = Convert.ToString(resultado["Email"]),
                        Rg = Convert.ToString(resultado["Rg"]),
                        Cpf = Convert.ToString(resultado["Cpf"]),
                        Sexo = Convert.ToString(resultado["Sexo"]),
                        Telefone = Convert.ToString(resultado["Telefone"]),
                        Celular = Convert.ToString(resultado["Celular"]),
                        Cep = Convert.ToString(resultado["Cep"]),
                        Endereco = Convert.ToString(resultado["Endereco"]),
                        NumeroCasa = Convert.ToInt32(resultado["Numero"]),
                        Complemento = Convert.ToString(resultado["Complemento"]),
                        Bairro = Convert.ToString(resultado["Bairro"]),
                        Cidade = Convert.ToString(resultado["Cidade"]),
                        Uf = Convert.ToString(resultado["Estado"]),
                        Senha = Convert.ToString(resultado["Senha"]),
                    };
                    listaUsuarios.Add(usu);

                }
                return listaUsuarios;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void InserirUsuarioDB(UsuarioDTO usuario)
        {
            try
            {
                IDbCommand insertQuery = conexao.CreateCommand();
                insertQuery.CommandText = "Insert into Usuarios (Nome, Sobrenome, Email, Rg, Cpf," +
                    " Telefone, Celular, Cep, Endereco, Numero, Complemento, Bairro, Cidade, Estado, Senha, Sexo) " +
                    "Values (@Nome, @Sobrenome, @Email, @Rg, @Cpf, @Telefone, @Celular, @Cep, @Endereco, @Numero," +
                    " @Complemento, @Bairro, @Cidade, @Estado, @Senha, @Sexo)";

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
                IDbDataParameter paramSexo = new SqlParameter("Sexo", usuario.Sexo);
                insertQuery.Parameters.Add(paramSexo);
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

           
        }

        public void AtualizarUsuarioDB(UsuarioDTO usuario)
        {
            try
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
                IDbDataParameter paramSexo = new SqlParameter("Sexo", usuario.Sexo);
                updateQuery.Parameters.Add(paramSexo);
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

           
        }

        public void DeletarUsuarioDB(int id)
        {
            try
            {

                IDbCommand deleteQuery = conexao.CreateCommand();
                deleteQuery.CommandText = $"Delete from Usuarios where Id = @id";

                IDbDataParameter paramId = new SqlParameter("id", id);
                deleteQuery.Parameters.Add(paramId);

                deleteQuery.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

        }
    }
}