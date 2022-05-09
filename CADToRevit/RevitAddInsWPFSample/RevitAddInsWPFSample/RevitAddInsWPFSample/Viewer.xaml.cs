using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Autodesk.Revit.DB;

namespace RevitAddInsWPFSample
{
    /// <summary>
    /// Interaction logic for Viewer.xaml
    /// </summary>
    public partial class Viewer : Window
    {
        // fields
        public Document document;
        // constructor
        public Viewer(Document doc)
        {
            // assign value to field
            document = doc;
            InitializeComponent();
            // display view
            DisplayTreeViewItem();
        }

        public void DisplayTreeViewItem()
        {
            // viewtypename and treeviewitem dictionary
            SortedDictionary<string,TreeViewItem> ViewTypeDictionary = new SortedDictionary<string, TreeViewItem>();
            // viewtypename
            List<string> viewTypenames = new List<string>();
            
            // collect view type
            List<Element> elements = new FilteredElementCollector(document).OfClass(typeof(View)).ToList();
            
            foreach (Element element in elements)
            {
                // view
                View view = element as View;
                // view typename
                viewTypenames.Add(view.ViewType.ToString());
            }
                      
            // create treeviewitem for viewtype
            foreach (string viewTypename in viewTypenames.Distinct().OrderBy(name => name).ToList())
            {
                // create viewtype treeviewitem
                TreeViewItem viewTypeItem = new TreeViewItem() { Header = viewTypename };
                // store in dict
                ViewTypeDictionary[viewTypename] = viewTypeItem;
                // add to treeview
                treeview.Items.Add(viewTypeItem);
            }

            foreach (Element element in elements)
            {
                // view
                View view = element as View;
                // viewname
                string viewName = view.Name;
                // view typename
                string viewTypename = view.ViewType.ToString();          
                // create view treeviewitem 
                TreeViewItem viewItem = new TreeViewItem() { Header = viewName };
                // view item add to view type
                ViewTypeDictionary[viewTypename].Items.Add(viewItem);
            }
        }
    }
}
