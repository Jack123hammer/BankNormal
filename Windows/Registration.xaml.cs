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

namespace BankNormal
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            btn_send_data.IsEnabled = false;
        }

        private void tb_last_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_last_name.Text.Length > 1)
            {
                cb_last_name.IsChecked = true;
                btn_send_data.IsEnabled = true;
            }
            else if (tb_last_name.Text.Length == 0)
            {
                cb_last_name.IsChecked = false;
                btn_send_data.IsEnabled = false;
            }
            else
            {
                cb_last_name.IsChecked = null;
                btn_send_data.IsEnabled = false;
            }
        }

        private void tb_first_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_first_name.Text.Length > 1)
            {
                cb_first_name.IsChecked = true;
                btn_send_data.IsEnabled = true;
            }
            else if (tb_first_name.Text.Length == 0)
            {
                cb_first_name.IsChecked = false;
                btn_send_data.IsEnabled = false;
            }
            else
            {
                cb_first_name.IsChecked = null;
                btn_send_data.IsEnabled = false;
            }
        }

        private void tb_second_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_second_name.Text.Length > 1)
            {
                cb_second_name.IsChecked = true;
                btn_send_data.IsEnabled = true;
            }
            else if (tb_second_name.Text.Length == 0)
            {
                cb_second_name.IsChecked = false;
                btn_send_data.IsEnabled = false;
            }
            else
            {
                cb_second_name.IsChecked = null;
                btn_send_data.IsEnabled = false;
            }
        }

        private void tb_telephone_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            if (tb_telephone.Text.Length >= 10 && tb_telephone.Text.Length <= 14)
            {
                cb_telephone.IsChecked = true;
                btn_send_data.IsEnabled = true;
                
            }
            else if (tb_telephone.Text.Length == 0)
            {
                cb_telephone.IsChecked = false;
                btn_send_data.IsEnabled = false;
            }
            else
            {
                cb_telephone.IsChecked = null;
                btn_send_data.IsEnabled = false;
            }
        }

        private void tb_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_email.Text.Contains("@yandex.ru") && tb_email.Text.Length > 10 || tb_email.Text.Contains("@gmail.com") && tb_email.Text.Length > 10 || tb_email.Text.Contains("@mail.ru") && tb_email.Text.Length > 8)
            {
                cb_email.IsChecked = true;
                

            }
            else if (tb_email.Text.Length == 0)
            {
                cb_email.IsChecked = false;
            }
            else
            {
                cb_email.IsChecked = null;
                btn_send_data.IsEnabled = false;
            }
        }

        private void tb_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_address.Text.Length >= 10)
            {
                cb_address.IsChecked = true;
            }
            else if (tb_email.Text.Length < 10)
            {
                cb_address.IsChecked = false;
            }
            else
            {
                cb_address.IsChecked = null;
            }
        }
       

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth = new Authorization();
            auth.Show();
            this.Close();
        }

        private void btn_send_data_Click(object sender, RoutedEventArgs e)
        {
            if (cb_last_name.IsChecked == true && cb_first_name.IsChecked == true && cb_second_name.IsChecked == true &&
                cb_email.IsChecked == true && cb_serial.IsChecked == true && cb_number.IsChecked == true &&
                cb_issied_by.IsChecked == true && cb_telephone.IsChecked == true && cb_address.IsChecked == true &&
                cb_inipa.IsChecked == true && cb_department_code.IsChecked == true && cb_tin.IsChecked == true)
            {
                btn_send_data.IsEnabled = true;
            }
            else { btn_send_data.IsEnabled = false; }
        }


    }
}
