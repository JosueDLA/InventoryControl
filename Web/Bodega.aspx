<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bodega.aspx.cs" Inherits="Web.Bodega" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Titulo" runat="server" Text="Ingresar Nueva Bodega"></asp:Label>
            <br/>

            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"  autocomplete="off"></asp:TextBox>
            <br/>

            <asp:Label ID="Label2" runat="server" Text="Principal"></asp:Label>
            <asp:DropDownList ID="ddlPrincipal" runat="server">
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="1">Si</asp:ListItem>
            </asp:DropDownList>
            <br/>

            <asp:Label ID="Label3" runat="server" Text="Bodega Superior"></asp:Label>
            <asp:DropDownList ID="ddlBodegaS" runat="server">
            </asp:DropDownList>
            <br/>

            <asp:Label ID="Label4" runat="server" Text="Institucion"></asp:Label>
            <asp:DropDownList ID="ddlInstitucion" runat="server">
            </asp:DropDownList>
            <br/>

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" style="height: 26px" />

            <br /><br />
            <asp:GridView ID="grdBodega" runat="server" AutoGenerateColumns="false" OnRowEditing="grdBodega_RowEditing" OnRowUpdating="grdBodega_RowUpdating" OnRowCancelingEdit="grdBodega_RowCancelingEdit" OnRowDeleting="grdBodega_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("Id_Bodega") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditNombre" runat="server"  Text='<%#Eval ("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Principal">
                        <ItemTemplate>
                            <asp:Label ID="lblPrincipal" runat="server" Text='<%# Eval("Principal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bodega Superior">
                        <ItemTemplate>
                            <asp:Label ID="lblIdBodegaS" runat="server" Text='<%# Eval("Id_Bodega_Superior") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Institucion">
                        <ItemTemplate>
                            <asp:Label ID="lblInstitucion" runat="server" Text='<%# Eval("Institucion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Edit">Editar</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnActualizar" runat="server" Text="Aceptar" CommandName="Update" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CommandName="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="Delete">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <br />

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
