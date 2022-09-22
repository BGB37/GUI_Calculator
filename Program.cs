using System;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace GUI_Calculator
{

    class AnaPencere : Form  // For sınıfından türeterek yeni bir sınıf oluşturuyoruz. Çok biçimlilik(Polymorphism) örneği.
    {
        private TextBox txtBox;
        Button btnZero, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnAdd, btnSub, btnMul, btnEqu, btnClear, btnDiv, btnDot;

        private string islem = "";

        public void btnNumber_click(object dugme, EventArgs e)
        {
            var t = ((Button)dugme).Text;  // Burayı incele. Parantez içinde yaptığımız işlem Button'a cast etmek diye bahsediliyor.
            txtBox.Text += t; // Atama yapmıyoruz mevcuda ekleme yapıyoruz.

            if (txtBox.Text[0] == '0') // İlk girilen sayı 0 sa,
            {
                txtBox.Text = txtBox.Text.Remove(0, 1); // Sayıyı ekranda gösterme çünkü sıfırlı bir sayıyla işlem yapılamaz. TextBox sınıfının Text propertysinin Remove() metetotunu kullandık.
            }
        }

        public void btnClear_click(object dugme, EventArgs e)
        {
            txtBox.Text = ""; // Sadece girilen son karakteri silecek şekilde geliştirilebilir.
        }

        public void btnIslem_Click(object dugme, EventArgs e)
        {
            var t = ((Button)dugme).Text; //dugmenin texti dört işlem sembollerinden biri olmak zorunda.
            txtBox.Text = txtBox.Text + " " + t + " ";

            islem = t; // Hangi işlem tuşuna basıldığını tutmak için global olarak islem değişkenini string olarak tanımladık. Burada hangi tuşa basıldıysa ona atanmış olan işlem stringini tutacak. X - / - + - -(çıkarma sembolü). 
        }

        public void btnDot_click(object sender, EventArgs e)
        {
            txtBox.Text += btnDot.Text;
        }

        public void btnEqu_Click(object dugme, EventArgs e)
        {

            var ifade = txtBox.Text.Split(islem[0]); //islem stringinin içindeki ilk elemanı almak için indisli yazdık. Aslında zaten tek karakter ama metot char veri tipi istediği için bu sayede bunu da çözmüş olduk.
            // DOUBLE sayı girilmesi durumuda yapılacak işlemler.
            if (ifade[0].Contains(".") || ifade[1].Contains("."))
            {
                double n1 = Convert.ToDouble(ifade[0]);
                double n2 = Convert.ToDouble(ifade[1]);

                switch (islem)
                {
                    case "+":
                        txtBox.Text = $"{n1 + n2}";
                        break;
                    case "-":
                        txtBox.Text = $"{n1 - n2}";
                        break;
                    case "x":
                        txtBox.Text = $"{n1 * n2}";
                        break;
                    case "/":
                        if (n2 != 0)
                        {
                            txtBox.Text = $"{n1 / n2}";
                        }
                        else
                        {
                            MessageBox.Show("İkinci sayıyı sıfır girme balım.");
                            txtBox.Text = txtBox.Text.Split('/')[0];
                        }

                        break;
                }
            }


            else
            {
                ulong n1 = Convert.ToUInt64(ifade[0]); // ifadenin solunda kalan sayıya n1 diyoruz.
                ulong n2 = Convert.ToUInt64(ifade[1]);

                switch (islem)
                {
                    case "+":
                        txtBox.Text = $"{n1 + n2}";
                        break;
                    case "-":
                        txtBox.Text = $"{n1 - n2}";
                        break;
                    case "x":
                        txtBox.Text = $"{n1 * n2}";
                        break;
                    case "/":
                        if (n2 != 0)
                        {
                            txtBox.Text = $"{n1 / n2}";
                        }
                        else
                        {
                            MessageBox.Show("İkinci sayıyı sıfır girme balım.");
                            txtBox.Text = txtBox.Text.Split('/')[0];
                        }

                        break;
                }
            }
        }

            
         



        public AnaPencere() // AnaPencerenin constructor'ı.
        {
            this.Text = "Şablon GUI App";
            this.BackColor = Color.Wheat;
            this.Width = 270;
            this.Height = 420;

            txtBox = new TextBox();

            txtBox.BackColor = Color.White;
            txtBox.Top = 30;
            txtBox.Left = 10;
            txtBox.Width = 230;
            txtBox.Font = new Font(new FontFamily("Arial"), 18F);
            txtBox.TextAlign = HorizontalAlignment.Right;

            btnZero = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();

            btnZero.Click += btnNumber_click; //Button sınıfından yarattığımız objelerin click eventleri alanına kendi yazacağımız fonksiyon isimlerini ekliyoruz ki tıklandığında çalışsın.
            btn1.Click += btnNumber_click;
            btn2.Click += btnNumber_click;
            btn3.Click += btnNumber_click;
            btn4.Click += btnNumber_click;
            btn5.Click += btnNumber_click;
            btn6.Click += btnNumber_click;
            btn7.Click += btnNumber_click;
            btn8.Click += btnNumber_click;
            btn9.Click += btnNumber_click;


            btnAdd = new Button();
            btnSub = new Button();
            btnMul = new Button();
            btnDiv = new Button();
            btnEqu = new Button();
            btnClear = new Button();
            btnDot = new Button();

            btnAdd.Click += btnIslem_Click;
            btnSub.Click += btnIslem_Click;
            btnMul.Click += btnIslem_Click;         // Sağ tarafta yazan fonksiyon isimlerini buton isimlerinin Click eventlerine ekliyoruz. En azından benim henüz anladığım bu:)
            btnDiv.Click += btnIslem_Click;
            btnEqu.Click += btnEqu_Click;
            btnClear.Click += btnClear_click;
            btnDot.Click += btnDot_click;

            // First Row Start 
            btn9.Text = "9";
            btn9.Width = 50;
            btn9.Height = 50;
            btn9.Top = 70;
            btn9.Left = 10;

            btn8.Text = "8";
            btn8.Width = 50;
            btn8.Height = 50;
            btn8.Top = 70;
            btn8.Left = 70;

            btn7.Text = "7";
            btn7.Width = 50;
            btn7.Height = 50;
            btn7.Top = 70;
            btn7.Left = 130;

            btnClear.Text = "C";
            btnClear.Width = 50;
            btnClear.Height = 50;
            btnClear.Top = 70;
            btnClear.Left = 190;
            //First Row End

            // Second Row Start
            btn6.Text = "6";
            btn6.Width = 50;
            btn6.Height = 50;
            btn6.Top = 130;
            btn6.Left = 10;

            btn5.Text = "5";
            btn5.Width = 50;
            btn5.Height = 50;
            btn5.Top = 130;
            btn5.Left = 70;

            btn4.Text = "4";
            btn4.Width = 50;
            btn4.Height = 50;
            btn4.Top = 130;
            btn4.Left = 130;

            btnAdd.Text = "+";
            btnAdd.Width = 50;
            btnAdd.Height = 50;
            btnAdd.Top = 130;
            btnAdd.Left = 190;
            btnAdd.Font = new Font(new FontFamily("Arial"), 10F);
            // Second Row End

            //Third Row Start
            btn3.Text = "3";
            btn3.Width = 50;
            btn3.Height = 50;
            btn3.Top = 190;
            btn3.Left = 10;

            btn2.Text = "2";
            btn2.Width = 50;
            btn2.Height = 50;
            btn2.Top = 190;
            btn2.Left = 70;

            btn1.Text = "1";
            btn1.Width = 50;
            btn1.Height = 50;
            btn1.Top = 190;
            btn1.Left = 130;

            btnSub.Text = "-";
            btnSub.Width = 50;
            btnSub.Height = 50;
            btnSub.Top = 190;
            btnSub.Left = 190;
            btnSub.Font = new Font(new FontFamily("Arial"), 10F);
            //Third Row End

            //Fourth Row Start
            btnZero.Text = "0";
            btnZero.Width = 50;
            btnZero.Height = 50;
            btnZero.Top = 250;
            btnZero.Left = 10;
            
            btnMul.Text = "x";
            btnMul.Width = 50;
            btnMul.Height = 50;
            btnMul.Top = 250;
            btnMul.Left = 70;
            btnMul.Font = new Font(new FontFamily("Arial"), 10F);

            btnDiv.Text = "/";
            btnDiv.Width = 50;
            btnDiv.Height = 50;
            btnDiv.Top = 250;
            btnDiv.Left = 130;
            btnDiv.Font = new Font(new FontFamily("Arial"), 10F);

            btnEqu.Text = "=";
            btnEqu.Width = 230;
            btnEqu.Height = 50;
            btnEqu.Top = 310;
            btnEqu.Left = 10;
            btnEqu.Font = new Font(new FontFamily("Arial"), 10F);

            btnDot.Text = ".";
            btnDot.Width = 50;
            btnDot.Height = 50;
            btnDot.Top = 250;
            btnDot.Left = 190;
            btnDot.Font = new Font(new FontFamily("Arial"), 20F);
            //Fourth Row End

            this.Controls.Add(btnZero);
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);
            this.Controls.Add(btn4);
            this.Controls.Add(btn5);
            this.Controls.Add(btn6);
            this.Controls.Add(btn7);
            this.Controls.Add(btn8);
            this.Controls.Add(btn9);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnSub);
            this.Controls.Add(btnMul);
            this.Controls.Add(btnDiv);
            this.Controls.Add(btnEqu);
            this.Controls.Add(txtBox);
            this.Controls.Add(btnDot);
        }

    };

    internal class Program
    {
        static void Main()
        {
            Application.Run(new AnaPencere());


        }
    }
}
