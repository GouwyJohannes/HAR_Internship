using HARApp.Model;
using HARApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HARApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public Dictionary<string, List<List<float>>> UCIsegmentDict;

        public MainPage()
        {
            InitializeComponent();
            LoadSegments();
        }

        private void LoadSegments()
        {
            UCIsegmentDict = UCIData.GetSegments();
            Debug.WriteLine("Segments of data: " + UCIsegmentDict.Count());
        }

        private void StdButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Std");
            string label = "std";
            List<List<float>> UCIsegment = UCIsegmentDict[label];
            Navigation.PushAsync(new ResultPage(UCIsegment, label));
        }
        private void DwsButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Dws");
            string label = "dws";
            List<List<float>> UCIsegment = UCIsegmentDict[label];
            Navigation.PushAsync(new ResultPage(UCIsegment, label));
        }
        private void LyButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Ly");
            string label = "ly";
            List<List<float>> UCIsegment = UCIsegmentDict[label];
            Navigation.PushAsync(new ResultPage(UCIsegment, label));
        }
        private void WlkButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Wlk");
            string label = "wlk";
            List<List<float>> UCIsegment = UCIsegmentDict[label];
            Navigation.PushAsync(new ResultPage(UCIsegment, label));
        }
        private void SitButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Sit");
            string label = "sit";
            List<List<float>> UCIsegment = UCIsegmentDict[label];
            Navigation.PushAsync(new ResultPage(UCIsegment, label));
        }
        private void UpsButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Ups");
            string label = "ups";
            List<List<float>> UCIsegment = UCIsegmentDict[label];
            Navigation.PushAsync(new ResultPage(UCIsegment, label));
        }
    }
}
