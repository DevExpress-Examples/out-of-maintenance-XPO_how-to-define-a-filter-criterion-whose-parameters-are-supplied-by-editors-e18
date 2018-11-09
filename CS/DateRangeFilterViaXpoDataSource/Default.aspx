<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DateRangeFilterViaXpoDataSource._Default" %>

<%@ Register Assembly="DevExpress.Xpo.v13.1.Web, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Xpo" TagPrefix="dxxpo" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>How to define a filter criterion whose parameters are supplied by editors</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table><tr><td>
        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="From date:">
        </dxe:ASPxLabel></td><td>
        <dxe:ASPxDateEdit ID="deStartDate" runat="server" AutoPostBack="True">
        </dxe:ASPxDateEdit></td><td>
        <dxe:ASPxLabel ID="ASPxLabel2" runat="server" Text="To date:">
        </dxe:ASPxLabel></td><td>
        <dxe:ASPxDateEdit ID="deEndDate" runat="server" AutoPostBack="True">
        </dxe:ASPxDateEdit></td></tr></table>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
            AutoGenerateColumns="False" DataSourceID="XpoDataSource1" Width="437px">
            <Columns>
                <dxwgv:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataDateColumn FieldName="ShippedDate" VisibleIndex="1">
                </dxwgv:GridViewDataDateColumn>
                <dxwgv:GridViewDataTextColumn Caption="Customer Name" 
                    FieldName="Customer.CompanyName" VisibleIndex="2">
                </dxwgv:GridViewDataTextColumn>
            </Columns>
        </dxwgv:ASPxGridView>
        <dxxpo:XpoDataSource ID="XpoDataSource1" runat="server" 
            TypeName="Northwind.Order" 
            Criteria="[ShippedDate] &gt;= ? And [ShippedDate] &lt; ?">
            <CriteriaParameters>
                <asp:ControlParameter ControlID="deStartDate" Name="@StartDate" 
                    PropertyName="Value" />
                <asp:ControlParameter ControlID="deEndDate" Name="@EndDate" 
                    PropertyName="Value" />
            </CriteriaParameters>
        </dxxpo:XpoDataSource>
    </div>
    </form>
</body>
</html>
