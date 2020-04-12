namespace ModPlusStyleDemo
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            SomeData = new List<string>
            {
                "313221",
                "jhrgrjhgrj",
                "HHHJHJHJH"
            };
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
        private string _testTextBoxValidationValue = "B";

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

        private ModPlusStyle.Theme _currentTheme;

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

        public List<TestClass> TestData { get; }

        private double _valueForNumericBox;

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
