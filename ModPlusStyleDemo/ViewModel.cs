namespace ModPlusStyleDemo
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        private string _testTextBoxValidationValue = "B";
        private ModPlusStyle.Theme _currentTheme;
        private double _valueForNumericBox;

        public ViewModel()
        {
            SomeData = new List<string>
            {
                "313221",
                "jhrgrjhgrj",
                "HHHJHJHJH",
                "iuyiruy"
            };
            _someDataSelected = SomeData.First();
            TestData = new List<TestClass>
            {
                new TestClass("First", 15.551, "Some data", SomeData),
                new TestClass("Second", 15.551, "Some data", SomeData),
                new TestClass("Third", 05.578, "Some data", SomeData),
                new TestClass("Any other", 0.111, "Some data", SomeData)
            };
            Themes = ModPlusStyle.ThemeManager.Themes;
            _currentTheme = Themes.First();
        }

        /// <summary></summary>
        public string TestTextBoxValidationValue
        {
            get => _testTextBoxValidationValue;
            set
            {
                if (Equals(value, _testTextBoxValidationValue))
                    return;
                _testTextBoxValidationValue = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<ModPlusStyle.Theme> Themes { get; }

        /// <summary></summary>
        public ModPlusStyle.Theme CurrentTheme
        {
            get => _currentTheme;
            set
            {
                if (Equals(value, _currentTheme))
                    return;
                _currentTheme = value;
                OnPropertyChanged();
            }
        }

        public List<string> SomeData { get; }

        private string _someDataSelected;

        /// <summary>
        /// 
        /// </summary>
        public string SomeDataSelected
        {
            get => _someDataSelected;
            set
            {
                if (_someDataSelected == value)
                    return;
                if (!SomeData.Contains(value))
                    return;
                _someDataSelected = value;
                OnPropertyChanged();
            }
        }

        public List<TestClass> TestData { get; }

        /// <summary></summary>
        public double ValueForNumericBox
        {
            get => _valueForNumericBox;
            set
            {
                _valueForNumericBox = value;
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
