using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CreatePage createPage = new CreatePage();
        private UpdatePage updatePage = new UpdatePage();
        private DeletePage deletePage = new DeletePage();
        private Adwat_bureauEntities Maincontext = new Adwat_bureauEntities();
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

            var СourtСasesList = Maincontext.СourtСasesTable.Select(c => c.СourtСases).ToList();
            createPage.CTextBox5.ItemsSource = СourtСasesList;
            updatePage.UCTextBox5.ItemsSource = СourtСasesList;

            var ClientList = Maincontext.Clients.Select(c => c.ID_Client).ToList();
            deletePage.DeleteComboBox.ItemsSource = ClientList;
            updatePage.UpdateComboBox.ItemsSource = ClientList;

            createPage.SetCTextBlock("Фамилия Клиента",
            "Имя Клиента",
            "Отчесвто Клиента",
            "Номер телефона",
            "ID_Вид дела", "");

            updatePage.SetUTextBlock("Фамилия Клиента",
            "Имя Клиента",
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


            var DiplomaUniversityList = Maincontext.DiplomaUniversityTable.Select(c => c.DiplomaUniversity).ToList();
            createPage.CTextBox5.ItemsSource = DiplomaUniversityList;
            updatePage.UCTextBox5.ItemsSource = DiplomaUniversityList;
            var ClientsList = Maincontext.Clients.Select(c => c.ClientName).ToList();
            createPage.CTextBox6.ItemsSource = ClientsList;
            updatePage.UCTextBox6.ItemsSource = ClientsList;

            var LawyerList = Maincontext.Lawyer.Select(c => c.ID_Lawyer).ToList();
            deletePage.DeleteComboBox.ItemsSource = LawyerList;
            updatePage.UpdateComboBox.ItemsSource = LawyerList;


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

            var СourtСasesList = Maincontext.СourtСasesTable.Select(c => c.ID_CourtCases).ToList();
            deletePage.DeleteComboBox.ItemsSource = СourtСasesList;
            updatePage.UpdateComboBox.ItemsSource = СourtСasesList;



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

            var DiplomaUniversityList = Maincontext.DiplomaUniversityTable.Select(c => c.ID_DiplomaUniversity).ToList();
            deletePage.DeleteComboBox.ItemsSource = DiplomaUniversityList;

            var IDDiplomaUniversityList = Maincontext.DiplomaUniversityTable.Select(c => c.ID_DiplomaUniversity).ToList();
            deletePage.DeleteComboBox.ItemsSource = IDDiplomaUniversityList;
            updatePage.UpdateComboBox.ItemsSource = IDDiplomaUniversityList;

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
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrameCRUD.Content = deletePage;
        }

        private void Change_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrameCRUD.Content = updatePage;
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrameCRUD.Content = createPage;
        }
    }
}
