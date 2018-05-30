<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm_Estab.aspx.cs" Inherits="WebForm_Estab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Estab. Cadastros</title>
            <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
            <link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
            <script src="js/jquery-3.3.1.min.js" type="text/javascript"></script>
            <script src="js/jquery.mask.min.js" type="text/javascript"></script>
            <script src="js/bootstrap.min.js" type="text/javascript"></script>
            <script src="js/bootstrap-notify.min.js" type="text/javascript"></script>
            <script src="js/jquery.validate.min.js" type="text/javascript"></script> 
            <script src="js/localization/messages_pt_BR.js" type="text/javascript"></script>
            
            <script type="text/javascript">

                jQuery.validator.addMethod("CNPJ", function (value, element) {

                    var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais;
                    if (value.length == 0) {
                        return false;
                    }

                    value = value.replace(/\D+/g, '');
                    digitos_iguais = 1;

                    for (i = 0; i < value.length - 1; i++)
                        if (value.charAt(i) != value.charAt(i + 1)) {
                            digitos_iguais = 0;
                            break;
                        }
                    if (digitos_iguais)
                        return false;

                    tamanho = value.length - 2;
                    numeros = value.substring(0, tamanho);
                    digitos = value.substring(tamanho);
                    soma = 0;
                    pos = tamanho - 7;
                    for (i = tamanho; i >= 1; i--) {
                        soma += numeros.charAt(tamanho - i) * pos--;
                        if (pos < 2)
                            pos = 9;
                    }
                    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                    if (resultado != digitos.charAt(0)) {
                        return false;
                    }
                    tamanho = tamanho + 1;
                    numeros = value.substring(0, tamanho);
                    soma = 0;
                    pos = tamanho - 7;
                    for (i = tamanho; i >= 1; i--) {
                        soma += numeros.charAt(tamanho - i) * pos--;
                        if (pos < 2)
                            pos = 9;
                    }

                    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;

                    return (resultado == digitos.charAt(1));
                }, "Por favor, forneça CNPJ válido.")

                $(document).ready(function () {
                    $('#txt_data').mask('00/00/0000');
                    $('#txt_cnpj').mask('00.000.000/0000-00');
                    $('#txt_agenciaconta').mask('000-0/00.000-0');
                    $('#txt_telefone').mask('(00) 00000-0000');
                    $("#form1").validate({
                        rules: {
                            txt_razao: {
                                required: true
                            },
                            txt_cnpj: {
                                CNPJ: true,
                                required: true
                            },
                            txt_email: {
                                email: true
                            },
                            txt_telefone: {
                                required: true
                            },
                            txt_data: {
                                dateITA: true,
                                required: true
                            }
                        }
                    })
                })
            </script>

</head>
<body>
        <div class="container">
            <form id="form1" runat="server">
                <h1><b>Estab. Cadastros</b></h1>
                <div class="form=group">
                     <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                </div><br />
                <div class="form=group">
                     <label>Razão Social</label><asp:TextBox ID="txt_razao" runat="server" Width="302px" placeholder="Razão Social" Class="form-control"></asp:TextBox>
                </div>
                <div class="form=group">
                     <label>Nome Fantasia</label><asp:TextBox ID="txt_fantasia" runat="server" Width="243px" placeholder="Nome Fantasia" Class="form-control"></asp:TextBox>
                </div>
                <div class="form=group">
                     <label>CNPJ</label><asp:TextBox ID="txt_cnpj" runat="server" Width="190px" placeholder="00.000.000/0000-00" Class="form-control"></asp:TextBox>
                </div>
                <div class="form=group">
                     <label>E-mail</label><asp:TextBox ID="txt_email" runat="server" Width="247px" placeholder="E-mail" Class="form-control"></asp:TextBox>
                </div>
                <div class="form=group">
                     <label>Endereço</label><asp:TextBox ID="txt_endereco" runat="server" Width="314px" placeholder="Endereço" Class="form-control"></asp:TextBox>
                </div>
                <div class="form=group">
                     <label>Cidade</label><asp:TextBox ID="txt_cidade" runat="server" Width="213px" placeholder="Cidade" Class="form-control"></asp:TextBox>
                </div>
                <div class="form=group">
                     <label>Estado</label><asp:DropDownList ID="dwl_estado" runat="server" Width="135px" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="ESTADO" DataValueField="id_ESTADO" Class="form-control"></asp:DropDownList>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id_ESTADO], [ESTADO] FROM [ESTADO_ESTAB]"></asp:SqlDataSource>
                </div>
                <div class="form=group">
                     <label>Telefone</label><asp:TextBox ID="txt_telefone" runat="server" Width="165px" placeholder="Telefone" Class="form-control"></asp:TextBox>
                </div>
                <div class="form=group">
                     <label>Agência e Conta</label><asp:TextBox ID="txt_agenciaconta" runat="server" Width="176px" placeholder="000-0/00.000-0" Class="form-control"></asp:TextBox>
                </div>
                <div class="form=group">
                     <label>Data de Cadastro</label><asp:TextBox ID="txt_data" runat="server" Width="176px" placeholder="00/00/0000" Class="form-control"></asp:TextBox>
                </div>
                <div class="form=group">
                     <label>Categoria</label><asp:DropDownList ID="dwl_categoria" runat="server" Width="135px" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="CATEGORIAS" DataValueField="id_CATEGORIA" Class="form-control"></asp:DropDownList>
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id_CATEGORIA], [CATEGORIAS] FROM [CATEGORIA_ESTAB]"></asp:SqlDataSource>
                </div>
                <div class="form=group">
                     <label>Status</label><asp:DropDownList ID="dwl_status" runat="server" Width="135px" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="STATUS" DataValueField="id_STATUS" Class="form-control"></asp:DropDownList>
                     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id_STATUS], [STATUS] FROM [STATUS_ESTAB]"></asp:SqlDataSource>
                </div><br />
                <div class="form=group">
                     <label>Código</label><br /><asp:TextBox ID="txt_codigo" runat="server" Width="40px" Enabled="false" class="form-control"></asp:TextBox>
                </div><br />
                <div class="form=group">
                <asp:Button ID="Cadastrar" runat="server" Text="Cadastrar" OnClick="btn_cadastrar_Click" Width="110px" Class="btn btn-primary"/>
                <asp:Button ID="btn_alterar" runat="server" Text="Alterar" Width="110px" OnClick="btn_alterar_Click" Class="btn btn-success" />
                <asp:Button ID="Excluir" runat="server" Text="Excluir" OnClientClick="return confirm('Confirmar a exclusão.');" OnClick="Excluir_Click" Width="110px" Class="btn btn-danger"/>
             </div><br />

                    <asp:GridView ID="GridView_Estab" runat="server" class="table table-striped" Width="190px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_Estab_SelectedIndexChanged" AllowPaging="True" PageSize="100" OnPageIndexChanging="GridView_Estab_PageIndexChanging" EmptyDataText="Nenhum registro encontrado." CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Img/ExLupa.png" ShowSelectButton="True">
                            <ControlStyle Height="16px" Width="16px" />
                            </asp:CommandField>
                            <asp:BoundField DataField="id_ESTAB" HeaderText="CÓDIGO" />
                            <asp:BoundField DataField="RAZAO" HeaderText="RAZÃO SOCIAL" />
                            <asp:BoundField DataField="FANTASIA" HeaderText="NOME FANTASIA" />
                            <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" />
                            <asp:BoundField DataField="EMAIL" HeaderText="E-MAIL" />
                            <asp:BoundField DataField="ENDERECO" HeaderText="ENDEREÇO" />
                            <asp:BoundField DataField="CIDADE" HeaderText="CIDADE" />
                            <asp:BoundField DataField="TELEFONE" HeaderText="TELEFONE" />
                            <asp:BoundField DataField="AGENCIACONTA" HeaderText="AGÊNCIA E CONTA" />
                            <asp:BoundField DataField="DATA" HeaderText="DATA DE CADASTRO" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
        </form>
        </div>
 </body>
</html>