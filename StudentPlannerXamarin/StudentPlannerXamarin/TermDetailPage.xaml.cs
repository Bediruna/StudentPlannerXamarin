using StudentPlannerXamarin.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentPlannerXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermDetailPage : ContentPage
    {
        public TermDetailPage(Term term)
        {
            Title = term.Name;
            InitializeComponent();
            StartDateLabel.Text = "Start Date: " + term.StartDate.ToString("dd/MM/yy");
            EndDateLabel.Text = "End Date: " + term.EndDate.ToString("dd/MM/yy");

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(dbPath);
            db.CreateTable<Course>();

            var courseTable = db.Table<Course>();
            List<Course> courseList = new List<Course>();
            foreach (var course in courseTable)
            {
                courseList.Add(course);
            }

            this.BindingContext = courseList;
        }

        private void AddClassBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCoursePage());
        }

        private void ClassesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}