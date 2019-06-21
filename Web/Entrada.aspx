<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="Web.Entrada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="Titulo" runat="server" Text="Ingresar Nueva Entrada"></asp:Label>
            
            <asp:Label ID="lblFecha" runat="server" Text="Fecha: "></asp:Label>
            <asp:TextBox ID="txtFecha" runat="server" type="date"></asp:TextBox>
            <br />
            <asp:Label ID="lblId_Institucion" runat="server" Text="Institucion: "></asp:Label> 
            <asp:DropDownList ID="ddlIdInstitucion" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblProveedor" runat="server" Text="Proveedor: "></asp:Label>
            <asp:DropDownList ID="ddlIdProveedor" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="grdEntradaDetalle" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ShowFooter="true" OnRowDeleting="grdEntradaDetalle_RowDeleting" >
                <Columns>
                    <asp:TemplateField HeaderText="Medicamento">
                        <ItemTemplate>
                            <asp:Label ID="lblMedicamento" runat="server" Text='<%# Eval("Medicamento") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlInsertMedicamento" runat="server">
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Label ID="lblCantidad" runat="server"  Text='<%# Eval("Cantidad") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID ="txtInsertCantidad" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:Label ID="lblPrecio" runat="server"  Text='<%# Eval("Precio") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID ="txtInsertPrecio" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de Vencimiento">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server"  Text='<%# Eval("Fecha") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID ="txtInsertFecha" runat="server" type="date"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="Delete">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnInsertar" runat="server" Text="Ingresar" OnClick="btnInsertar_Click"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <a href="Bodega.aspx">Bodega</a><br />
            <a href="Descarte.aspx">Descarte</a><br />
            <a href="Devolucion.aspx">Devolucion</a><br />
            <a href="Entrada.aspx">Entrada</a><br />
            <a href="Institucion.aspx">Institucion</a><br />
            <a href="Lote.aspx">Lote</a><br />
            <a href="Medicamento.aspx">Medicamento</a><br />
            <a href="Proveedor.aspx">Proveedor</a><br />
            <a href="Salida.aspx">Salida</a><br />

        </div>
    </form>
</body>
</html>
