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
    /// Логика взаимодействия для DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        ClientsPage clientsPage = new ClientsPage();
        CourtCasesPage courtCasesPage = new CourtCasesPage();
        LawyerPage lawyerPage = new LawyerPage();
        DiplomaUniversityPage diplomaUniversityPage = new DiplomaUniversityPage();
        private Adwat_bureauEntities context = new Adwat_bureauEntities();
        
        public string choice;
        public DeletePage()
        {
            InitializeComponent();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {


            if (choice == "ClientsPage")
            {
                var dclient = context.Clients.Find(DeleteComboBox.SelectedItem);
                try
                {
                context.Clients.Remove(dclient as Clients);
                }
                catch { return; }
                context.SaveChanges();
                clientsPage.grid_Clients.ItemsSource = context.Clients.ToList();
            }
            else if (choice == "LawyerPage")
            {
                var dlawyer = context.Lawyer.Find(DeleteComboBox.SelectedItem);

                try
                {
                context.Lawyer.Remove(dlawyer as Lawyer);
                }
                catch { return; }
                context.SaveChanges();
                lawyerPage.grid_Lawyer.ItemsSource = context.Lawyer.ToList();
            }
            else if (choice == "DiplomaUniversityPage")
            {
                var ddiploma = context.DiplomaUniversityTable.Find(DeleteComboBox.SelectedItem);

                try
                {
                context.DiplomaUniversityTable.Remove(ddiploma as DiplomaUniversityTable);
                }
                catch { return; }
                context.SaveChanges();
                diplomaUniversityPage.grid_DiplomaUniversity.ItemsSource = context.DiplomaUniversityTable.ToList();
            }
            else if (choice == "CourtCasesPage")
            {
                var dcourt = context.СourtСasesTable.Find(DeleteComboBox.SelectedItem);

                try
                {
                context.СourtСasesTable.Remove(dcourt as СourtСasesTable);
                }
                catch { return; }
                context.SaveChanges();
                courtCasesPage.grid_CourtCases.ItemsSource = context.СourtСasesTable.ToList();
            }
            
        }

    }
}
