using Adwat_bureau_WPF_DataSet.Adwat_bureau_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Adwat_bureau_WPF_DataSet
{
    /// <summary>
    /// Логика взаимодействия для DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        СourtСasesTableTableAdapter courtCasesAdap = new СourtСasesTableTableAdapter();
        ClientsTableAdapter clientsAdap = new ClientsTableAdapter();
        LawyerTableAdapter lawyerAdap = new LawyerTableAdapter();
        DiplomaUniversityTableTableAdapter diplomaAdap = new DiplomaUniversityTableTableAdapter();
        ClientsPage clientsPage = new ClientsPage();
        CourtCasesPage courtCasesPage = new CourtCasesPage();
        LawyerPage lawyerPage = new LawyerPage();
        DiplomaUniversityPage diplomaUniversityPage = new DiplomaUniversityPage();
        public string choice;
        public DeletePage()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (DeleteComboBox.SelectedItem as DataRowView).Row[0];
            if (choice == "ClientsPage")
            {
                try { 
                clientsAdap.DeleteQuery(Convert.ToInt32(id));
                }
                catch { return; }
                ClientsPage newPage = new ClientsPage();
                newPage.grid_Clients.ItemsSource = clientsAdap.GetData();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.PageFrame.Navigate(newPage);
            }
            else if (choice == "LawyerPage")
            {
                try { 
                lawyerAdap.DeleteQuery(Convert.ToInt32(id));
                }
                catch { return; }
                LawyerPage newPage = new LawyerPage();
                newPage.grid_Lawyer.ItemsSource = lawyerAdap.GetData();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.PageFrame.Navigate(newPage);
            }
            else if (choice == "DiplomaUniversityPage")
            {
                try
                {
                diplomaAdap.DeleteQuery(Convert.ToInt32(id));
                }
                catch { return; }
                DiplomaUniversityPage newPage = new DiplomaUniversityPage();
                newPage.grid_DiplomaUniversity.ItemsSource = diplomaAdap.GetData();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.PageFrame.Navigate(newPage);
            }
            else if (choice == "CourtCasesPage")
            {
                try
                {
                    courtCasesAdap.DeleteQuery(Convert.ToInt32(id));
                }
                catch { return; }
                CourtCasesPage newPage = new CourtCasesPage();
                newPage.grid_CourtCases.ItemsSource = courtCasesAdap.GetData();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.PageFrame.Navigate(newPage);
            }
        
        }
    }
}
