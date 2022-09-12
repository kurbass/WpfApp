using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.Infrastructure;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace WpfApp1.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        MyColor _selectedColor;
        public MyColor SelectedColor
        {
            get => _selectedColor;
            set
            {
                if (_selectedColor != value)
                {
                    _selectedColor = value;
                    OnPropertyChanged();
                }
            }
        }
        byte _alpha;
        public byte Alpha
        {
            get => _alpha;
            set
            {
                if (value != _alpha)
                {
                    _alpha = value;
                    Brush = new SolidColorBrush(Color.FromArgb(Alpha, Red, Green, Blue));
                    OnPropertyChanged();
                }
            }
        }
        byte _red;
        public byte Red
        {
            get => _red;
            set
            {
                if (value != _red)
                {
                    _red = value;
                    Brush = new SolidColorBrush(Color.FromArgb(Alpha, Red, Green, Blue));
                    OnPropertyChanged();
                }
            }
        }
        byte _green;
        public byte Green
        {
            get => _green;
            set
            {
                if (value != _green)
                {
                    _green = value;
                    Brush = new SolidColorBrush(Color.FromArgb(Alpha, Red, Green, Blue));
                    OnPropertyChanged();
                }
            }
        }
        byte _blue;
        public byte Blue
        {
            get => _blue;
            set
            {
                if (value != _blue)
                {
                    _blue = value;
                    Brush = new SolidColorBrush(Color.FromArgb(Alpha, Red, Green, Blue));
                    OnPropertyChanged();
                }
            }
        }
        SolidColorBrush _brush;
        public SolidColorBrush Brush
        {
            get => _brush;
            set
            {
                if (value != _brush)
                {
                    _brush = value;
                    OnPropertyChanged();
                }
            }
        }
        RelayCommand _delCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _delCommand ?? (_delCommand = new RelayCommand(DelCommandMethod, CanDelMethod));
            }
        }
        void DelCommandMethod(object param)
        {
            Colors.Remove(SelectedColor);
        }
        bool CanDelMethod(object param)
        {
            return SelectedColor != null;
        }
        RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(AddCommandMethod, CanAddMethod));
            }
        }
        void AddCommandMethod(object param)
        {
            Colors.Add(new MyColor() { Alpha = Alpha, Blue = Blue, Green = Green, Red = Red});
        }
        bool CanAddMethod(object param)
        {
            foreach (var item in Colors)
            {
                if (item.MyBrush == Brush)
                    return false;
            }
            return true;
        }
        public ObservableCollection<MyColor> Colors { get; set; }
        public MainWindowViewModel()
        {
            Colors = new ObservableCollection<MyColor>
            {
                new MyColor{Alpha = 255,Red = 231,Green = 103,Blue = 212 },
            };
        }
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
