<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Partizan.aspx.cs" Inherits="WebApplication1.Account.Partizan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h3>Statistika igrača KK Partizana u Euroligi sezona 2023/24</h3>
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table">
    </asp:GridView>
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Legenda:" ForeColor="DimGray"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="AvgPts:Prosečan broj poena igrača na utakmici" ForeColor="DimGray"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="AvgAst:Prosečan broj asistencija igrača na utakmici" ForeColor="DimGray"></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="AvgReb:Prosečan broj skokova igrača na utakmici" ForeColor="DimGray"></asp:Label>
    <br />
    <asp:Label ID="Label9" runat="server" Text="AvgPIR:Prosečan indeks korisnosti igrača na utakmici" ForeColor="DimGray"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Pozicije:" ForeColor="DimGray"></asp:Label>
    <br />
    <asp:Label ID="Label6" runat="server" Text="F:Forward" ForeColor="DimGray"></asp:Label>
    <br />
    <asp:Label ID="Label7" runat="server" Text="G:Guard" ForeColor="DimGray"></asp:Label>
    <br />
    <asp:Label ID="Label8" runat="server" Text="C:Center" ForeColor="DimGray"></asp:Label>
    <br />
    <asp:Label ID="Label10" runat="server" Text="Podatci preuzieti sa oficijalnog sajta EuroLige" ForeColor="DimGray"></asp:Label>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
</asp:Content>
