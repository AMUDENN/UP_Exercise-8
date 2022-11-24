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

namespace UP_Exercise_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Dictionary<string, string> langs = new Dictionary<string, string>
        {
            { "Русский", "ru" },
            { "Английский", "en"}
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetResultClick(object sender, RoutedEventArgs e)
        {
            InputText.SpellCheck.IsEnabled = true;
        }
        private void ClearField(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rsltMessageBox = MessageBox.Show("Вы уверены, что хотите очистить поле?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (rsltMessageBox == MessageBoxResult.Yes)
            {
                InputText.Text = "";
                InputText.SpellCheck.IsEnabled = false;
            }
        }
        private void GetLanguageClick(object sender, RoutedEventArgs e)
        {
            InputText.Language = System.Windows.Markup.XmlLanguage.GetLanguage(langs[((RadioButton)sender).Content.ToString()]);
        }
    }
}
