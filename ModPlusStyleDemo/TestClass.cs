namespace ModPlusStyleDemo
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class TestClass : INotifyPropertyChanged
    {
        public TestClass(string name, double value, string strData, List<string> listData)
        {
            _name = name;
            _doubleValue = value;
            _stringData = strData;
            _listData = listData;
        }

        private string _name;

        /// <summary></summary>
        public string Name
        {
            get => _name;
            set
            {
                if (Equals(value, _name))
                    return;
                _name = value;
                OnPropertyChanged();
            }
        }

        private double _doubleValue;

        /// <summary></summary>
        public double DoubleValue
        {
            get => _doubleValue;
            set
            {
                if (Equals(value, _doubleValue))
                    return;
                _doubleValue = value;
                OnPropertyChanged();
            }
        }

        private string _stringData;

        /// <summary></summary>
        public string StringData
        {
            get => _stringData;
            set
            {
                if (Equals(value, _stringData))
                    return;
                _stringData = value;
                OnPropertyChanged();
            }
        }

        private List<string> _listData;

        /// <summary></summary>
        public List<string> ListData
        {
            get => _listData;
            set
            {
                if (Equals(value, _listData))
                    return;
                _listData = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
