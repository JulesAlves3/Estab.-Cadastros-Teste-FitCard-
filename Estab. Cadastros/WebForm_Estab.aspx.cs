using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class WebForm_Estab : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CarregaEstab();
        }
    }
    protected void btn_cadastrar_Click(object sender, EventArgs e)
    {
        try
        {
            new Estab().Cadastrar(txt_razao.Text, txt_fantasia.Text, txt_cnpj.Text, txt_email.Text, txt_endereco.Text, txt_cidade.Text, dwl_estado.SelectedIndex, txt_telefone.Text, txt_agenciaconta.Text, txt_data.Text, dwl_categoria.SelectedIndex, dwl_status.SelectedIndex);
            CarregaEstab();
        }
        catch (Exception erx)
        {
            lbl_msg.Text = "Erro ao Cadastrar." + erx.ToString();
        }
    }

    void CarregaEstab()
    {
        GridView_Estab.DataSource = new Classe_Funções().AbrirTabela("SELECT * FROM DADOS_ESTAB");
        GridView_Estab.DataBind();
        txt_codigo.Text = "";
        txt_razao.Text = "";
        txt_fantasia.Text = "";
        txt_cnpj.Text = "";
        txt_email.Text = "";
        txt_endereco.Text = "";
        txt_cidade.Text = "";
        txt_telefone.Text = "";
        txt_agenciaconta.Text = "";
        txt_data.Text = "";

    }

    protected void GridView_Estab_SelectedIndexChanged(object sender, EventArgs e)
    {
        Estab estab = new Estab(GridView_Estab.SelectedRow.Cells[1].Text);
        txt_codigo.Text = estab.Codigo;
        txt_razao.Text = estab.Razão_Social;
        txt_fantasia.Text = estab.Nome_Fantasia;
        txt_cnpj.Text = estab.Cnpj;
        txt_email.Text = estab.Email;
        txt_endereco.Text = estab.Endereço;
        txt_cidade.Text = estab.Cidade;
        txt_telefone.Text = estab.Telefone;
        txt_agenciaconta.Text = estab.Agencia_e_Conta;
        dwl_estado.SelectedIndex = estab.Estado;
        dwl_categoria.SelectedIndex = estab.Categoria;
        dwl_status.SelectedIndex = estab.Status;
        txt_data.Text = estab.Data_de_Cadastro;
    }

    protected void Excluir_Click(object sender, EventArgs e)
    {
        try
        {
            new Estab().Excluir(txt_codigo.Text);
            CarregaEstab();
        }
        catch (Exception erx)
        {
            lbl_msg.Text = "Erro ao excluir. " + erx.Message;
        }

    }

    protected void GridView_Estab_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_Estab.PageIndex = e.NewPageIndex;
        CarregaEstab();
    }

    protected void btn_alterar_Click(object sender, EventArgs e)
    {
        Estab estab = new Estab();
        estab.Codigo = txt_codigo.Text;
        estab.Razão_Social = txt_razao.Text;
        estab.Nome_Fantasia = txt_fantasia.Text;
        estab.Cnpj = txt_cnpj.Text;
        estab.Email = txt_email.Text;
        estab.Endereço = txt_endereco.Text;
        estab.Cidade = txt_cidade.Text;
        estab.Telefone = txt_telefone.Text;
        estab.Agencia_e_Conta = txt_agenciaconta.Text;
        estab.Estado = dwl_estado.SelectedIndex;
        estab.Categoria = dwl_categoria.SelectedIndex;
        estab.Status = dwl_status.SelectedIndex;
        estab.Data_de_Cadastro = txt_data.Text;
        estab.Alterar();
        CarregaEstab();
    }
}