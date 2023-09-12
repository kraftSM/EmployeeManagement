using EmployeeManagement.Models;
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

namespace EmployeeManagement.Views
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void ListView_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItems[0];
            if (item is null) { return; }
            else
            {
                var emp = item as Employee;
                string Msg =Message( emp);
                MessageBox.Show(Msg);

            }
            
        }
        private string Message(Employee employee)
        {
            return "Имя: " + employee.FirstName + "\n" +
                "Фамилия: " + employee.LastName + "\n" +
                "Возраст: " + employee.Age + "\n" +
                "Должность: " + employee.Position + "\n" +
                "Компания: " + employee.CompanyName + "\n" +
                "Город: " + employee.CityName;
        }

       
    }


}
