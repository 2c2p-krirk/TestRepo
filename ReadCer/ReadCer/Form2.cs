using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReadCer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<cData> Col = new List<cData>();
            int i;
            int j;
            int k;
            //int[] Number = this.textBox1.Text.Split(',');
            string[] strNumber = this.textBox1.Text.Split(',');
            System.Text.StringBuilder strB = new StringBuilder();
            for (i = 0; i < strNumber.Length-1; i++)
            {
                
                for (j = i + 1; j < strNumber.Length; j++)
                {
                    cData CurrentData = new cData();
                    
                    CurrentData.LeftIndex = i;                                   
                    CurrentData.RightIndex = j;
                    if (j == i + 1)
                    {
                        CurrentData.Sumvalue = int.Parse(strNumber[i]) + int.Parse(strNumber[j]);
                    }
                    else
                    {
                        CurrentData.Sumvalue = Col [Col.Count -1].Sumvalue + int.Parse(strNumber[j]);
                    }
                    Col.Add(CurrentData);
                    ////cData CurrentData = new cData();
                    ////Col.Add(CurrentData);
                    ////CurrentData.LeftIndex = i;
                    ////CurrentData.RightIndex = j;
                    ////CurrentData.Sumvalue = 0;
                    ////for (k = i; k <= j; k++)
                    ////{
                    ////    CurrentData.Sumvalue += int.Parse (strNumber[k]);
                    ////    strB.Append(strNumber[k]);
                    ////    if (k < j)
                    ////    {
                    ////        strB.Append(",");
                    ////    }
                    ////    else
                    ////    {
                    ////        strB.Append(Environment.NewLine);
                    ////    }
                    ////}
                }
            }
            int Max = int.MinValue;
            int IndexofMax = -1;
            for (i = 0; i < Col.Count; i++)
            {
                if (Col[i].Sumvalue > Max)
                {
                    Max = Col[i].Sumvalue;
                    IndexofMax = i;
                }
            }
            for (i = 0; i < Col.Count; i++)
            {
                if (i > 0)
                {
                    if (Col[i].LeftIndex > Col[i - 1].LeftIndex)
                    {
                        strB.Append("--------------").Append(Environment.NewLine);
                    }
                }
                for (j = Col[i].LeftIndex; j <= Col[i].RightIndex; j++)
                {  
                    
                    
                    strB.Append(strNumber[j]);
                    if (j < Col[i].RightIndex)
                    {
                        strB.Append(",");
                    }
                    else
                    {
                        strB.Append("   [").Append(Col[i].Sumvalue.ToString()).Append ("]");
                        strB.Append(Environment.NewLine);
                      

                    }
                    
                }
                
            }
            this.textBox2.Text = Col[IndexofMax].LeftIndex.ToString() + "," +
                Col[IndexofMax].RightIndex.ToString() + "," +
                Col[IndexofMax].Sumvalue.ToString();
            this.textBox2.Text += Environment.NewLine + strB.ToString();
            

        }
    }
}