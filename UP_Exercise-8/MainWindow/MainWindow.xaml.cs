using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace UP_Exercise_8
{
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
            RadioRus.IsChecked = true;
            Closing += ShowCloseMessage;
        }
        private void ShowCloseMessage(object sender, CancelEventArgs e)
        {
            if (ActionConfirmation("Вы уверены, что хотите закрыть приложение?") == MessageBoxResult.No) e.Cancel = true;
        }
        private void GetResultClick(object sender, RoutedEventArgs e)
        {
            InputText.SpellCheck.IsEnabled = true;
        }
        private void ClearField(object sender, RoutedEventArgs e)
        {
            if (ActionConfirmation("Вы уверены, что хотите очистить поле?") == MessageBoxResult.Yes)
            {
                InputText.Clear();
                InputText.SpellCheck.IsEnabled = false;
            }
        } 
        private MessageBoxResult ActionConfirmation(string question) => MessageBox.Show(question, "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
        private void GetLanguageClick(object sender, RoutedEventArgs e)
        {
            InputText.Language = System.Windows.Markup.XmlLanguage.GetLanguage(langs[((RadioButton)sender).Content.ToString()]);
            LangName.Header = ((RadioButton)sender).Content.ToString();
        }
        private void InputTextChanged(object sender, TextChangedEventArgs e)
        {
            Counter.Content = InputText.Text.Length;
        }
    }
}