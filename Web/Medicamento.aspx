<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medicamento.aspx.cs" Inherits="Web.Medicamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Stock Minimo"></asp:Label>
            <asp:TextBox ID="txtMinimo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Stock Máximo"></asp:Label>
            <asp:TextBox ID="txtMaximo" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <br />

            <asp:GridView ID="grdMedicamento" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="grdMedicamento_RowCancelingEdit" OnRowDeleting="grdMedicamento_RowDeleting" OnRowEditing="grdMedicamento_RowEditing" OnRowUpdating="grdMedicamento_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("Id_Medicamento") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Stock Minimio">
                        <ItemTemplate>
                            <asp:Label ID="lblMinimo" runat="server" Text='<%# Eval("Minimo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditMinimo" runat="server"  Text='<%#Eval ("Minimo") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stock Máximo">
                        <ItemTemplate>
                            <asp:Label ID="lblMaximo" runat="server" Text='<%# Eval("Maximo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditMaximo" runat="server"  Text='<%#Eval ("Maximo") %>'></asp:TextBox>
                        </EditItemTemplate>
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
