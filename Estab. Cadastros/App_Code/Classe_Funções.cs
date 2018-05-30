using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class Classe_Funções
{
    public string conexao = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jules Alves\source\repos\Estab. Cadastros\Estab. Cadastros\App_Data\DB_ESTAB.mdf;Integrated Security = True");

    /// <summary>
    /// Método para retornar um DataSet conforme sql passado por parâmetro.
    /// </summary>
    /// <param name="sqltxt">comando sql para carregar dataset</param>
    /// <returns></returns>
    public DataSet AbrirTabela(string sqltxt)
    {
        SqlConnection cnx = new SqlConnection(conexao);
        cnx.Open();
        SqlDataAdapter adp = new SqlDataAdapter(sqltxt, cnx);
        DataSet dst = new DataSet();
        adp.Fill(dst);
        return dst;
    }

    public SqlConnection Conexao()
    {
        SqlConnection cnx = new SqlConnection(conexao);
        cnx.Open();
        return cnx;
    }
}