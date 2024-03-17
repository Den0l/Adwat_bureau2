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
using Adwat_bureau_WPF_DataSet.Adwat_bureau_DataSetTableAdapters;

namespace Adwat_bureau_WPF_DataSet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {
        СourtСasesTableTableAdapter courtCasesAdap = new СourtСasesTableTableAdapter();
        ClientsTableAdapter clientsAdap = new ClientsTableAdapter();
        LawyerTableAdapter lawyerAdap = new LawyerTableAdapter();
        DiplomaUniversityTableTableAdapter diplomaAdap = new DiplomaUniversityTableTableAdapter();
        private CreatePage createPage = new CreatePage();
        private UpdatePage updatePage = new UpdatePage();
        private DeletePage deletePage = new DeletePage();
        

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void PageClients_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ClientsPage();
            createPage.choice = "ClientsPage";
            updatePage.choice = "ClientsPage";
            deletePage.choice = "ClientsPage";

            DataTable courtCasesTable = courtCasesAdap.GetData();
            createPage.CTextBox5.DisplayMemberPath = "СourtСases";
            createPage.CTextBox5.ItemsSource = courtCasesTable.DefaultView;
            updatePage.UCTextBox5.DisplayMemberPath = "СourtСases";
            updatePage.UCTextBox5.ItemsSource = courtCasesTable.DefaultView;

            DataTable clientsTable = clientsAdap.GetData();
            updatePage.UpdateComboBox.DisplayMemberPath = "ID_Client";
            updatePage.UpdateComboBox.ItemsSource = clientsTable.DefaultView;

            deletePage.DeleteComboBox.DisplayMemberPath = "ID_Client";
            deletePage.DeleteComboBox.ItemsSource = clientsTable.DefaultView;

            createPage.SetCTextBlock("Имя Клиента",
            "Фамилия Клиента",
            "Отчесвто Клиента",
            "Номер телефона",
            "ID_Вид дела", "");

            updatePage.SetUTextBlock("Имя Клиента",
            "Фамилия Клиента",
            "Отчесвто Клиента",
            "Номер телефона",
            "ID_Вида дела", "");

        }

        private void PageLawyer_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new LawyerPage();
            createPage.choice = "LawyerPage";
            updatePage.choice = "LawyerPage";
            deletePage.choice = "LawyerPage";

            DataTable diplomaTable = diplomaAdap.GetData();
            DataTable clientTable = clientsAdap.GetData();
            createPage.CTextBox5.DisplayMemberPath = "DiplomaUniversity";
            createPage.CTextBox5.ItemsSource = diplomaTable.DefaultView;
            updatePage.UCTextBox5.DisplayMemberPath = "DiplomaUniversity";
            updatePage.UCTextBox5.ItemsSource = diplomaTable.DefaultView;
            createPage.CTextBox6.DisplayMemberPath = "ClientName";
            createPage.CTextBox6.ItemsSource = clientTable.DefaultView;
            updatePage.UCTextBox6.DisplayMemberPath = "ClientName";
            updatePage.UCTextBox6.ItemsSource = clientTable.DefaultView;

            DataTable LawyerTable = lawyerAdap.GetData();
            updatePage.UpdateComboBox.DisplayMemberPath = "ID_Lawyer";
            updatePage.UpdateComboBox.ItemsSource = LawyerTable.DefaultView;

            deletePage.DeleteComboBox.DisplayMemberPath = "ID_Lawyer";
            deletePage.DeleteComboBox.ItemsSource = LawyerTable.DefaultView;

            createPage.SetCTextBlock("Фамилия Адвоката",
            "Имя Адвоката",
            "Отчесвто Адвоката",
            "Опыт работы",
            "ID_Вуз", "ID_Клиент");

            updatePage.SetUTextBlock("Фамилия Адвоката",
            "Имя Адвоката",
            "Отчесвто Адвоката",
            "Опыт работы",
            "ID_Вуз", "ID_Клиент");
           
        }

        private void PageСourtСases_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new CourtCasesPage();
            createPage.choice = "CourtCasesPage";
            updatePage.choice = "CourtCasesPage";
            deletePage.choice = "CourtCasesPage";

            DataTable courtCasesTable = courtCasesAdap.GetData();
            updatePage.UpdateComboBox.DisplayMemberPath = "ID_CourtCases";
            updatePage.UpdateComboBox.ItemsSource = courtCasesTable.DefaultView;

            deletePage.DeleteComboBox.DisplayMemberPath = "ID_CourtCases";
            deletePage.DeleteComboBox.ItemsSource = courtCasesTable.DefaultView;

            createPage.SetCTextBlock("Вид судебного дела",
            "",
            "",
            "",
            "", "");

            updatePage.SetUTextBlock("Вид судебного дела",
            "",
            "",
            "",
            "", "");

            

        }

        private void PageDiplomaUniversity_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new DiplomaUniversityPage();
            createPage.choice = "DiplomaUniversityPage";
            updatePage.choice = "DiplomaUniversityPage";
            deletePage.choice = "DiplomaUniversityPage";

            DataTable diplomaTable = diplomaAdap.GetData();
            updatePage.UpdateComboBox.DisplayMemberPath = "ID_DiplomaUniversity";
            updatePage.UpdateComboBox.ItemsSource = diplomaTable.DefaultView;

            deletePage.DeleteComboBox.DisplayMemberPath = "ID_DiplomaUniversity";
            deletePage.DeleteComboBox.ItemsSource = diplomaTable.DefaultView;

            createPage.SetCTextBlock("Диплом университета",
            "",
            "",
            "",
            "", "");

            updatePage.SetUTextBlock("Диплом университета",
            "",
            "",
            "",
            "", "");
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrameCRUD.Content = createPage;
            
        }

        private void Change_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrameCRUD.Content = updatePage;
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrameCRUD.Content = deletePage;
        }
    }
}
