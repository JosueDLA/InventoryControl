<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Institucion.aspx.cs" Inherits="Web._1_Institucion"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>

            <asp:Label ID="Titulo" runat="server" Text="Ingresar Nueva Institucion"></asp:Label>
            <br/>

            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"  autocomplete="off"></asp:TextBox>
            <br/>

            <asp:Label ID="Label2" runat="server" Text="Ubicación"></asp:Label>
            <asp:TextBox ID="txtUbicacion" runat="server"  autocomplete="off"></asp:TextBox>
            <br/>

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />

            <br /><br /><br />

            <asp:GridView ID="grdInstitucion" runat="server" AutoGenerateColumns="False" OnRowEditing="grdInstitucion_RowEditing" OnRowUpdating="grdInstitucion_RowUpdating" OnRowCancelingEdit="grdInstitucion_RowCancelingEdit" OnRowDeleting="grdInstitucion_RowDeleting" >
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
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

                    <asp:TemplateField HeaderText="Ubicación">
                        <ItemTemplate>
                            <asp:Label ID="lblUbicacion" runat="server"  Text='<%# Eval("Ubicacion") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditUbicacion" runat="server"  Text='<%#Eval ("Ubicacion") %>'></asp:TextBox>
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
