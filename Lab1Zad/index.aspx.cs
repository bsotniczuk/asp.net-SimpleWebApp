using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace Lab1Zad
{
    public partial class index : System.Web.UI.Page
    {   //deklaracje zmiennych
        public static int liczba_zalogowan = 0;
        private static int ktore_okno = 1;
        private static int ilosc_wcisniec = 0;
        public static string UserName = "";
        public static int count=1; //na poczatku programu jest 1 uzytkownik
        protected void Page_Load(object sender, EventArgs e)
        {
            //label_ilosc_wcisniec.Text = "Wybrany index dla DropDownList1: " + DropDownList1.SelectedValue + "UserName: " + UserName;
            label_ilosc_wcisniec.Visible = false; //debug
            if (!IsPostBack)
            {
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        public void Update(int id)
        {
            using (dbEntities baza_danych = new dbEntities())
            {
                if (baza_danych.Globalne.Where(p => p.Id_uzytkownika == id).FirstOrDefault() != null) //dla id_uzytkownika == id
                {
                    var pd = baza_danych.Globalne.Where(p => p.Id_uzytkownika == 1).FirstOrDefault();
                    pd.Id_uzytkownika = id;
                    baza_danych.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (dbEntities baza_danych = new dbEntities())
            {
                //zabezpiecz przed updateowaniem nieistniejacego rekordu
                if(baza_danych.Globalne.Where(p => p.Id_uzytkownika == id).FirstOrDefault()!=null) //zmienia sie dane dla id = 1000
                {
                    var pda = baza_danych.Globalne.Where(p => p.Id_uzytkownika == id).FirstOrDefault();
                    baza_danych.DeleteObject(pda);
                    baza_danych.SaveChanges();
                }
            }
        }
        public void Insert(int id, String Nazwa_Uzytkownika) //Insert(baza_danych.Globalne.Count(), UserName); //int id, UserName, reszta na 0;
        {
            Globalne globalne = new Globalne()
            {
                Id_uzytkownika = id,
                Nazwa_Uzytkownika = Nazwa_Uzytkownika,
                Data_Uruchomienia = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                Godzina_Uruchomienia = DateTime.Now.ToString("HH:mm"),
                czy_aktywny = "tak",
                ile_razy_uruchomil = 1,
                klikniecia_przycisk = 0,
                klikniecia_obraz = 0,
                ilu_zarejestrowanych = count,
                numer_okna = 1,
                Ilu_uzytkownikow = Global.ile_uzytkownikow,
                Id_sesji = Session.SessionID.ToString(),
                iterator = 0
            };
            using (dbEntities baza_danych = new dbEntities())
            {
                if (baza_danych.Globalne.Where(p => p.Id_uzytkownika == id).FirstOrDefault() == null) //zmienia sie dane dla id = 1000
                {
                    baza_danych.AddToGlobalne(globalne);
                    baza_danych.SaveChanges();
                }
            }
        }

        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        public void SubmitBtn_Click(Object sender, EventArgs e)
        {
            using (dbEntities baza_danych = new dbEntities())
            {  
                if (baza_danych.Globalne.Where(p => p.Id_sesji == Session.SessionID).FirstOrDefault() != null) //zmienia sie dane dla id = 1000
                {
                    var pd = baza_danych.Globalne.Where(p => p.Id_sesji == Session.SessionID).FirstOrDefault(); //zmienia sie dane dla id = 1000
                    String login = pd.Nazwa_Uzytkownika;
                    pd.klikniecia_przycisk++;
                    baza_danych.SaveChanges();
                }
            }
            GetRand();
            Pozycja_okna(ktore_okno);
            Sync(ktore_okno, ilosc_wcisniec);
            Show_Label();
        }

        public void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            GlobalAsax_Increment();

            Pozycja_okna(ktore_okno);
            Sync(ktore_okno, ilosc_wcisniec);
            Show_Label();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        public void Pozycja_okna(int zmienna)
        {
            img1.Visible = img2.Visible = img3.Visible = img4.Visible = false;
            if (zmienna == 1) //pierwsza pozycja
            {
                img1.Visible = true;
            }
            else if (zmienna == 2)
            {
                img2.Visible = true;
            }
            else if (zmienna == 3)
            {
                img3.Visible = true;
            }
            else if (zmienna == 4)
            {
                img4.Visible = true;
            }
        }

        public void GetRand()
        {
            if (ktore_okno == 1)
            { ktore_okno = GetRandomNumber(2, 5); } //ze wzgledu na funkcje synchronizującą dozwalam losowanie do 5
            else if (ktore_okno == 2)
            { ktore_okno = GetRandomNumber(3, 5); }
            else if (ktore_okno == 3)
            { ktore_okno = GetRandomNumber(1, 2); }
            else if (ktore_okno == 4)
            { ktore_okno = GetRandomNumber(1, 3); }

            using (dbEntities baza_danych = new dbEntities())
            {
                if (baza_danych.Globalne.Where(p => p.Id_sesji == Session.SessionID).FirstOrDefault() != null) //zmienia sie dane dla id = 1000
                {
                    var pd = baza_danych.Globalne.Where(p => p.Id_sesji == Session.SessionID).FirstOrDefault();
                    pd.numer_okna=(int)ktore_okno;
                    baza_danych.SaveChanges();
                }
            }
        }
        public void Sync(int zmienna1, int zmienna2) //funkcja synchronizująca zmienne statyczne
        {
            ktore_okno = zmienna1;
            ilosc_wcisniec = zmienna2;
        }

        public void Show_Label()
        {
            using (dbEntities baza_danych = new dbEntities()) //ustalanie zeby zawsze wyswietlalo sie DetailsView dla aktualnie zalogowanego uzytkownika
            {
                if (baza_danych.Globalne.Where(p => p.Nazwa_Uzytkownika == zalogowany_uzytkownik.Text).FirstOrDefault() != null) //zmienia sie dane dla id = 1000
                {
                    var pd = baza_danych.Globalne.Where(p => p.Nazwa_Uzytkownika == zalogowany_uzytkownik.Text).FirstOrDefault();
                    if (pd.czy_aktywny.ToString()=="nie")
                    {
                        whole_1.Visible = false;
                        panel_logowania.Visible = true;
                    }
                    else
                    {
                        DropDownList_DetailsView();

                        if (baza_danych.Globalne.Where(p => p.Id_sesji == Session.SessionID).FirstOrDefault() != null) //zmienia sie dane dla id = 1000
                        {
                            var pda = baza_danych.Globalne.Where(p => p.Id_sesji == Session.SessionID).FirstOrDefault(); //zmienia sie dane dla id = 1000
                            String login = pda.Nazwa_Uzytkownika;
                            DropDownList1.DataBind();
                            DropDownList1.SelectedValue = login;
                            DetailsView1.DataBind();
                            DropDownList1.DataBind();
                            //DropDownList1.SelectedIndex = 1;
                            label_ilosc_wcisniec.Text = "Wybrany index dla DropDownList1: " + DropDownList1.SelectedValue;
                        }
                    }
                }         
            }
        }

        public void GlobalAsax_Increment()
        {

            using (dbEntities baza_danych = new dbEntities())
            {
                if (baza_danych.Globalne.Where(p => p.Id_sesji == Session.SessionID).FirstOrDefault() != null) //zmienia sie dane dla id = 1000
                {
                    var pd = baza_danych.Globalne.Where(p => p.Id_sesji == Session.SessionID).FirstOrDefault();
                    String login = pd.Nazwa_Uzytkownika;
                    DropDownList1.DataBind();
                    DropDownList1.SelectedValue = pd.Nazwa_Uzytkownika;
                    pd.Ilu_uzytkownikow = Global.ile_uzytkownikow;
                    pd.ilu_zarejestrowanych = baza_danych.Globalne.Count();
                    pd.klikniecia_obraz++;
                    pd.numer_okna++;
                    if (pd.numer_okna == 5) pd.numer_okna = 1;
                    pd.iterator = 1;

                    ktore_okno = (int)pd.numer_okna;

                    baza_danych.SaveChanges();
               }
            }
            DetailsView1.DataBind();
        }


        public void DropDownList_DetailsView()
        {
            DetailsView1.DataBind();
        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Global.lista_uzytkownikow.Contains(TextBoxUserName.Text)/*TextBoxUserName.Text=="Jan Chudzikiewicz"*/ /*TextBoxUserName.Text.Equals(UserName, StringComparison.Ordinal) || lista_uzytkownikow.Contains(TextBoxUserName.Text)*/)
            {
                args.IsValid = false;
                Label5.Visible = true;
            }
            else //jezeli dany uzytkownik nie jest zalogowany i przeszedł wszystkie walidatory to pokaz owieczki
            {
                args.IsValid = true;

                panel_logowania.Visible = false;
                whole_1.Visible = true;
                Label5.Visible = false;

                //convert to ASCII to prevent user from using non-compatible characters
                string s = TextBoxUserName.Text;
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(s);
                int result = BitConverter.ToInt32(bytes, 0);
            
                int i = result;
                byte[] bytes2 = BitConverter.GetBytes(i);
                string s2 = System.Text.Encoding.ASCII.GetString(bytes);
               
                UserName = s2;
                TextBoxUserName.Text = s2;
                Global.lista_uzytkownikow.Add(UserName);
                Global.ile_uzytkownikow++;
                zalogowany_uzytkownik.Text = UserName;
                

                using (dbEntities baza_danych = new dbEntities()) //tworzenie nowego uzytkownika jezeli nie istnieje w bazei danych
                {

                    if (baza_danych.Globalne.Where(p => p.Nazwa_Uzytkownika == UserName).FirstOrDefault() == null)
                    {
                        if (baza_danych.Globalne.Count() == 0) //jezeli baza jest pusta to stworz Uzytkownika
                        {
                            Insert(0, UserName);
                        }
                        else
                        {
                            count=baza_danych.Globalne.Count();
                            int ostatnie_id = baza_danych.Globalne.Count() - 1;
                            label_ilosc_wcisniec.Text = "Nowy Uzytkownik: " + UserName + "ostatnie id w bazie danych: " + ostatnie_id;
                            Insert(baza_danych.Globalne.Count(), UserName); //int id, UserName, reszta na 0;
                        }
                    }
                    else //jezeli taki uzytkownik juz istnieje -> wyzeruj numer_okna dla tego uzytkownika
                    {
                        var pd = baza_danych.Globalne.Where(p => p.Nazwa_Uzytkownika == UserName).FirstOrDefault();
                        pd.numer_okna = 1;
                        pd.Data_Uruchomienia = DateTime.Now.Date.ToString("yyyy-MM-dd");
                        pd.Godzina_Uruchomienia = DateTime.Now.ToString("HH:mm");
                        pd.ile_razy_uruchomil++;
                        pd.czy_aktywny = "tak";
                        pd.Id_sesji = Session.SessionID.ToString();
                        pd.Ilu_uzytkownikow = Global.ile_uzytkownikow;
                        pd.ilu_zarejestrowanych = baza_danych.Globalne.Count();
                        baza_danych.SaveChanges();
                    }
                }

                TextBoxUserName.Text = ""; //zeby zapobiec dodaniu uzytkownika po zakonczonej sesji

                Show_Label();
                DropDownList1.DataBind();
                DropDownList1.SelectedValue = UserName;
                DetailsView1.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_ilosc_wcisniec.Text = "Wybrany index dla DropDownList1: " + DropDownList1.SelectedValue;
        }
    }
}