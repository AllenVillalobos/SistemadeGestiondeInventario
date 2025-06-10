<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos Gestion.aspx.cs" Inherits="Sistema_de_Gestión_de_Inventario.Paginas.Productos_Gestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Gestion de Productos</h1>
            <br />
            <asp:Label runat="server">Agrega Un Producto</asp:Label>
            <br />
            <br />
            <asp:Label runat="server">Escribe el Nombre</asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">Escribe una Descripcion</asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtDescripcion"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">Escribe el Precio</asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtPrecio"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">Escribe la Cantidad</asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtCantidad"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">Selecciona Una Categoria</asp:Label>
            <br />
            <asp:DropDownList runat="server" ID="ddlCategoria" AutoPostBack="true"></asp:DropDownList>
            <br />
            <br />
            <asp:Label runat="server">Selecciona Un Proveedor</asp:Label>
            <br />
            <asp:DropDownList runat="server" ID="ddlProveedor" AutoPostBack="true"></asp:DropDownList>
            <br />
            <asp:Button runat="server" ID="btnAgregar" Text="Agregar Producto" OnClick="btnAgregar_Click" />
            <br />
            <br />
            <br />
            <div>
                <asp:Label runat="server">Selecciona Una Categoria</asp:Label>
                <br />
                <asp:DropDownList runat="server" ID="ddlFiltro" AutoPostBack="true"></asp:DropDownList>
                <asp:Button runat="server" ID="btnFiltro" Text="Filtrar" OnClick="btnFiltro_Click"/>
                <br />
                <asp:ListView runat="server" ID="lvProductos" OnItemCommand="lvProductos_ItemCommand">
                    <LayoutTemplate>
                        <table>
                            <tr>
                                <th>ID
                                </th>
                                <th>Nombre
                                </th>
                                <th>Descripcion
                                </th>
                                <th>Precio
                                </th>
                                <th>Cantidad
                                </th>
                                <th>Categoria
                                </th>
                                <th>Proveedor
                                </th>
                                <th>Eliminar
                                </th>
                                <th>Modificar
                                </th>
                            </tr>
                            <tr>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("id") %></td>
                            <td><%#Eval("nombre") %></td>
                            <td><%#Eval("descripcion") %></td>
                            <td><%#Eval("precio") %></td>
                            <td><%#Eval("cantidad") %></td>
                            <td><%#Eval("categoria.nombre") %></td>
                            <td><%#Eval("proveedor.nombre") %></td>
                            <td>
                                <asp:Button runat="server" Text="Eliminar"
                                    CommandName="eliminar" CommandArgument='<%#Eval("id") %>' ID="btnEliminar" />
                            </td>
                            <td>
                                <asp:Button runat="server" Text="Modificar"
                                    CommandName="modificar" CommandArgument='<%#Eval("id") %>' ID="btnModificar" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </form>
</body>
</html>
