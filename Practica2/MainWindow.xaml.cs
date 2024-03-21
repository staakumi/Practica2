using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Practica2.Hobby_shopDataSetTableAdapters;


namespace Practica2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        Shop_EmployeesTableAdapter employees = new Shop_EmployeesTableAdapter();
        ProductsTableAdapter products = new ProductsTableAdapter();
        public MainWindow()
        {


            InitializeComponent();
            EmployeesDataGrid.ItemsSource = employees.GetData();


            ProductsDataGrid.ItemsSource = products.GetData();


        }

        public void ShowEmployees_Click(object sender, RoutedEventArgs e)
        {
            
            SurnameTbx.Visibility = Visibility.Visible;
            NameTbx.Visibility = Visibility.Visible;
            MiddleNameTbx.Visibility = Visibility.Visible;
            AgeTbx.Visibility = Visibility.Visible;

            
            NamePro.Visibility = Visibility.Collapsed;
            PricePro.Visibility = Visibility.Collapsed;

            EmployeesDataGrid.Visibility = Visibility.Visible;
            ProductsDataGrid.Visibility = Visibility.Collapsed;
        }
        public void ShowProducts_Click(object sender, RoutedEventArgs e)
        {
            
            SurnameTbx.Visibility = Visibility.Collapsed;
            NameTbx.Visibility = Visibility.Collapsed;
            MiddleNameTbx.Visibility = Visibility.Collapsed;
            AgeTbx.Visibility = Visibility.Collapsed;

            
            NamePro.Visibility = Visibility.Visible;
            PricePro.Visibility = Visibility.Visible;

            EmployeesDataGrid.Visibility = Visibility.Collapsed;
            ProductsDataGrid.Visibility = Visibility.Visible;
        }


        private void OpenNewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2();
            window.Show();
        }

        private void ButtonInsertClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.Visibility == Visibility.Visible)
            {
                employees.InsertQuery( NameTbx.Text, SurnameTbx.Text, MiddleNameTbx.Text, Convert.ToInt32(AgeTbx.Text));
                EmployeesDataGrid.ItemsSource = employees.GetData();
            }
            else
            {
                products.InsertQueryPro( NamePro.Text, Convert.ToInt32(PricePro.Text));
                ProductsDataGrid.ItemsSource = products.GetData();
            }
        }
        private void ButtonUpdateClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.Visibility == Visibility.Visible)
            {
                object ID1 = (EmployeesDataGrid.SelectedItem as DataRowView).Row[0];
                employees.UpdateQuery(NameTbx.Text, SurnameTbx.Text, MiddleNameTbx.Text, Convert.ToInt32(AgeTbx.Text), Convert.ToInt32(ID1));
                EmployeesDataGrid.ItemsSource = employees.GetData();
            }
            else
            {
                object ID2 = (ProductsDataGrid.SelectedItem as DataRowView).Row[0];
                products.UpdateQueryPro(NamePro.Text, Convert.ToInt32(PricePro.Text), Convert.ToInt32(ID2));
                ProductsDataGrid.ItemsSource = products.GetData();
            }
        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.Visibility == Visibility.Visible)
            {
                object ID1 = (EmployeesDataGrid.SelectedItem as DataRowView).Row[0];
                employees.DeleteQuery(Convert.ToInt32(ID1));
                EmployeesDataGrid.ItemsSource = employees.GetData();
            }
            else
            {
                object ID2 = (ProductsDataGrid.SelectedItem as DataRowView).Row[0];
                products.DeleteQueryPro(Convert.ToInt32(ID2));
                ProductsDataGrid.ItemsSource = products.GetData();
            }
        }

    }

}

