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
    public partial class CourseDetailPage : ContentPage
    {
        Term associatedTerm;
        Course courseViewed;
        public CourseDetailPage(Term term, Course course)
        {
            associatedTerm = term;
            courseViewed = course;
            InitializeComponent();
            Title = course.Name;
            StartDateLabel.Text = "Start Date: " + course.StartDate.ToString("dd/MM/yy");
            EndDateLabel.Text = "End Date: " + course.EndDate.ToString("dd/MM/yy");
            StatusLabel.Text = "Status: " + course.Status;
            InstructorNameLabel.Text = "Instructor Name: " + course.InstructorName;
            InstructorPhoneLabel.Text = "Instructor Phone: " + course.InstructorPhone;
            InstructorEmailLabel.Text = "Instructor Name: " + course.InstructorEmail;
            NotesLabel.Text = "Notes: " + course.Notes;


            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(dbPath);
            db.CreateTable<Assessment>();

            var courseTable = db.Table<Assessment>().Where(v => v.CourseId.Equals(course.Id));
            this.BindingContext = courseTable;
        }

        private void AddAssessmentBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void AssessmentListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void DeleteCourseBtn_Clicked(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(dbPath);
            db.Delete(courseViewed);
            Navigation.PopAsync();
            Navigation.PopAsync();
            Navigation.PushAsync(new TermDetailPage(associatedTerm));
        }

        private void EditCourseBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}