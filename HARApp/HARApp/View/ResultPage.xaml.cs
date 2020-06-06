using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HARApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        public ResultPage(List<List<float>> UCIsegment, string label)
        {
            InitializeComponent();
            (string preciction, float accuracy) = Predict(UCIsegment);
            ShowResult(accuracy, preciction, label);
        }

        private void ShowResult(float accuracy, string preciction, string label)
        {
            Title = "      Preciction for " + label;
            Result.Text = "Predicted: " + preciction;
            Accuracy.Text = "Accuracy: " + accuracy.ToString() + "%";
        }

        private (string, float) Predict(List<List<float>> uCIsegment)
        {
            // Implement the TensorflowClassifier here
            string prediction = "prediction";
            float accuracy = 0;

            return (prediction, accuracy);
        }
    }
}