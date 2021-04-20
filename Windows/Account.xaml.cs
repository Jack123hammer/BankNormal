using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BankNormal.DataBase;
using BankNormal.Resources;

namespace BankNormal.Windows
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        Entities DB = new Entities();

        public Account()
        {
            InitializeComponent();
            Update();

        }

        private void Update()
        {
            DG_Score.ItemsSource = DB.Score.Where(t => t.UserID == SaveData.id).ToList();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Authorization aut = new Authorization();
            aut.Show();
            this.Close();
        }

        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
            var user = DB.Score.SingleOrDefault(t => t.Number.ToString() == tbYourScore.Text);
            var reciever = DB.Score.SingleOrDefault(t => t.Number.ToString() == tbRecieverScore.Text);
            if (user != null && reciever != null && user.Currency == reciever.Currency && user.UserID == SaveData.id && user.Number != reciever.Number)
            {
               MessageBox.Show("Работает");
                DataBase.Transaction tra = new DataBase.Transaction
                {
                    Sender = SaveData.id,
                    Receiver = reciever.UserID,
                    Amount = Convert.ToInt32( tbAmount.Text),
                    Currency = user.Currency,
                    Type = 1
                };
                try
                {
                    DB.Transaction.Add(tra);
                    DB.SaveChanges();
                    DataBase.Score score_usr = DB.Score.SingleOrDefault(t => t.Number == user.Number);
                    score_usr.Amount = score_usr.Amount - Convert.ToInt32(tbAmount.Text);
                    DB.SaveChanges();
                    DataBase.Score score_rec = DB.Score.SingleOrDefault(t => t.Number == reciever.Number);
                    score_rec.Amount = score_rec.Amount + Convert.ToInt32(tbAmount.Text);
                    DB.SaveChanges();
                    Update();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Не работает");
                  
                }
                
            }
            else
            {
                MessageBox.Show("БЛЯЯЯЯЯЯЯ");
            }
        }
    }
}