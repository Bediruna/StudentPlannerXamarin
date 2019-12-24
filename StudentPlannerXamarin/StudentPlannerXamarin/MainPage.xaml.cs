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
        }

        void TermBtnClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TermViewPage());
        }
    }
}
