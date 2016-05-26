<%@ Page Language="C#" MasterPageFile="~/BaseMaster.master" AutoEventWireup="true" CodeBehind="PageShop.aspx.cs" Inherits="Coffee.PageShop" Title="Untitled Page" %>

<%@ Reference Control="ProductDisplay.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="SiteStyle.css" rel="stylesheet" type="text/css" />
    <script lang="javascript" src="Scripts/jquery-1.7.1.min.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">

    <div class="main">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <%-- 大图 --%>
        <asp:Image ID="Image1" ImageUrl="Images/Shop_bg.jpg" Width="100%" Height="600px" runat="server" />

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <%-- 类别选择按钮栏 --%>
                <nav id="menu">
                    <div class="menuContainer">
                        <div id="div_all" class="menuItem">
                            <asp:ImageButton ID="ibtn_all" runat="server" ImageUrl="/Images/All.jpg" OnClick="ibtn_filter_Click" onmouseout="ChangeImage(this,'Images/Espressos.jpg')" onmouseover="ChangeImage(this,'/Images/TeaLattes.jpg')" />
                        </div>
                        <div class="menuItem">
                            <asp:ImageButton ID="ibtn_espressos" runat="server" ImageUrl="Images/Espressos.jpg" OnClick="ibtn_filter_Click" />
                        </div>
                        <div class="menuItem">
                            <asp:ImageButton ID="ibtn_lattes" runat="server" ImageUrl="/Images/Lattes.jpg" OnClick="ibtn_filter_Click" />
                        </div>
                        <div class="menuItem">
                            <asp:ImageButton ID="ibtn_tealattes" runat="server" ImageUrl="/Images/TeaLattes.jpg" OnClick="ibtn_filter_Click" />
                        </div>
                        <div class="menuItem">
                            <asp:ImageButton ID="ibtn_hotchocolates" runat="server" ImageUrl="/Images/HotChocolates.jpg" OnClick="ibtn_filter_Click" />
                        </div>
                        <div class="menuItem">
                            <asp:ImageButton ID="ibtn_blended" runat="server" ImageUrl="/Images/Blended.jpg" OnClick="ibtn_filter_Click" />
                        </div>
                    </div>
                </nav>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <%-- 下拉框选择及排序按钮 --%>
                    <div class="selectContainer">
                        <%-- 下拉框 --%>
                        <div class="selectDropdown">
                            <%-- 设置AutoPostBack以便改变选择项时就执行查询 --%>
                            <asp:DropDownList ID="dl_select" runat="server" Width="150px" Height="30px" Font-Size="15"
                                OnSelectedIndexChanged="dl_select_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="Calories" Selected="True"> Calories</asp:ListItem>
                                <asp:ListItem Value="Fat">Fat</asp:ListItem>
                                <asp:ListItem Value="Saturated Fat">Saturated Fat</asp:ListItem>
                                <asp:ListItem Value="Trans Fat">Trans Fat</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%-- 排序按钮栏 --%>
                        <div class="selectsortmethod">
                            <asp:ImageButton ID="ibtn_sort_desc" runat="server" Width="40" Height="40"
                                OnClick="ibtn_sort_Click"  ImageUrl="Images/ibtn_desc_normal.jpg"></asp:ImageButton>
                            <asp:ImageButton ID="ibtn_sort_asc" runat="server" Width="40" Height="40"
                                OnClick="ibtn_sort_Click" ImageUrl="Images/ibtn_asc_normal.jpg"></asp:ImageButton>
                        </div>
                    </div>

                    <%-- 商品显示区域，DataList实现 --%>
                    <div class="productTable">
                        <%-- 显示商品，只刷新显示部分DataList_Products--%>
                        <asp:DataList ID="DataList_Products" runat="server" Height="600px" ItemStyle-VerticalAlign="Top"
                            RepeatColumns="5" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <table border="0" cellpadding="15" cellspacing="0">
                                    <tr>
                                        <td align="center" valign="middle">
                                            <a href='PageProductDetails.aspx?ProductId=<%# DataBinder.Eval(Container.DataItem, "C_id")%> '>
                                                <img alt="img" height="180" src='<%# DataBinder.Eval(Container.DataItem, "C_image")%>'
                                                    width="100" /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="width: 150px; height: 22px;">
                                            <a href='PageProductDetails.aspx?ProductId=<%# DataBinder.Eval(Container.DataItem, "C_id")%> '>
                                                <%# DataBinder.Eval(Container.DataItem, "C_name")%></a>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>

</asp:Content>
