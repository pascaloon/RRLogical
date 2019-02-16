using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace cs_wpf_Logical.ViewModels
{
    class SimpleBoolViewModel : BindableBase
    {
        private String _result;

        public String Result {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        public SimpleBoolViewModel(bool result)
        {
            Result = result.ToString();
        }
    }
}
