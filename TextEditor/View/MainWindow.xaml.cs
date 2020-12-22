using System.Windows;
using System.Windows.Controls;

using TextEditor.ViewModel;

namespace TextEditor.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Count { get; set; } 
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            Count = textBox.Text.Length;
            Lb.Content = Count;
        }
    }
}
