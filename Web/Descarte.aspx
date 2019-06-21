<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Descarte.aspx.cs" Inherits="Web.Descarte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Titulo" runat="server" Text="Ingresar Nuevo Descarte"></asp:Label>
            
            <asp:Label ID="lblFecha" runat="server" Text="Fecha: "></asp:Label>
            <asp:TextBox ID="txtFecha" runat="server" type="date"></asp:TextBox>
            <br />

            <asp:Label ID="lblBodegaOrigen" runat="server" Text="Id Bodega Origen: "></asp:Label>
            <asp:DropDownList ID="ddlBodegaOrigen" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
            <asp:GridView ID="grdDescarteDetalle" runat="server" AutoGenerateColumns="false" OnRowDeleting="grdDescarteDetalle_RowDeleting" ShowFooter="true">
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

                    <asp:TemplateField HeaderText="Lote">
                        <ItemTemplate>
                            <asp:Label ID="lblLote" runat="server" Text='<%# Eval("Lote") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlInsertLote" runat="server">
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

                    <asp:TemplateField HeaderText="Motivo">
                        <ItemTemplate>
                            <asp:Label ID="lblMotivo" runat="server"  Text='<%# Eval("Motivo") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID ="txtInsertMotivo" runat="server"></asp:TextBox>
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
