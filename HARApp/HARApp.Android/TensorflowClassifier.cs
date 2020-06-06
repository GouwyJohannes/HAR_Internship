using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HARApp.Model;
using Java.IO;
using Java.Nio;
using Java.Nio.Channels;

namespace HARApp.Droid
{
    class TensorflowClassifier
    {
        public async Task Classify(List<List<float>> dataframe)
        {
            var mappedByteBuffer = GetModelAsMappedByteBuffer();

            var interpreter = new Xamarin.TensorFlow.Lite.Interpreter(mappedByteBuffer);

            var tensor = interpreter.GetInputTensor(0);

            var shape = tensor.Shape();

            var width = shape[1];
            var height = shape[2];


            var sr = new StreamReader(Application.Context.Assets.Open("labels.txt"));
            var labels = sr.ReadToEnd().Split('\n').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();

            var outputLocations = new float[1][] { new float[labels.Count] };

            var outputs = Java.Lang.Object.FromArray(outputLocations);

            //interpreter.Run(dataframe, outputs);

            var classificationResult = outputs.ToArray<float[]>();

            var result = new List<Classification>();
        }

        private object GetDataframeAsByteBuffer(List<List<float>> dataframe)
        {
            throw new NotImplementedException();
        }

        private MappedByteBuffer GetModelAsMappedByteBuffer()
        {
            var assetDescriptor = Application.Context.Assets.OpenFd("LSTM_V6_model4.tflite");
            var inputStream = new FileInputStream(assetDescriptor.FileDescriptor);

            var mappedByteBuffer = inputStream.Channel.Map(FileChannel.MapMode.ReadOnly, assetDescriptor.StartOffset, assetDescriptor.DeclaredLength);

            return mappedByteBuffer;
        }

    }
}