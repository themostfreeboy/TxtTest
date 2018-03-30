using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//文件读写需要

namespace TxtTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] myByte = new byte[100];
            char[] myChar = new char[100];
            try
            {
                FileStream myFS = new FileStream(@".\in.txt", FileMode.Open);
                myFS.Seek(0, SeekOrigin.Begin);//设置流的当前位置为文件开始位置
                myFS.Read(myByte, 0, 100);
                //Decoder myDecoder = Encoding.UTF8.GetDecoder();//通过UFT-8编码方法将字节数组转换成字符数组
                //Decoder myDecoder = Encoding.ASCII.GetDecoder();//通过ASCII编码方法将字节数组转换成字符数组
                Decoder myDecoder = Encoding.Default.GetDecoder();//通过ANSI编码方法将字节数组转换成字符数组
                myDecoder.GetChars(myByte, 0, myByte.Length, myChar, 0);
                myFS.Close();
                MessageBox.Show(new string(myChar));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] myByte = new byte[100];
            char[] myChar = new char[100];
            try
            {
                FileStream myFS = new FileStream(@".\out.txt", FileMode.OpenOrCreate);
                myFS.Close();
                myFS = new FileStream(@".\out.txt", FileMode.Truncate);
                myChar = "hello5678你好".ToCharArray();//将要写入的字符串转换成字符数组
                //Encoder myEncoder = Encoding.UTF8.GetEncoder();//通过UFT-8编码方法将字节数组转换成字节数组
                //Encoder myEncoder = Encoding.ASCII.GetEncoder();//通过ASCII编码方法将字节数组转换成字节数组
                Encoder myEncoder = Encoding.Default.GetEncoder();//通过ANSI编码方法将字节数组转换成字节数组
                myEncoder.GetBytes(myChar, 0, myChar.Length, myByte, 0, true);
                int mylength = System.Text.Encoding.Default.GetByteCount(new string(myChar));
                System.Console.WriteLine("myChar.Length=" + myChar.Length);
                System.Console.WriteLine("mylength=" + mylength);
                myFS.Seek(0, SeekOrigin.Begin);//设置流的当前位置为文件开始位置
                myFS.Write(myByte, 0, mylength);//将字节数组中的内容写入文件
                System.Console.WriteLine("myByte.Length=" + myByte.Length);
                myFS.Close();
                MessageBox.Show(new string(myChar));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strs = File.ReadAllLines(@".\in.txt", Encoding.Default);
                for (int i = 0; i < strs.Length; i++)
                {
                    MessageBox.Show(strs[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strs = { "Good Morning!", "Good Afternoon!" };
                File.WriteAllLines(@".\out.txt", strs, Encoding.Default);
                for (int i = 0; i < strs.Length; i++)
                {
                    MessageBox.Show(strs[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strs = File.ReadAllLines(@".\in.txt", Encoding.Default);
                for (int i = 0; i < strs.Length; i++)
                {
                    char[] tempchar = strs[i].ToCharArray();
                    int tabnum = 0;
                    int spacenum = 0;
                    int enternum = 0;
                    for (int j = 0; j < tempchar.Length; j++)
                    {
                        if (tempchar[j] == '\t')
                        {
                            tabnum++;
                        }
                        else if (tempchar[j] == ' ')
                        {
                            spacenum++;
                        }
                        else if (tempchar[j] == '\n')
                        {
                            enternum++;
                        }
                    }
                    MessageBox.Show("strs=" + strs[i] + "\ntabnum=" + tabnum + "\nspacenum=" + spacenum + "\nenternum=" + enternum);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strs = { "G\to\to\td Morning!", "Good Afternoon!" };
                File.WriteAllLines(@".\out.txt", strs, Encoding.Default);
                for (int i = 0; i < strs.Length; i++)
                {
                    MessageBox.Show(strs[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strs = File.ReadAllLines(@".\in.txt", Encoding.Default);
                for (int i = 0; i < strs.Length; i++)
                {
                    strs[i].Replace('\t', ' ');//将所有的'\t'都替换为空格
                    char[] delimiterChars = { ' ', '\t', '\r', '\n' };//分割字符串所采用的分割字符
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(?is)(\s+)");//使用正则表达式将多个连续的空格合并为一个空格
                    string result = regex.Replace(strs[i], " ");
                    string[] words = result.Split(delimiterChars);//使用分割字符将字符串分割
                    for (int j = 0; j < words.Length; j++)
                    {
                        MessageBox.Show(words[j]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strs = File.ReadAllLines(@".\in.txt", Encoding.Default);
                System.Data.DataTable dt = new System.Data.DataTable();
                for (int i = 0; i < strs.Length; i++)
                {
                    strs[i].Replace('\t', ' ');//将所有的'\t'都替换为空格
                    char[] delimiterChars = { ' ', '\t', '\r', '\n' };//分割字符串所采用的分割字符
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(?is)(\s+)");//使用正则表达式将多个连续的空格合并为一个空格
                    string result = regex.Replace(strs[i], " ");
                    string[] words = result.Split(delimiterChars);//使用分割字符将字符串分割
                    if (i == 0)//表标题
                    {
                        for (int j = 0; j < words.Length; j++)
                        {
                            dt.Columns.Add(words[j]);
                        }
                    }
                    else//表内容
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < words.Length; j++)
                        {
                            dr[j] = words[j];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = GetDgvToTable(dataGridView1);
                System.IO.StreamWriter file = new System.IO.StreamWriter(@".\out.txt", false, Encoding.Default);
                string tempstr = string.Empty;

                #region 写入表头
                for(int i=0;i<dt.Columns.Count;i++)
                {
                    tempstr = tempstr + dt.Columns[i].ColumnName;
                    if (tempstr.Length < 20 * (i + 1))//为使在txt中的内容每列左对齐，每个字段不足20字符在右边补空格至20字符
                    {
                        tempstr = tempstr.PadRight(20 * (i + 1), ' ');
                    }
                }
                file.WriteLine(tempstr);// 直接追加文件末尾，换行
                #endregion

                #region 写入表中数据
                for (int i=0;i<dt.Rows.Count-1;i++)
                {
                    int j = 0;
                    tempstr = string.Empty;
                    for(j=0;j<dt.Columns.Count;j++)
                    {
                        tempstr = tempstr + dt.Rows[i][j].ToString();
                        if (tempstr.Length < 20 * (j + 1))//为使在txt中的内容每列左对齐，每个字段不足20字符在右边补空格至20字符
                        {
                            tempstr = tempstr.PadRight(20 * (j + 1), ' ');
                        }
                    }
                    file.WriteLine(tempstr);// 直接追加文件末尾，换行
                }
                #endregion

                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static System.Data.DataTable GetDgvToTable(DataGridView dgv)//将DataGridView控件中的内容转化成System.Data.DataTable
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)//列强制转换
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)//循环行
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
