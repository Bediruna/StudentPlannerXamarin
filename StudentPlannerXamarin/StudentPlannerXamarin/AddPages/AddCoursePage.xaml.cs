using StudentPlannerXamarin.DataModels;
using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentPlannerXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCoursePage : ContentPage
    {
        Term termAddedto;
        public AddCoursePage(Term term)
        {
            termAddedto = term;
            InitializeComponent();
            CourseStatusPicker.Items.Add("Completed");
            CourseStatusPicker.Items.Add("Enrolled");
            CourseStatusPicker.Items.Add("Pending");
        }

        private void AddCourse_Clicked(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(dbPath);
            Course newCourse = new Course
            {
                TermId = termAddedto.Id,
                Name = CourseName.Text,
                StartDate = StartDatePicker.Date,
                EndDate = EndDatePicker.Date,
                Status = CourseStatusPicker.SelectedItem.ToString(),
                InstructorName = InstructorName.Text,
                InstructorPhone = InstructorPhone.Text,
                InstructorEmail = InstructorEmail.Text,
                Notes = Notes.Text
            };
            db.Insert(newCourse);

            Navigation.PopAsync();
            Navigation.PopAsync();
            Navigation.PushAsync(new TermDetailPage(termAddedto));
        }
    }
}