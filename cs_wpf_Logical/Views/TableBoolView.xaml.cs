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
using cs_LogicalAnalyzer;
using cs_wpf_Logical.ViewModels;

namespace cs_wpf_Logical.Views
{
    /// <summary>
    /// Interaction logic for TableBoolView.xaml
    /// </summary>
    public partial class TableBoolView : UserControl
    {
        public TableBoolView(LogicalReport report)
        {
            InitializeComponent();
            DataContext = new TableBoolViewModel(report, this);
        }
    }
}
