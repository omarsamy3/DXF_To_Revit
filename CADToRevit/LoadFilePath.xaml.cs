using Autodesk.Revit.DB;
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

namespace CADToRevit
{
    /// <summary>
    /// Interaction logic for LoadFilePath.xaml
    /// </summary>
    public partial class LoadFilePath : Window
    {
        // fields
        public Document document;
        public string filePath;
        public LoadFilePath(Document doc)
        {
            // assign value to field
            document = doc;
            InitializeComponent();
        }

        // Browse the file
        private void BrowseFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog Open = new Microsoft.Win32.OpenFileDialog();
            Open.DefaultExt = ".dxf";
            Open.Filter = "Drawing (.dxf)|*.dxf";
            bool? response = Open.ShowDialog();

            if (response == true)
            {
                filePathLabel.Content = Open.FileName;
                filePath = Open.FileName;
                GlobalVariable.file = filePath;
            }
        }
        private void CloseDialog(object sender, EventArgs e)
        {
            DialogResult = false;
        }



    }
}
