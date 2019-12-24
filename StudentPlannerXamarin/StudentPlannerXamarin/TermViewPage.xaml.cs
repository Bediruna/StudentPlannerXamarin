using StudentPlannerXamarin.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentPlannerXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermViewPage : ContentPage
    {
        public TermViewPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(dbPath);

            var termTable = db.Table<Term>();
            List<(string, string)> stringList = new List<(string, string)>();
            foreach (var term in termTable)
            {                
                stringList.Add((term.Name, term.StartDate.ToString("dd/MM/yy") + " - " + term.EndDate.ToString("dd/MM/yy")));
            }

            this.BindingContext = stringList;
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        public ICommand MyCommand { private set; get; }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTermPage());
        }
    }
}