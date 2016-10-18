using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CScrollContent
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private GeneratorIncrementalLoadingClass<Employee> employees;
        public MainPage()
        {
            this.InitializeComponent();
            Scenario8Reset();
            //System.Diagnostics.Debug.WriteLine(RootScroller.ActualHeight);
            System.Diagnostics.Debug.WriteLine(lvEmployees.ActualHeight);
        }
        private void Scenario8Reset()
        {
            if (employees != null)
            {
                employees.CollectionChanged -= _employees_CollectionChanged;
            }

            employees = new GeneratorIncrementalLoadingClass<Employee>(1000, (count) =>
            {
                return new Employee() { Name = "Name" + count, Organization = "Organization" + count };
            });
            employees.CollectionChanged += _employees_CollectionChanged;

            lvEmployees.ItemsSource = employees;


            tbCollectionChangeStatus.Text = String.Empty;
        }

        void _employees_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            tbCollectionChangeStatus.Text = String.Format("Collection was changed. Count = {0}", employees.Count);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("scrollerview actual height:"+RootScroller.ActualHeight);
            System.Diagnostics.Debug.WriteLine("listview actual height:" + lvEmployees.ActualHeight);
            lvEmployees.Height = RootScroller.ActualHeight;
        }
    }
}
