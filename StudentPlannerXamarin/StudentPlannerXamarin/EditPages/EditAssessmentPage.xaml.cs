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
    public partial class EditAssessmentPage : ContentPage
    {
        Term term;
        Course course;
        Assessment assessmentBeingEdited;
        public EditAssessmentPage(Term term, Course course, Assessment assessment)
        {
            this.term = term;
            this.course = course;
            assessmentBeingEdited = assessment;
            InitializeComponent();

            AssessmentName.Text = assessment.Name;
            AssessmentTypePicker.SelectedItem = assessment.AssessmentType;
            DueDatePicker.Date = assessment.DueDate;
            Description.Text = assessment.Description;
        }

        private void SaveChangesBtn_Clicked(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(dbPath);

            assessmentBeingEdited.Name = AssessmentName.Text;
            assessmentBeingEdited.AssessmentType = AssessmentTypePicker.SelectedItem.ToString();
            assessmentBeingEdited.DueDate = DueDatePicker.Date;
            assessmentBeingEdited.Description = Description.Text;

            db.Update(assessmentBeingEdited);

            Navigation.PopAsync();
            Navigation.PopAsync();
            Navigation.PushAsync(new AssessmentDetailPage(term, course, assessmentBeingEdited));
        }
    }
}