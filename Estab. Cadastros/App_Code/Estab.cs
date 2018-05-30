using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descrição resumida de Estab
/// </summary>
public class Estab
{
    public string Codigo { get; set; }
    public string Razão_Social { get; set; }
    public string Nome_Fantasia { get; set; }
    public string Cnpj { get; set; }
    public string Email { get; set; }
    public string Endereço { get; set; }
    public string Cidade { get; set; }
    public int Estado { get; set; }
    public string Telefone { get; set; }
    public string Agencia_e_Conta { get; set; }
    public string Data_de_Cadastro { get; set; }
    public int Categoria { get; set; }
    public int Status { get; set; }
    public Estab()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }

    public void Cadastrar(string _razao, string _fantasia, string _cnpj, string _email, string _endereco, string _cidade, int _estado, string _telefone, string _agenciaconta, string _datacadastro, int _categoria, int _status)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DADOS_ESTAB(RAZAO,FANTASIA,CNPJ,EMAIL,ENDERECO,CIDADE,TELEFONE,AGENCIACONTA,Id_ESTADO,Id_CATEGORIA,Id_STATUS,DATA) VALUES (@RAZAO,@FANTASIA,@CNPJ,@EMAIL,@ENDERECO,@CIDADE,@TELEFONE,@AGENCIACONTA,@ESTADO,@CATEGORIA,@STATUS,@DATA)", new Classe_Funções().Conexao());
            cmd.Parameters.AddWithValue("@RAZAO", _razao);
            cmd.Parameters.AddWithValue("@FANTASIA", _fantasia);
            cmd.Parameters.AddWithValue("@CNPJ", _cnpj);
            cmd.Parameters.AddWithValue("@EMAIL", _email);
            cmd.Parameters.AddWithValue("@ENDERECO", _endereco);
            cmd.Parameters.AddWithValue("@CIDADE", _cidade);
            cmd.Parameters.AddWithValue("@ESTADO", _estado);
            cmd.Parameters.AddWithValue("@TELEFONE", _telefone);
            cmd.Parameters.AddWithValue("@AGENCIACONTA", _agenciaconta);
            cmd.Parameters.AddWithValue("@CATEGORIA", _categoria);
            cmd.Parameters.AddWithValue("@STATUS", _status);
            cmd.Parameters.AddWithValue("@DATA", _datacadastro);
            cmd.ExecuteNonQuery();
        }
        catch (Exception erx)
        {
            throw new Exception(erx.ToString());
        }
    }


    public Estab(string _codestab)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM DADOS_ESTAB WHERE id_ESTAB=@COD", new Classe_Funções().Conexao());
        cmd.Parameters.AddWithValue("@COD", _codestab);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        while (dr.Read())
        {
            Codigo = dr["id_ESTAB"].ToString();
            Razão_Social = dr["RAZAO"].ToString();
            Nome_Fantasia = dr["FANTASIA"].ToString();
            Cnpj = dr["CNPJ"].ToString();
            Email = dr["EMAIL"].ToString();
            Endereço = dr["ENDERECO"].ToString();
            Cidade = dr["CIDADE"].ToString();
            Telefone = dr["TELEFONE"].ToString();
            Agencia_e_Conta = dr["AGENCIACONTA"].ToString();
            Estado = dr["Id_ESTADO"].GetHashCode();
            Categoria = dr["Id_CATEGORIA"].GetHashCode();
            Status = dr["Id_STATUS"].GetHashCode();
            Data_de_Cadastro = dr["DATA"].ToString();
        }
    }

    public void Excluir(string _codestab)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM DADOS_ESTAB WHERE id_ESTAB=@COD", new Classe_Funções().Conexao());
        cmd.Parameters.AddWithValue("@COD", _codestab);
        cmd.ExecuteNonQuery();
    }

    public void Alterar()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("UPDATE DADOS_ESTAB SET RAZAO=@RAZAO,FANTASIA=@FANTASIA,CNPJ=@CNPJ,EMAIL=@EMAIL,ENDERECO=@ENDERECO,CIDADE=@CIDADE,TELEFONE=@TELEFONE,AGENCIACONTA=@AGENCIACONTA,Id_ESTADO=@ESTADO,Id_CATEGORIA=@CATEGORIA,Id_STATUS=@STATUS,DATA=@DATA WHERE Id_ESTAB=@COD", new Classe_Funções().Conexao());
            cmd.Parameters.AddWithValue("@COD", Codigo);
            cmd.Parameters.AddWithValue("@RAZAO", Razão_Social);
            cmd.Parameters.AddWithValue("@FANTASIA", Nome_Fantasia);
            cmd.Parameters.AddWithValue("@CNPJ", Cnpj);
            cmd.Parameters.AddWithValue("@EMAIL", Email);
            cmd.Parameters.AddWithValue("@ENDERECO", Endereço);
            cmd.Parameters.AddWithValue("@CIDADE", Cidade);
            cmd.Parameters.AddWithValue("@TELEFONE", Telefone);
            cmd.Parameters.AddWithValue("@AGENCIACONTA", Agencia_e_Conta);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@CATEGORIA", Categoria);
            cmd.Parameters.AddWithValue("@STATUS", Status);
            cmd.Parameters.AddWithValue("@DATA", Data_de_Cadastro);
            cmd.ExecuteNonQuery();
        }
        catch (Exception erx)
        {
            throw new Exception(erx.ToString());
        }
    }
}