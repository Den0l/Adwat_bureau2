using Adwat_bureau_WPF_DataSet.Adwat_bureau_DataSetTableAdapters;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Adwat_bureau_WPF_DataSet
{
    /// <summary>
    /// Логика взаимодействия для CreatePage.xaml
    /// </summary>
    public partial class CreatePage : Page
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
            
            
            if(choice == "ClientsPage")
            {
                
                clientsAdap.InsertQuery(CTextBox2.Text, CTextBox1.Text, CTextBox3.Text, CTextBox4.Text, CTextBox5.SelectedIndex+1);
            }
            else if(choice == "LawyerPage")
            {
                int Seniority = 0;
                if (int.TryParse(CTextBox4.Text, out Seniority))
                {
                    
                }
                else
                {
                    return;
                }
                
                lawyerAdap.InsertQuery(CTextBox1.Text, CTextBox2.Text, CTextBox3.Text, Seniority, CTextBox5.SelectedIndex+1, CTextBox6.SelectedIndex+1);
            }
            else if (choice == "DiplomaUniversityPage")
            {
                diplomaAdap.InsertQuery(CTextBox1.Text);
            }
            else if (choice == "CourtCasesPage")
            {
                courtCasesAdap.InsertQuery(CTextBox1.Text);
            }
            
            
        }
    }
}
