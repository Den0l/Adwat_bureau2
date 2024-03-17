using Adwat_bureau_WPF_DataSet.Adwat_bureau_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
    /// Логика взаимодействия для LawyerPage.xaml
    /// </summary>
    public partial class LawyerPage : Page
    {
        LawyerTableAdapter lawyers = new LawyerTableAdapter();
        

        public LawyerPage()
        {
            InitializeComponent();
            grid_Lawyer.ItemsSource = lawyers.GetData();
            
        }
        
    }
}
