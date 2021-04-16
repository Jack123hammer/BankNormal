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
using System.Windows.Shapes;
using BankNormal.DataBase;
using BankNormal.Resources;

namespace BankNormal.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        Entities DB = new Entities();
        public UserWindow()
        {
            InitializeComponent();
            MessageBox.Show(SaveData.idid.ToString());
        }

        private void btn_confirm_Click(object sender, RoutedEventArgs e)
        {

            EnterData entr = DB.EnterData.SingleOrDefault(t => t.ID == SaveData.idid);
            if (entr.Code == tb_code.Text)
            {
                entr.Type = 1;
                DB.SaveChanges();
                Account acc = new Account();
                acc.Show();
                this.Close();

            }
            else
            {
                entr.Type = 2;
                DB.SaveChanges();
                Authorization au = new Authorization();
                au.Show();
                this.Close();
            }
        }
    }
}
