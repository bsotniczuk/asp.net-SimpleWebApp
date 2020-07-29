<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Lab1Zad.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .tabela_pozycja {
            position: absolute;
            left: 37.0%;
            right: 32.5%;
            top: 20%;
            bottom: 40%;
        }

        .auto-style1 {
            background-color: #f2f2f2;
            color: #4CAF50;
            border-collapse: collapse;
        }

        .auto-style2 {
            text-align: center;

            background-color: #4CAF50;
            color: black;
        }

        .pole_do_wpisywania {
            text-align: center;
            background-color: #4CAF50;
        }

        .auto-style4 {
            text-align: center;
            background-color: #4CAF50;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="tabela_pozycja" runat="server">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Podaj imie i nazwisko</td>
                </tr>
                <tr>
                    <td class="pole_do_wpisywania">
                        <asp:TextBox ID="TextBoxUserName" runat="server" Width="50%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="Button1" runat="server" Height="15%" OnClick="Button1_Click" Text="Zarejestruj" Width="40%" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="Identyfikator nie jest zgodny ze wzorcem." ValidationExpression="^[A-Z-ŻŹĆĄŚĘŁÓŃ][a-z-żźćńółęąś][a-z-żźćńółęąś]+ [A-Z-ŻŹĆĄŚĘŁÓŃ][a-z-żźćńółęąś][a-z-żźćńółęąś]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Użytkownik jest zalogowany." OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="Nie wprowadzono żadnej wartości."></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
