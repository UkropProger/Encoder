using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace encode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // if (comboBox1.Text = ".jpg") openFileDialog1.Filter = ".jpg"
            textBox6.Enabled = true;
            openFileDialog1.Filter = "Video Files(*.wav;)|*.wav|Image Files(*.jpg)|*.jpg|Audio Files(*.mp3)|*.mp3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = openFileDialog1.FileName;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                textBox2.Text = saveFileDialog1.FileName;
        }

        //@"C:\Users\alimz\Desktop\скачуха\note.txt"
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                using (FileStream fstream = File.OpenRead(Path.Combine(openFileDialog1.FileName)))
                {
                    byte[] array;
                    int[] n;
                    var rnd = new Random();
                    int key = 0;
                    if (checkBox1.Checked == false)
                    {

                        key = rnd.Next(100, 255);
                        array = new byte[fstream.Length];
                        n = new int[fstream.Length];
                        // считываем данные
                        fstream.Read(array, 0, array.Length);
                        for (int i = 0; i < array.Length; i++)
                        {
                            n[i] = Convert.ToInt32(array[i] ^ key);
                            array[i] = Convert.ToByte(n[i]);
                        }
                        MessageBox.Show("Ваш ключ:" + Convert.ToString(key));
                        using (FileStream fstream1 = new FileStream(Path.Combine(saveFileDialog1.FileName), FileMode.OpenOrCreate))
                        {
                            fstream1.Write(array, 0, array.Length);
                        }
                    }

                    else if (textBox6.Text != "")
                    {

                        if (Convert.ToInt32(textBox6.Text) > 255)
                            key = Convert.ToByte(Convert.ToInt32(textBox6.Text) % 255);
                        else
                            key = Convert.ToByte(Convert.ToInt32(textBox6.Text));
                        // преобразуем строку в байты
                        array = new byte[fstream.Length];
                        n = new int[fstream.Length];
                        // считываем данные
                        fstream.Read(array, 0, array.Length);
                        for (int i = 0; i < array.Length; i++)
                        {
                            n[i] = Convert.ToInt32(array[i] ^ key);
                            array[i] = Convert.ToByte(n[i]);
                        }
                        MessageBox.Show("Готово");
                        using (FileStream fstream1 = new FileStream(Path.Combine(saveFileDialog1.FileName), FileMode.OpenOrCreate))
                        {
                            fstream1.Write(array, 0, array.Length);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите ключ или выберите автоматическую генерацию ключа в настройках");
                    }
                }
            }
            else MessageBox.Show("Выберите файл и папку для сохранения");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
                textBox3.Text = openFileDialog2.FileName;
            textBox4.Enabled = true;
            button6.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                textBox4.Text = saveFileDialog2.FileName;
            button8.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (FileStream fstream = File.OpenRead(Path.Combine(openFileDialog2.FileName)))
            {
                if (textBox5.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    int key = 0;
                    if (Convert.ToInt32(textBox5.Text) > 255)
                        key = Convert.ToByte(Convert.ToInt32(textBox5.Text) % 255);
                    else
                        key = Convert.ToByte(Convert.ToInt32(textBox5.Text));
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    int[] n = new int[fstream.Length];
                    // считываем данные
                    fstream.Read(array, 0, array.Length);
                    for (int i = 0; i < array.Length; i++)
                    {
                        n[i] = Convert.ToInt32(array[i] ^ key);
                        array[i] = Convert.ToByte(n[i]);
                    }
                    MessageBox.Show("Готово");
                    using (FileStream fstream1 = new FileStream(Path.Combine(saveFileDialog2.FileName), FileMode.OpenOrCreate))
                    {
                        fstream1.Write(array, 0, array.Length);
                    }
                }
                else MessageBox.Show("Заполните все поля");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox6.Visible = true;
                label1.Visible = true;
            }
            else
            {
                textBox6.Visible = false;
                label1.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
