using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using BankNormal.DataBase;
using System.Security.Cryptography;
using BankNormal.Resources;
using BankNormal.Windows;

namespace BankNormal
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : MetroWindow
    {
        public string mailacc;
        DataBase.Entities DB = new Entities();
        public Authorization()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start(
                "https://i.ytimg.com/vi/pTx8E-QsaAY/maxresdefault.jpg");
        }


        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            fvMain.SelectedIndex = 1;
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        public byte[] GetHashPassword(string c)
        {
            var f = ASCIIEncoding.ASCII.GetBytes(c);
            f = new MD5CryptoServiceProvider().ComputeHash(f);
            return f;
        }

        public bool CheckPassword(byte[] one, byte[] two)
        {
            bool bEqual = false;
            if (one.Length == two.Length)
            {
                int i = 0;
                while ((i < one.Length) && (one[i] == two[i]))
                {
                    i += 1;
                }
                if (i == one.Length)
                {
                    bEqual = true;
                }
            }

            if (bEqual)
                return true;
            else
                return false;
            
        }

        private void btn_enter_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (tb_login.Text != "" && PassBox.Password != "")
            {
                DataBase.Account acc = DB.Account.SingleOrDefault(t => t.Login == tb_login.Text);
                if (acc == null)
                {
                    MessageBox.Show("Такого пользователя не существует!");
                    return;
                }

                if (!CheckPassword(acc.Password,GetHashPassword(PassBox.Password)))
                {
                    MessageBox.Show("Пароль неверный!");
                    return;
                }

                MessageBox.Show("Bueno!");
                SaveData.id = acc.ID;
                if (acc.LegalEntity == null && acc.Employee == null && acc.Individual == null)
                {
                    MessageBox.Show("Non Bueno!");
                    //Registration reg = new Registration();
                   // reg.Show();
                    //this.Close();
                }
                else
                {
                    
                    if (acc.LegalEntity != null)
                    {
                       LegalEntity accmail = DB.LegalEntity.SingleOrDefault(t => t.ID == SaveData.id);
                       mailacc = accmail.Email;
                    }
                    else if (acc.Employee != null)
                    {
                        Employee accmail = DB.Employee.SingleOrDefault(t => t.ID == SaveData.id);
                         mailacc = accmail.Email;
                    }
                    else if (acc.Individual != null)
                    {
                        Individual accmail = DB.Individual.SingleOrDefault(t => t.ID == SaveData.id);
                         mailacc = accmail.Email;
                    }

                    try
                    {
                        MessageBox.Show(mailacc);
                        SmtpClient client = new SmtpClient();
                        client.Credentials = new NetworkCredential("proverkasvyazi@internet.ru", "Ytrewq987654");
                        client.Host = "smtp.mail.ru";
                        client.Port = 587;
                        client.EnableSsl = true;
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("proverkasvyazi@internet.ru");
                        mail.To.Add(mailacc);
                        mail.Subject = "Код";
                        mail.Body = "1234";
                        client.Send(mail);
                        
                        
                        EnterData entr = new EnterData { 
                        Date = DateTime.Now,
                        Type = 4,
                        Code = "1234",
                        UserID = SaveData.id,
                        };
                        DB.EnterData.Add(entr);
                        DB.SaveChanges();
                        SaveData.idid = entr.ID;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Pechal'", "Beda");
                        throw;
                    }
                  UserWindow usr = new UserWindow();
                  usr.Show();
                  this.Close();
                }
            }
            else MessageBox.Show("Введите данные!");
        }

        private void btn_enterReg_Click(object sender, RoutedEventArgs e)
        {
            if (tb_loginReg.Text != "" && PassBoxReg.Password != "")
            {
                DataBase.Account acc = new DataBase.Account
                {
                    Login = tb_loginReg.Text,
                    Password = GetHashPassword(PassBoxReg.Password),
                    CreateAccount = DateTime.Now,
                    Status = 4
                };
                DB.Account.Add(acc);
                DB.SaveChanges();
                MessageBox.Show("Аккаунт создан!");
                tb_loginReg.Clear();
                PassBoxReg.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(
                "https://i.pinimg.com/originals/a2/0d/dd/a20ddd95ed33c6937246c1f37232e519.gif");
        }
    }
}
