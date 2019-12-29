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
        Term termViewed;
        public TermDetailPage(Term term)
        {
            termViewed = term;
            Title = term.Name;
            InitializeComponent();
            StartDateLabel.Text = "Start Date: " + term.StartDate.ToString("dd/MM/yy");
            EndDateLabel.Text = "End Date: " + term.EndDate.ToString("dd/MM/yy");

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(dbPath);
            db.CreateTable<Course>();

            var courseTable = db.Table<Course>().Where(v => v.TermId.Equals(term.Id)) ;
            this.BindingContext = courseTable;
        }

        private void ClassesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            var selectedCourse = (Course)((ListView)sender).SelectedItem;
            Navigation.PushAsync(new CourseDetailPage(termViewed, selectedCourse));
        }

        private void DeleteTermBtn_Clicked(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(dbPath);
            db.Delete(termViewed);
            Navigation.PopAsync();
            Navigation.PopAsync();
            Navigation.PushAsync(new TermViewPage());
        }

        private void EditTermBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void AddCourseBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCoursePage(termViewed));
        }
    }
}