using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HARApp.Model
{
    class UCIData
    {
        private float acc_x;
        public float acc_X
        {
            get { return acc_x; }
            set { acc_x = value; }
        }

        private float acc_y;
        public float acc_Y
        {
            get { return acc_y; }
            set { acc_y = value; }
        }

        private float acc_z;
        public float acc_Z
        {
            get { return acc_z; }
            set { acc_z = value; }
        }

        private float acc_xy;
        public float acc_XY
        {
            get { return acc_xy; }
            set { acc_xy = value; }
        }

        private float acc_xz;
        public float acc_XZ
        {
            get { return acc_xz; }
            set { acc_xz = value; }
        }

        private float acc_yz;
        public float acc_YZ
        {
            get { return acc_yz; }
            set { acc_yz = value; }
        }

        private float acc_xyz;
        public float acc_XYZ
        {
            get { return acc_xyz; }
            set { acc_xyz = value; }
        }

        private float gyro_x;
        public float gyro_X
        {
            get { return gyro_x; }
            set { gyro_x = value; }
        }

        private float gyro_y;
        public float gyro_Y
        {
            get { return gyro_y; }
            set { gyro_y = value; }
        }

        private float gyro_z;
        public float gyro_Z
        {
            get { return gyro_z; }
            set { gyro_z = value; }
        }

        private string label;
        public string Label
        {
            get { return label; }
            set { label = value; }
        }


        public override string ToString()
        {
            return String.Format("label: {0}", this.Label);
        }

        private static List<UCIData> ReadUCIData()
        {
            List<UCIData> UCIresult = new List<UCIData>();

            var assembly = typeof(UCIData).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("HARApp.Assets.UCIDataset.csv");

            StreamReader oSR = new StreamReader(stream);

            string sLine = oSR.ReadLine();
            sLine = oSR.ReadLine();
            while (sLine != null)
            {
                try
                {
                    Debug.WriteLine(sLine);
                    UCIData UCIdata = CreateUCIData(sLine);
                    UCIresult.Add(UCIdata);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error on line: " + sLine);
                }
                sLine = oSR.ReadLine();
            }
            Debug.WriteLine("----------------------------------------------------------------------");

            oSR.Close();
            return UCIresult;
        }

        private static UCIData CreateUCIData(string sLine)
        {
            UCIData UCIdata = new UCIData();
            String[] parts = sLine.Split(',');
            UCIdata.acc_X = float.Parse(parts[0]);
            UCIdata.acc_Y = float.Parse(parts[1]);
            UCIdata.acc_Z = float.Parse(parts[2]);
            UCIdata.acc_XY = float.Parse(parts[0]) * float.Parse(parts[1]);
            UCIdata.acc_XZ = float.Parse(parts[0]) * float.Parse(parts[2]);
            UCIdata.acc_YZ = float.Parse(parts[1]) * float.Parse(parts[2]);
            UCIdata.acc_XYZ = float.Parse(parts[0]) * float.Parse(parts[1]) * float.Parse(parts[2]);
            UCIdata.gyro_X = float.Parse(parts[3]);
            UCIdata.gyro_Y = float.Parse(parts[4]);
            UCIdata.gyro_Z = float.Parse(parts[5]);
            UCIdata.Label = parts[6];

            return UCIdata;
        }

        public static Dictionary<string, List<List<float>>> GetSegments()
        {
            // Get data from ReadUCIData
            List<UCIData> UCIdata = ReadUCIData();
            List<List<float>> UCIsegment = new List<List<float>>();
            var UCIsegmentDict = new Dictionary<string, List<List<float>>>();
            int counter = 0;

            foreach (UCIData line in UCIdata)
            {
                if (counter == 9)
                {
                    List<float> UCIrow = CreateRow(line);
                    UCIsegment.Add(UCIrow);
                    UCIsegmentDict.Add(line.Label, UCIsegment);
                    counter = 0;
                }
                else
                {
                    List<float> UCIrow = CreateRow(line);
                    UCIsegment.Add(UCIrow);
                    counter += 1;
                }
            }
            return UCIsegmentDict;
        }

        private static List<float> CreateRow(UCIData line)
        {
            List<float> UCIrow = new List<float>();
            UCIrow.Add(line.acc_X);
            UCIrow.Add(line.acc_Y);
            UCIrow.Add(line.acc_Z);
            UCIrow.Add(line.acc_XY);
            UCIrow.Add(line.acc_XZ);
            UCIrow.Add(line.acc_YZ);
            UCIrow.Add(line.acc_XYZ);
            UCIrow.Add(line.gyro_X);
            UCIrow.Add(line.gyro_Y);
            UCIrow.Add(line.gyro_Z);

            return UCIrow;
        }
    }
}
