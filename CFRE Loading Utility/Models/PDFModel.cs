using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CFRE_Loading_Utility.Models
{
    public partial class PDFRow : INotifyPropertyChanged
    {
        private string row;

        public string Row
        {
            get { return row; }
            set
            {
                row = value;
                OnPropertyChanged(nameof(Row));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
