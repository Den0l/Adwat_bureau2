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
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
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
        public UpdatePage()
        {
            InitializeComponent();
        }
        public void SetUTextBlock(string text1, string text2, string text3, string text4, string text5, string text6)
        {
            UTextBlock1.Text = text1;
            UTextBlock2.Text = text2;
            UTextBlock3.Text = text3;
            UTextBlock4.Text = text4;
            UTextBlock5.Text = text5;
            UTextBlock6.Text = text6;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (UpdateComboBox.SelectedItem as DataRowView).Row[0];
            if (choice == "ClientsPage")
            {
                clientsAdap.UpdateQuery(UTextBox2.Text, UTextBox1.Text, UTextBox3.Text, UTextBox4.Text, UCTextBox5.SelectedIndex + 1, Convert.ToInt32(id));
                 ClientsPage newPage = new ClientsPage();
                 newPage.grid_Clients.ItemsSource = clientsAdap.GetData();
                 MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                 mainWindow.PageFrame.Navigate(newPage);
            }
            else if (choice == "LawyerPage")
            {
                int Seniority = 0;
                if (int.TryParse(UTextBox4.Text, out Seniority))
                {

                }
                else
                {
                    return;
                }

                lawyerAdap.UpdateQuery(UTextBox1.Text, UTextBox2.Text, UTextBox3.Text, Seniority, UCTextBox5.SelectedIndex + 1, UCTextBox6.SelectedIndex + 1, Convert.ToInt32(id));
                LawyerPage newPage = new LawyerPage();
                newPage.grid_Lawyer.ItemsSource = lawyerAdap.GetData();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.PageFrame.Navigate(newPage);
            }
            else if (choice == "DiplomaUniversityPage")
            {
                diplomaAdap.UpdateQuery(UTextBox1.Text, Convert.ToInt32(id));
                 DiplomaUniversityPage newPage = new DiplomaUniversityPage();
                 newPage.grid_DiplomaUniversity.ItemsSource = diplomaAdap.GetData();
                 MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                 mainWindow.PageFrame.Navigate(newPage);
            }
            else if (choice == "CourtCasesPage")
            {
                courtCasesAdap.UpdateQuery(UTextBox1.Text, Convert.ToInt32(id));
                CourtCasesPage newPage = new CourtCasesPage();
                newPage.grid_CourtCases.ItemsSource = courtCasesAdap.GetData();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.PageFrame.Navigate(newPage);
            }
        }
    }
}
