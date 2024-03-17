using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для CreatePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        ClientsPage clientsPage = new ClientsPage();
        CourtCasesPage courtCasesPage = new CourtCasesPage();
        LawyerPage lawyerPage = new LawyerPage();
        DiplomaUniversityPage diplomaUniversityPage = new DiplomaUniversityPage();
        private Adwat_bureauEntities context = new Adwat_bureauEntities();
        public string choice;

        public CreatePage()
        {
            InitializeComponent();
        }
        public void SetCTextBlock(string text1, string text2, string text3, string text4, string text5, string text6)
        {
            CTextBlock1.Text = text1;
            CTextBlock2.Text = text2;
            CTextBlock3.Text = text3;
            CTextBlock4.Text = text4;
            CTextBlock5.Text = text5;
            CTextBlock6.Text = text6;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {



            if (choice == "ClientsPage")
            {
                Clients c = new Clients();
                c.ClientName = CTextBox1.Text;
                c.ClientSurname = CTextBox2.Text;
                c.ClientMiddleName = CTextBox3.Text;
                c.PhoneNumber = CTextBox4.Text;
                c.СourtСases_ID = CTextBox5.SelectedIndex + 1;

                context.Clients.Add(c);
                context.SaveChanges();
                clientsPage.grid_Clients.ItemsSource  = context.Clients.ToList();

            }
            else if (choice == "LawyerPage")
            {
                int Seniority = 0;
                if (int.TryParse(CTextBox4.Text, out Seniority))
                {

                }
                else
                {
                    return;
                }

                Lawyer l = new Lawyer();
                l.LawyerSurname = CTextBox1.Text;
                l.LawyerName = CTextBox2.Text;
                l.LawyerMiddleName = CTextBox3.Text;
                l.Seniority = Seniority;
                l.DiplomaUniversity_ID = CTextBox5.SelectedIndex + 1; 
                l.Client_ID = CTextBox6.SelectedIndex + 1;

                context.Lawyer.Add(l);
                context.SaveChanges();
                lawyerPage.grid_Lawyer.ItemsSource = context.Lawyer.ToList();

            }
            else if (choice == "DiplomaUniversityPage")
            {
                DiplomaUniversityTable d = new DiplomaUniversityTable();
                d.DiplomaUniversity = CTextBox1.Text;

                context.DiplomaUniversityTable.Add(d);
                context.SaveChanges();
                diplomaUniversityPage.grid_DiplomaUniversity.ItemsSource = context.DiplomaUniversityTable.ToList();
            }
            else if (choice == "CourtCasesPage")
            {
                СourtСasesTable cc = new СourtСasesTable();
                cc.СourtСases = CTextBox1.Text;

                context.СourtСasesTable.Add(cc);
                context.SaveChanges();
                courtCasesPage.grid_CourtCases.ItemsSource = context.СourtСasesTable.ToList();
            }
            
        }
    }
}
