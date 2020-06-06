using System;
using System.Collections.Generic;
using System.Text;

namespace HARApp.Model
{
    public class Classification
    {
        public float Probability { get; set; }
        public string TagName { get; set; }

        public Classification(string tagName, float probability)
        {
            TagName = tagName;
            Probability = probability;
        }
    }
}
