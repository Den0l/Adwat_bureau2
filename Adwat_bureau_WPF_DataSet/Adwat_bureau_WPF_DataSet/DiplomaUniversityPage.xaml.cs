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
    /// Логика взаимодействия для DiplomaUniversityPage.xaml
    /// </summary>
    public partial class DiplomaUniversityPage : Page
    {
        DiplomaUniversityTableTableAdapter diploma = new DiplomaUniversityTableTableAdapter();
        public DiplomaUniversityPage()
        {
            InitializeComponent();
            grid_DiplomaUniversity.ItemsSource = diploma.GetData();

        }
    }
}
