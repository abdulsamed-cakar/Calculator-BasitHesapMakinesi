using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hesapmakinesi
{
    public partial class Form1 : Form
    {
        int sayac1 = 1;
        int sayac2 = 1;
        string islem;
        bool btnClick = true; 
        public Form1()
        {
            InitializeComponent();
        }

        //Butona basınca basılan butonun Textini yazdıran kod.
        private void Buton(object sender, EventArgs e) 
        {
            Button btn = (Button)sender;

            if (label4.Text == string.Empty && btnClick == true)
            {
                if (label2.Text == string.Empty)
                {
                    label1.Text = label1.Text + btn.Text;
                }
                else
                {
                    label3.Text = label3.Text + btn.Text;
                }
            }
        }

        //Toplama İşlemi Oluşturma
        private void button13_Click(object sender, EventArgs e) 
        {
            if (label1.Text != string.Empty)
            {
                label2.Text = "+";
                islem = "toplama";
            }
        }

        //Çarpma İşlemi Oluşturma
        private void button3_Click(object sender, EventArgs e) 
        {
            if (label1.Text != string.Empty)
            {
                label2.Text = "*";
                islem = "carpma";
            }
        }

        //Çıkarma İşlemi
        private void button9_Click(object sender, EventArgs e) 
        {
            if (label1.Text != string.Empty)
            {
                if (label4.Text == string.Empty)
                {
                    if (label2.Text == string.Empty)
                    {
                        label2.Text = "-";
                    }
                    else
                    {
                        if (label2.Text != "-")
                        {
                            label2.Text = "-";
                        }
                        else
                        {
                            label3.Text = "-";
                        }
                    }
                }
                else
                {
                    label2.Text = "-";
                }
            }
            islem = "cikarma";
        }

        //Fibonacci Fonksiyonu
        private int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        //Bölme İşlemi Tanımlama
        private void button17_Click(object sender, EventArgs e) 
        {
            if (label1.Text != string.Empty)
            {
                label2.Text = "/";
                islem = "bolme";
            }
        }

        int ks1;
        int faktoryel = 1;
        double sonuc;

        //Eşittir Butonu
        private void button25_Click(object sender, EventArgs e) 
        {
            try
            {
                //Kök Alma İşlemi
                if (islem == "sqrt")
                {
                    double sonuc = Math.Sqrt(Convert.ToDouble(label1.Text));
                    label4.Text = $"{sonuc:0.000}";
                }
                //Faktoryel Hesaplama
                else if (islem == "!")
                {
                    try
                    {
                        int sayi = Convert.ToInt32(label1.Text);
                        int faktoriyel = 1;

                        if (sayi < 0)
                        {
                            MessageBox.Show("Faktöriyel negatif sayılar için tanımsızdır.", "Hata!", MessageBoxButtons.OK);
                        }
                        else
                        {
                            for (int i = 1; i <= sayi; i++)
                            {
                                faktoriyel *= i;
                            }

                            label2.Text = "!";
                            islem = "!";
                            label4.Text = faktoriyel.ToString();
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Lütfen pozitif bir sayı girin.", "Hata!", MessageBoxButtons.OK);
                    }
                }
                //Fibonacci Hesaplama
                else if (islem == "f")
                {
                    int n = Convert.ToInt32(label1.Text);
                    if (n < 0)
                    {
                        MessageBox.Show("Fibonacci sayısı negatif olamaz.", "Hata!", MessageBoxButtons.OK);
                    }
                    else
                    {
                        int result = Fibonacci(n);
                        label4.Text = result.ToString();
                        btnClick = false;
                    }
                }
                else
                {
                    if (label3.Text != string.Empty)
                    {
                        //Toplama İşlemi yapma
                        if (islem == "toplama")
                        {
                            double sonuc = Convert.ToDouble(label1.Text) + Convert.ToDouble(label3.Text);
                            label4.Text = $"{sonuc:0.000}";
                        }
                        //Çıkarma İşlemi yapma
                        else if (islem == "cikarma")
                        {
                            double sonuc = Convert.ToDouble(label1.Text) - Convert.ToDouble(label3.Text);
                            label4.Text = $"{sonuc:0.000}";
                        }
                        //Çarpma İşlemi yapma
                        else if (islem == "carpma") 
                        {
                            double sonuc = Convert.ToDouble(label1.Text) * Convert.ToDouble(label3.Text);
                            label4.Text = $"{sonuc:0.000}";
                        }
                        //Bölme İşlemi yapma
                        else if (islem == "bolme")
                        {
                            if (Convert.ToDouble(label1.Text) == 0)
                            {
                                label4.Text = "0.000";
                            }
                            else if (Convert.ToDouble(label3.Text) == 0)
                            {
                                label4.Text = "∞";
                            }
                            else
                            {
                                double sonuc = Convert.ToDouble(label1.Text) / Convert.ToDouble(label3.Text);
                                label4.Text = $"{sonuc:0.000}";
                            }
                        }
                        //Ebob Alma 
                        else if (islem == "ebob")
                        {
                            ks1 = Convert.ToInt32(label3.Text);

                            if (Convert.ToInt32(label1.Text) < Convert.ToInt32(label3.Text))
                            {
                                ks1 = Convert.ToInt32(label1.Text);
                            }

                            for (int i = 1; i <= ks1; i++)
                            {
                                if ((Convert.ToInt32(label1.Text)) % i == 0 && (Convert.ToInt32(label3.Text)) % i == 0)
                                {
                                    label4.Text = i.ToString();
                                }
                            }
                        }
                        //Üs alma
                        else if (islem == "pow")
                        {
                            double sonuc = Math.Pow(Convert.ToDouble(label1.Text), Convert.ToDouble(label3.Text));
                            label4.Text = $"{sonuc:0.000}";
                        }
                        //Mod alma
                        else if (islem == "mod")
                        {
                            double sonuc = Convert.ToDouble(label1.Text) % Convert.ToDouble(label3.Text);
                            label4.Text = $"{sonuc:0.000}";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hesaplama işlemi için önce sayılar girilmeli!", "Hata!", MessageBoxButtons.OK);
                    }
                }
            }
            catch (FormatException)
            {
            }
            catch (OverflowException)
            {
            }

        }

        //Girilen rakamın " - " lisini alma
        private void button5_Click(object sender, EventArgs e)
        {
            
            if (label4.Text == string.Empty)
            {
                if (label1.Text != "0")
                {
                    if (label1.Text.StartsWith("-"))
                    {
                        label1.Text = label1.Text.Replace("-", "");
                    }
                    else if (label1.Text.StartsWith(""))
                    {
                        label1.Text = "-" + label1.Text;
                    }
                }
            }
        }

        // " , " Koyma 
        private void button18_Click(object sender, EventArgs e)
        {
            if (label2.Text == string.Empty)
            {

                if (label1.Text != string.Empty)
                {
                    if (sayac1 == 1)
                    {
                        label1.Text += ",";
                        sayac1 = 0;
                    }
                }
            }
            else
            {
                if (label3.Text != string.Empty)
                {
                    if (sayac2 == 1)
                    {
                        label3.Text += ",";
                        sayac2 = 0;
                    }
                }
            }
        }

        //Tekli Silme
        private void button4_Click(object sender, EventArgs e)
        {
            if (label4.Text == string.Empty)
            {
                if (label2.Text == string.Empty)
                {
                    if (label1.Text != string.Empty)
                    {
                        label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
                    }
                }
                else
                {
                    if (label3.Text != string.Empty)
                    {
                        label3.Text = label3.Text.Substring(0, label3.Text.Length - 1);
                    }
                }
            }
        }
        //Satırı Silme
        private void button2_Click(object sender, EventArgs e)
        {
            if (label4.Text == string.Empty)
            {
                if (label2.Text == string.Empty)
                {
                    label1.Text = string.Empty;
                }
                else
                {
                    label3.Text = string.Empty;
                }
            }
        }

        //Üs Alma Tanımlama
        private void button23_Click(object sender, EventArgs e)
        {
            if (label1.Text != string.Empty)
            {
                label2.Text = "POW";
                islem = "pow";
            }
        }

        //Ebob Tanımlama
        private void button22_Click(object sender, EventArgs e)
        {
            if (label1.Text != string.Empty)
            {
                label2.Text = "EBOB";
                islem = "ebob";
            }
        }

        //Tümünü Silme
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = label2.Text = label3.Text = label4.Text = string.Empty;
            sayac1 = sayac2 = 1;
            btnClick = true;
        }

        //Mod Tanımlama
        private void button21_Click(object sender, EventArgs e)
        {

            if (label1.Text != string.Empty)
            {
                label2.Text = "MOD";
                islem = "mod";
            }
        }

        //Faktöryel Tanımlama
        private void button20_Click(object sender, EventArgs e)
        {
            if (label1.Text != string.Empty)
            {
                label2.Text = "!";
                islem = "!";
            }
        }

        //Karekök Alma Tanımlama
        private void button24_Click(object sender, EventArgs e)
        {
            if (label1.Text != string.Empty)
            {
                label2.Text = "SQRT";
                islem = "sqrt";
                btnClick = false;
            }
        }

        //Fibonacci Tanımlama
        private void button26_Click(object sender, EventArgs e)
        {
            if (label1.Text != string.Empty)
            {
                label2.Text = "F";
                islem = "f";
                btnClick = false;
            }
        }

        //Formu Kapatırken MessageBoxla Sorma
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Dikkat!", MessageBoxButtons.OK);
            if (cevap == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }

        

       
    }

