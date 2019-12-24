using System.IO;
using System.ComponentModel;
using Xamarin.Forms;
using StudentPlannerXamarin.DataModels;
using System.Collections.Generic;

namespace StudentPlannerXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ormdemo.db3");
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(dbPath);
            db.DropTable<Term>();
            db.CreateTable<Term>();
            Term newTerm = new Term();

            newTerm.Name = "AAPL";
            db.Insert(newTerm);
            newTerm.Name = "GOOG";
            db.Insert(newTerm);
            newTerm.Name = "MSFT";
            db.Insert(newTerm);


            var table = db.Table<Term>();
            List<string> stringList = new List<string>();
            foreach (var s in table)
            {
                stringList.Add(s.Name);
            }

            this.BindingContext = stringList;
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        void TermBtnClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TermViewPage());
        }
    }
}
