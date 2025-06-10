<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos Gestion.aspx.cs" Inherits="Sistema_de_Gestión_de_Inventario.Paginas.Productos_Gestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestion de Productos</title>
    <link href="Estilos.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <h1 class="titulos">Gestion de Productos</h1>
            <br />
            <asp:Label runat="server" CssClass="sub-titulos" ID="lblMensajePrincipal">Agrega Un Producto</asp:Label>
            <br />
            <br />
            <asp:Label runat="server" CssClass="sub-titulos" Visible="false" ID="lblID"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtID" CssClass="campos" Visible="false"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" CssClass="sub-titulos">Escribe el Nombre</asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtNombre" CssClass="campos"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" CssClass="sub-titulos">Escribe una Descripcion</asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="campos"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" CssClass="sub-titulos">Escribe el Precio</asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtPrecio" CssClass="campos"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" CssClass="sub-titulos">Escribe la Cantidad</asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtCantidad" CssClass="campos"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" CssClass="sub-titulos">Selecciona Una Categoria</asp:Label>
            <br />
            <asp:DropDownList runat="server" ID="ddlCategoria" AutoPostBack="true" CssClass="listas"></asp:DropDownList>
            <br />
            <br />
            <asp:Label runat="server" CssClass="sub-titulos">Selecciona Un Proveedor</asp:Label>
            <br />
            <asp:DropDownList runat="server" ID="ddlProveedor" AutoPostBack="true" CssClass="listas"></asp:DropDownList>
            <br />
            <asp:Button runat="server" ID="btnAgregar" Text="Agregar Producto" OnClick="btnAgregar_Click" CssClass="botones" />
            <asp:Button runat="server" ID="btnEditar" Text="Editar Producto" OnClick="btnEditar_Click" CssClass="botones" Visible="false" />
            <br />
            <br />
            <br />
            <div class="sub-contenedor">
                <asp:Label runat="server" CssClass="sub-titulos">Selecciona Una Categoria</asp:Label>
                <br />
                <asp:DropDownList runat="server" ID="ddlFiltro" AutoPostBack="true" CssClass="listas"></asp:DropDownList>
                <asp:Button runat="server" ID="btnFiltro" Text="Filtrar" OnClick="btnFiltro_Click" CssClass="botones" />
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
                                    CommandName="eliminar" CommandArgument='<%#Eval("id") %>' ID="btnEliminar"
                                    CssClass="botones" />
                            </td>
                            <td>
                                <asp:Button runat="server" Text="Modificar"
                                    CommandName="modificar" CommandArgument='<%#Eval("id") %>' ID="btnModificar"
                                    CssClass="botones" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </form>
</body>
</html>
