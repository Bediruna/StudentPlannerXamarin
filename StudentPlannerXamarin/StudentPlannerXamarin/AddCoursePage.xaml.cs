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
    public partial class AddCoursePage : ContentPage
    {
        public AddCoursePage()
        {
            InitializeComponent();
            CourseStatusPicker.Items.Add("Enrolled");
            CourseStatusPicker.Items.Add("Completed");
            CourseStatusPicker.Items.Add("Pending");
        }

        private void AddCourse_Clicked(object sender, EventArgs e)
        {
            string courseName = CourseName.Text;
            DateTime startDate = StartDatePicker.Date;
            DateTime endDate = EndDatePicker.Date;

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(dbPath);
            Course newCourse = new Course
            {
                Name = courseName,
                StartDate = startDate,
                EndDate = endDate
            };
            db.Insert(newCourse);

            Navigation.RemovePage(this);
        }
    }
}