<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lote.aspx.cs" Inherits="Web.Lote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grdLote" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lblIdLote" runat="server" Text='<%# Eval("Id_Lote") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ID Entrada">
                        <ItemTemplate>
                            <asp:Label ID="lblIdEntradaDetalle" runat="server" Text='<%# Eval("Id_Entrada_Detalle") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Medicamento">
                        <ItemTemplate>
                            <asp:Label ID="lblMedicamento" runat="server" Text='<%# Eval("Medicamento") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad Actual">
                        <ItemTemplate>
                            <asp:Label ID="lblCantidadActual" runat="server" Text='<%# Eval("Cantidad_Actual") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:Label ID="lblPrecioUnitario" runat="server" Text='<%# Eval("Precio_Unitario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de Vencimiento">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text='<%# Eval("Fecha_Vencimiento") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bodega">
                        <ItemTemplate>
                            <asp:Label ID="lblBodega" runat="server" Text='<%# Eval("Bodega") %>'></asp:Label>
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
