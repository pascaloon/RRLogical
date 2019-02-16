using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using cs_LogicalAnalyzer;
using cs_wpf_Logical.Views;
using Prism.Mvvm;

namespace cs_wpf_Logical.ViewModels
{
    class TableBoolViewModel : BindableBase
    {
        private TableBoolView _view;
        private LogicalReport _report;

        public TableBoolViewModel(LogicalReport report, TableBoolView view)
        {
            _view = view;
            _report = report;

            CreateGrid();
        }

        private void CreateGrid()
        {
            DataTable dt = new DataTable();
            foreach (string name in _report.ColumnNames)
            {
                dt.Columns.Add(name);
            }
            dt.Columns.Add("Result");
            for (int i = 0; i < _report.Rows.Count; i++)
            {
                var row = dt.NewRow();

                for (int j = 0; j < _report.ColumnNames.Count; j++)
                {
                    row[_report.ColumnNames[j]] = _report.Rows[i].VariablesValues[j]? 1 : 0;
                }
                row["Result"] = _report.Rows[i].Result ? 1 : 0;
                dt.Rows.Add(row);
            }
            _view.variablesGrid.AutoGenerateColumns = true;
            _view.variablesGrid.ItemsSource = dt.AsDataView();
        }
    }
}
