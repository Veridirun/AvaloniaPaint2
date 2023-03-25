using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaPaint.ViewModels;
using System.Linq;

namespace AvaloniaPaint.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnExportMenuClickXML(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] {"xml"}.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if(this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SaveFigures(path);
                }
            }
        }
        private async void OnImportMenuClickXML(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadFigures(path[0]);
                }
            }
        }
    }
}
