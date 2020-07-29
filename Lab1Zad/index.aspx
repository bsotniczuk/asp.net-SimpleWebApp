<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Lab1Zad.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="CSS/ekran_obrazow.css" rel="stylesheet" />
    <link href="CSS/ekran_logowania.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel ID="panel_logowania" runat="server" CssClass="logowanie" Visible="true">

            <div class="tabela_pozycja" runat="server">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">Podaj imie i nazwisko</td>
                    </tr>
                    <tr>
                        <td class="pole_do_wpisywania">
                            <asp:TextBox ID="TextBoxUserName" runat="server" Width="50%"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Button ID="Button1" runat="server" Height="15%" OnClick="Button1_Click" Text="Zarejestruj" Width="40%" Font-Size="8pt" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Size="8pt" Width="80%"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="Identyfikator nie jest zgodny ze wzorcem." ValidationExpression="^[A-Z-ŻŹĆĄŚĘŁÓŃ][a-z-żźćńółęąś][a-z-żźćńółęąś]+ [A-Z-ŻŹĆĄŚĘŁÓŃ][a-z-żźćńółęąś][a-z-żźćńółęąś]+$" Font-Size="0pt"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="Nie wprowadzono żadnej wartości." Font-Size="0pt"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Użytkownik jest zalogowany." OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="TextBoxUserName" Font-Size="0pt"></asp:CustomValidator>
                        </td>
                    </tr>
                </table>
            </div>

        </asp:Panel>

        <div class="whole" id="whole_1" visible="false" runat="server">
            <div class="column_side">

                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Blue" Text="Nazwa Użytkownika:"></asp:Label>
                <br />

                <asp:Label ID="zalogowany_uzytkownik" runat="server" Text="Label" ForeColor="Red" Font-Bold="True" Width="100%"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Blue" Text="Lista Użytkowników:"></asp:Label>
                <br />

                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ForeColor="#0066FF" DataSourceID="SqlDataSource2" DataTextField="Nazwa_Uzytkownika" DataValueField="Nazwa_Uzytkownika">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Nazwa_Uzytkownika] FROM [Globalne]"></asp:SqlDataSource>
                <br />

                <br />
                <asp:DetailsView ID="DetailsView1" runat="server" OnPageIndexChanging="DetailsView1_PageIndexChanging" Width="100%" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="5px" CellPadding="5" CellSpacing="2" EnableModelValidation="True" Font-Size="8pt" AutoGenerateRows="False" DataSourceID="SqlDataSource4">
                    <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <Fields>
                        <asp:BoundField DataField="Data_Uruchomienia" HeaderText="Data Uruchomienia" SortExpression="Data_Uruchomienia" />
                        <asp:BoundField DataField="Godzina_Uruchomienia" HeaderText="Godzina Uruchomienia" SortExpression="Godzina_Uruchomienia" />
                        <asp:BoundField DataField="ile_razy_uruchomil" HeaderText="Ile Razy Uruchomił" SortExpression="ile_razy_uruchomil" />
                        <asp:BoundField DataField="klikniecia_przycisk" HeaderText="Ile Zmian Przycisk" SortExpression="klikniecia_przycisk" />
                        <asp:BoundField DataField="klikniecia_obraz" HeaderText="Ile Zmian Rysunek" SortExpression="klikniecia_obraz" />
                        <asp:BoundField DataField="Ilu_uzytkownikow" HeaderText="Ilu Aktywnych Użytkowników" SortExpression="Ilu_uzytkownikow" />
                        <asp:BoundField DataField="ilu_zarejestrowanych" HeaderText="Ilu Zarejestrowanych Użytkowników" SortExpression="ilu_zarejestrowanych" />
                    </Fields>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                </asp:DetailsView>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Data_Uruchomienia], [Godzina_Uruchomienia], [ile_razy_uruchomil], [klikniecia_przycisk], [klikniecia_obraz], [Ilu_uzytkownikow], [ilu_zarejestrowanych] FROM [Globalne]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Data_Uruchomienia], [Godzina_Uruchomienia], [ile_razy_uruchomil], [klikniecia_przycisk], [klikniecia_obraz], [Ilu_uzytkownikow], [ilu_zarejestrowanych] FROM [Globalne] WHERE ([Nazwa_Uzytkownika] = @Nazwa_Uzytkownika)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="Nazwa_Uzytkownika" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Data_Uruchomienia], [Godzina_Uruchomienia], [ile_razy_uruchomil], [klikniecia_przycisk], [klikniecia_obraz], [Ilu_uzytkownikow], [ilu_zarejestrowanych] FROM [Globalne] WHERE ([Id_uzytkownika] = @Id_uzytkownika)">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="Id_uzytkownika" SessionField="ID_wyswietlane" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Data_Uruchomienia], [Godzina_Uruchomienia], [ile_razy_uruchomil], [klikniecia_przycisk], [klikniecia_obraz], [Ilu_uzytkownikow], [ilu_zarejestrowanych] FROM [Globalne]"></asp:SqlDataSource>
                <br />
                <asp:Label ID="label_ilosc_wcisniec" runat="server" Text="Label" Font-Size="10pt"></asp:Label>
                <br />

            </div>
            <div class="column_middle">
                <div class="owieczka_whole">
                    <div class="middle">
                        <asp:Button class="przelacz_rysunek"
                            Text="Przełącz Rysunek"
                            OnClick="SubmitBtn_Click"
                            runat="server" Font-Size="50%" />
                        <br />
                        <asp:Label ID="Message" runat="server" />
                    </div>

                    <div class="pozycja1">
                        <asp:ImageButton class="ImageButton" ID="img1" runat="server"
                            AlternateText="ImageButton 1"
                            ImageUrl="owca.jpg"
                            Visible="true"
                            OnClick="ImageButton_Click" />
                        <asp:Label ID="Label1" runat="server" />
                    </div>

                    <div class="pozycja2">
                        <asp:ImageButton class="ImageButton" ID="img2" runat="server"
                            AlternateText="ImageButton 1"
                            ImageUrl="owca.jpg"
                            Visible="false"
                            OnClick="ImageButton_Click" />
                        <asp:Label ID="Label2" runat="server" />
                    </div>

                    <div class="pozycja3">
                        <asp:ImageButton class="ImageButton" ID="img3" runat="server"
                            AlternateText="ImageButton 1"
                            ImageUrl="owca.jpg"
                            Visible="false"
                            OnClick="ImageButton_Click" />
                        <asp:Label ID="Label3" runat="server" />
                    </div>

                    <div class="pozycja4">
                        <asp:ImageButton class="ImageButton" ID="img4" runat="server"
                            AlternateText="ImageButton 1"
                            ImageUrl="owca.jpg"
                            Visible="false"
                            OnClick="ImageButton_Click" />
                        <asp:Label ID="Label4" runat="server" />
                    </div>
                </div>
            </div>
        </div>







    </form>


</body>
</html>
