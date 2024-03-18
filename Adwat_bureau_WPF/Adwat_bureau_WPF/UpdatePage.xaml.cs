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

namespace Adwat_bureau_WPF
{
    /// <summary>
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        ClientsPage clientsPage = new ClientsPage();
        CourtCasesPage courtCasesPage = new CourtCasesPage();
        LawyerPage lawyerPage = new LawyerPage();
        DiplomaUniversityPage diplomaUniversityPage = new DiplomaUniversityPage();
        private Adwat_bureauEntities context = new Adwat_bureauEntities();
        public string choice;

        public UpdatePage()
        {
            InitializeComponent();
           ;
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
            
            if (choice == "ClientsPage")
            {
                if (UpdateComboBox.SelectedItem != null)
                {
                    var uclients = context.Clients.Find(UpdateComboBox.SelectedItem);
                    var select = uclients as Clients;

                    select.ClientName = UTextBox1.Text;
                    select.ClientSurname = UTextBox2.Text;
                    select.ClientMiddleName = UTextBox3.Text;
                    select.PhoneNumber = UTextBox4.Text;
                    select.СourtСases_ID = UCTextBox5.SelectedIndex + 1;

                    context.SaveChanges();
                    ClientsPage newPage = new ClientsPage();
                    newPage.grid_Clients.ItemsSource = context.Clients.ToList();
                    MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow.PageFrame.Navigate(newPage);
                }
            }
            else if (choice == "LawyerPage")
            {
                if (UpdateComboBox.SelectedItem != null)
                {
                    int Seniority = 0;
                    if (int.TryParse(UTextBox4.Text, out Seniority))
                    {
                        
                    }
                    else
                    {
                        return;
                    }

                    var ulawyer = context.Lawyer.Find(UpdateComboBox.SelectedItem);
                    var selectl = ulawyer as Lawyer;

                    selectl.LawyerSurname = UTextBox1.Text;
                    selectl.LawyerName = UTextBox2.Text;
                    selectl.LawyerMiddleName = UTextBox3.Text;
                    selectl.Seniority = Seniority;
                    selectl.DiplomaUniversity_ID = UCTextBox5.SelectedIndex + 1;
                    selectl.Client_ID = UCTextBox6.SelectedIndex + 1;

                    context.SaveChanges();
                    LawyerPage newPage = new LawyerPage();
                    newPage.grid_Lawyer.ItemsSource = context.Lawyer.ToList();
                    MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow.PageFrame.Navigate(newPage);
                }
            }
            else if (choice == "DiplomaUniversityPage")
            {
                if (UpdateComboBox.SelectedItem != null)
                {
                    var udiploma = context.DiplomaUniversityTable.Find(UpdateComboBox.SelectedItem);
                    var selectd = udiploma as DiplomaUniversityTable;

                    selectd.DiplomaUniversity = UTextBox1.Text;

                    context.SaveChanges();
                    DiplomaUniversityPage newPage = new DiplomaUniversityPage();
                    newPage.grid_DiplomaUniversity.ItemsSource = context.DiplomaUniversityTable.ToList();
                    MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow.PageFrame.Navigate(newPage);
                }
            }
            else if (choice == "CourtCasesPage")
            {
                if (UpdateComboBox.SelectedItem != null)
                {
                    var ucourt = context.СourtСasesTable.Find(UpdateComboBox.SelectedItem);
                    var selectc = ucourt as СourtСasesTable;

                    selectc.СourtСases = UTextBox1.Text;

                    context.SaveChanges();
                    CourtCasesPage newPage = new CourtCasesPage();
                    newPage.grid_CourtCases.ItemsSource = context.СourtСasesTable.ToList();
                    MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow.PageFrame.Navigate(newPage);
                }
            }
           
        }
    }
}
