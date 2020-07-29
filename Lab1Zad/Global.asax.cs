using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Lab1Zad
{
    public class Global : System.Web.HttpApplication
    {
        public static ArrayList lista_uzytkownikow = new ArrayList(); //lista uzytkownikow globalna dla całej aplikacji
        public static int ile_uzytkownikow=0;
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 1; //zamyka sesje po minucie braku używania
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            using (dbEntities baza_danych = new dbEntities()) //ustalanie zeby zawsze wyswietlalo sie DetailsView dla aktualnie zalogowanego uzytkownika
            {
                if (baza_danych.Globalne.Where(p => p.Id_sesji == Session.SessionID).FirstOrDefault() != null) //zmienia sie dane dla id = 1000
                {
                    var pd = baza_danych.Globalne.Where(p => p.Id_sesji == Session.SessionID).FirstOrDefault(); //zmienia sie dane dla id = 1000
                    lista_uzytkownikow.Remove(pd.Nazwa_Uzytkownika.ToString());
                    pd.czy_aktywny = "nie";
                    ile_uzytkownikow--;
                    baza_danych.SaveChanges();
                }
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }

}