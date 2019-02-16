using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using cs_LogicalAnalyzer;
using cs_wpf_Logical.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace cs_wpf_Logical
{
    class MainWindowViewModel : BindableBase
    {
        private string _input = "1 * 1";
        public String Input { get { return _input; } set { SetProperty(ref _input, value); EvaluateCommand.RaiseCanExecuteChanged(); } }

        private string _output = "";
        private UserControl _displayControl;
        public string Output { get { return _output; } set { SetProperty(ref _output, value); } }

        public UserControl DisplayControl
        {
            get { return _displayControl; }
            set
            {
                SetProperty(ref _displayControl, value);
            }
        }
        public DelegateCommand EvaluateCommand { get; set; }

        public MainWindowViewModel()
        {
            EvaluateCommand = new DelegateCommand(EvaluateCommand_Execute, () => Input.Length != 0);
        }


        private void EvaluateCommand_Execute()
        {
            DisplayControl = null;
            Analyzer analyzer = new Analyzer(Input);
            LogicalReport report;
            try
            {
                report = analyzer.Analyze();
            }
            catch (Exception)
            {
                DisplayControl = new ErrorResultView();
                return;
            }
            
            if (report.UniqueResult.HasValue)
            {
                DisplayControl = new SimpleBoolView(report.UniqueResult.Value);
                return;
            }
            DisplayControl = new TableBoolView(report);
        }
    }
}
