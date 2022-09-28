using System;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace GUI_Calculator
{

    class AnaPencere : Form  // For sınıfından türeterek yeni bir sınıf oluşturuyoruz. Çok biçimlilik(Polymorphism) örneği.
    {
        private TextBox txtBox;

        Button btnZero, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnAdd, btnSub, btnMul, btnEqu, btnClear, btnDiv, btnDot;

        private string sign = "";

        public void btnNumber_click(object btn, EventArgs e)
        {
            var t = ((Button)btn).Text;  // Burayı incele. Parantez içinde yaptığımız işlem Button'a cast etmek diye bahsediliyor.
            txtBox.Text += t; // Atama yapmıyoruz mevcuda ekleme yapıyoruz.

            if (txtBox.Text[0] == '0') // İlk girilen sayı 0 sa,
            {
                txtBox.Text = txtBox.Text.Remove(0, 1); // Sayıyı ekranda gösterme çünkü sıfırlı bir sayıyla işlem yapılamaz. TextBox sınıfının Text propertysinin Remove() metetotunu kullandık.
            }
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Blue;
            btnAdd.ForeColor = Color.White;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Wheat;
            btnAdd.ForeColor = Color.Black;
        }

        private void btnSub_MouseHover(object sender, EventArgs e)
        {
            btnSub.BackColor = Color.Blue;
            btnSub.ForeColor = Color.White;
        }

        private void btnSub_MouseLeave(object sender, EventArgs e)
        {
            btnSub.BackColor = Color.Wheat;
            btnSub.ForeColor = Color.Black;
        }

        private void btnMul_MouseHover(object sender, EventArgs e)
        {
            btnMul.BackColor = Color.Blue;
            btnMul.ForeColor = Color.White;
        }

        private void btnMul_MouseLeave(object sender, EventArgs e)
        {
            btnMul.BackColor = Color.Wheat;
            btnMul.ForeColor = Color.Black;
        }

        private void btnDiv_MouseHover(object sender, EventArgs e)
        {
            btnDiv.BackColor = Color.Blue;
            btnDiv.ForeColor = Color.White;
        }

        private void btnDiv_MouseLeave(object sender, EventArgs e)
        {
            btnDiv.BackColor = Color.Wheat;
            btnDiv.ForeColor = Color.Black;
        }

        private void btnZero_MouseHover(object sender, EventArgs e)
        {
            btnZero.BackColor = Color.LightBlue;
        }

        private void btnZero_MouseLeave(object sender, EventArgs e)
        {
            btnZero.BackColor = Color.Wheat;
        }
        private void btn1_MouseHover(object sender, EventArgs e)
        {
            btn1.BackColor = Color.LightBlue;
        }

        private void btn1_MouseLeave(object sender, EventArgs e)
        {
            btn1.BackColor = Color.Wheat;
        }

        private void btn2_MouseHover(object sender, EventArgs e)
        {
            btn2.BackColor = Color.LightBlue;
        }

        private void btn2_MouseLeave(object sender, EventArgs e)
        {
            btn2.BackColor = Color.Wheat;
        }

        private void btn3_MouseHover(object sender, EventArgs e)
        {
            btn3.BackColor = Color.LightBlue;
        }

        private void btn3_MouseLeave(object sender, EventArgs e)
        {
            btn3.BackColor = Color.Wheat;
        }

        private void btn4_MouseHover(object sender, EventArgs e)
        {
            btn4.BackColor = Color.LightBlue;
        }

        private void btn4_MouseLeave(object sender, EventArgs e)
        {
            btn4.BackColor = Color.Wheat;
        }

        private void btn5_MouseHover(object sender, EventArgs e)
        {
            btn5.BackColor = Color.LightBlue;
        }

        private void btn5_MouseLeave(object sender, EventArgs e)
        {
            btn5.BackColor = Color.Wheat;
        }

        private void btn6_MouseHover(object sender, EventArgs e)
        {
            btn6.BackColor = Color.LightBlue;
        }

        private void btn6_MouseLeave(object sender, EventArgs e)
        {
            btn6.BackColor = Color.Wheat;
        }

        private void btn7_MouseHover(object sender, EventArgs e)
        {
            btn7.BackColor = Color.LightBlue;
        }

        private void btn7_MouseLeave(object sender, EventArgs e)
        {
            btn7.BackColor = Color.Wheat;
        }

        private void btn8_MouseHover(object sender, EventArgs e)
        {
            btn8.BackColor = Color.LightBlue;
        }

        private void btn8_MouseLeave(object sender, EventArgs e)
        {
            btn8.BackColor = Color.Wheat;
        }

        private void btn9_MouseHover(object sender, EventArgs e)
        {
            btn9.BackColor = Color.LightBlue;
        }

        private void btn9_MouseLeave(object sender, EventArgs e)
        {
            btn9.BackColor = Color.Wheat;
        }
        public void btnClear_click(object dugme, EventArgs e)
        {
            if (txtBox.Text != "")
            {    //YENİ GELİŞTİRME -- Sayıları teker tker silme sorununu çözdüm. Ayrıca txtBox.Textboş ise, C tuşuna basıldığında program kapanmıyor. 
                int Length = txtBox.Text.Length - 1;
                txtBox.Text = txtBox.Text.Remove(Length);   // Sadece girilen son karakteri silecek şekilde geliştirilebilir. .Length denedim ve yapamadım çünkü .Lenght zero based saymaz!
            }
        }

        public void btnIslem_Click(object btn, EventArgs e)
        {
            var t = ((Button)btn).Text; //dugmenin texti dört işlem sembollerinden biri olmak zorunda.
            txtBox.Text = txtBox.Text + " " + t + " ";

            sign = t; // Hangi işlem tuşuna basıldığını tutmak için global olarak islem değişkenini string olarak tanımladık. Burada hangi tuşa basıldıysa ona atanmış olan işlem stringini tutacak. X - / - + - -(çıkarma sembolü). 
        }

        public void btnDot_click(object sender, EventArgs e)
        {
            txtBox.Text += btnDot.Text;
        }

        public void btnEqu_Click(object dugme, EventArgs e)
        {

            var ifade = txtBox.Text.Split(sign[0]); //islem stringinin içindeki ilk elemanı almak için indisli yazdık. Aslında zaten tek karakter ama metot char veri tipi istediği için bu sayede bunu da çözmüş olduk.
            // DOUBLE sayı girilmesi durumuda yapılacak işlemler.
            if (ifade[0].Contains(".") || ifade[1].Contains("."))
            {
                double n1 = Convert.ToDouble(ifade[0]);
                double n2 = Convert.ToDouble(ifade[1]);

                switch (sign)
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

                switch (sign)
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
            this.Text = "GUI Calculator";
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

            btnZero.Click += btnNumber_click; //Button sınıfından yarattığımız objelerin click eventleri alanına kendi yazacağımız fonksiyon isimlerini Zerokliyoruz ki tıklanZeroığında çalışsın.
            btnZero.MouseHover += btnZero_MouseHover;
            btnZero.MouseLeave += btnZero_MouseLeave;

            btn1.Click += btnNumber_click;
            btn1.MouseHover += btn1_MouseHover;
            btn1.MouseLeave += btn1_MouseLeave;

            btn2.Click += btnNumber_click;
            btn2.MouseHover += btn2_MouseHover;
            btn2.MouseLeave += btn2_MouseLeave;

            btn3.Click += btnNumber_click;
            btn3.MouseHover += btn3_MouseHover;
            btn3.MouseLeave += btn3_MouseLeave;

            btn4.Click += btnNumber_click;
            btn4.MouseHover += btn4_MouseHover;
            btn4.MouseLeave += btn4_MouseLeave;

            btn5.Click += btnNumber_click;
            btn5.MouseHover += btn5_MouseHover;
            btn5.MouseLeave += btn5_MouseLeave;

            btn6.Click += btnNumber_click;
            btn6.MouseHover += btn6_MouseHover;
            btn6.MouseLeave += btn6_MouseLeave;

            btn7.Click += btnNumber_click;
            btn7.MouseHover += btn7_MouseHover;
            btn7.MouseLeave += btn7_MouseLeave;

            btn8.Click += btnNumber_click;
            btn8.MouseHover += btn8_MouseHover;
            btn8.MouseLeave += btn8_MouseLeave;

            btn9.Click += btnNumber_click;
            btn9.MouseHover += btn9_MouseHover;
            btn9.MouseLeave += btn9_MouseLeave;

            btnAdd = new Button();
            btnSub = new Button();
            btnMul = new Button();
            btnDiv = new Button();
            btnEqu = new Button();
            btnClear = new Button();
            btnDot = new Button();

            btnAdd.Click += btnIslem_Click;
            btnAdd.MouseHover += btnAdd_MouseHover;
            btnAdd.MouseLeave += btnAdd_MouseLeave;

            btnSub.Click += btnIslem_Click;
            btnSub.MouseHover += btnSub_MouseHover;
            btnSub.MouseLeave += btnSub_MouseLeave;

            btnMul.Click += btnIslem_Click;                  // Sağ tarafta yazan fonksiyon isimlerini buton isimlerinin Click eventlerine ekliyoruz. En azından benim henüz anladığım bu:)
            btnMul.MouseHover += btnMul_MouseHover;
            btnMul.MouseLeave += btnMul_MouseLeave;
            
            btnDiv.Click += btnIslem_Click;
            btnDiv.MouseHover += btnDiv_MouseHover;
            btnDiv.MouseLeave += btnDiv_MouseLeave;

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


/* TO DO LIST
  4 + = --> Breaks the program. Handle this.
*/
