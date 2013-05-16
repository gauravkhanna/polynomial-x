using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using Microsoft.Phone.Tasks;

namespace Polynomial_X
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool ans;
        bool inp;
        float init;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            inp = true;
            init = 0;
        }
        private void setzero()
        {
            if (textBox1.Text.Equals(""))
                textBox1.Text = "0";
            if (textBox2.Text.Equals(""))
                textBox2.Text = "0";
            if (textBox3.Text.Equals(""))
                textBox3.Text = "0";
            if (textBox4.Text.Equals(""))
                textBox4.Text = "0";
            if (textBox5.Text.Equals(""))
                textBox5.Text = "0";
            if (textBox6.Text.Equals(""))
                textBox6.Text = "0";
            if (textBox7.Text.Equals(""))
                textBox7.Text = "0";
            if (textBox8.Text.Equals(""))
                textBox8.Text = "0";
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            setzero();
            if (!textBlock10.Text.Equals(null))
            {
                init = float.Parse(textBlock10.Text.ToString());
            }
            if (inp)
            {
                float res = solve();
                textBlock8.Visibility = Visibility.Visible;
                textBox9.Text = res.ToString();
                if (ans == false)
                    textBox9.Text = res.ToString() + " (Approximate)";
                textBox9.Visibility = Visibility.Visible;
            }
            else
            {
                textBlock8.Visibility = Visibility.Collapsed;
                textBox9.Visibility = Visibility.Collapsed;
            }
        }
        private float f(float x, float[] c)
        {
            return c[0]+
                c[1]*x+
                c[2]*x*x+
                c[3]*x*x*x+
                c[4]*x*x*x*x+
                c[5]*x*x*x*x*x+
                c[6] * x * x * x * x * x * x +
                c[7]*x*x*x*x*x*x*x;

        }
        private float f1(float x, float[] c)
        {
            return c[1] +
                c[2] * 2 * x +
                c[3] * 3 * x * x +
                c[4] * 4 * x * x * x +
                c[5] * 5 * x * x * x * x +
                c[6] * 6 * x * x * x * x * x +
                c[7] * 7 * x * x * x * x * x * x;

        }
        private float solve()
        {
            float[] coff=new float[8];
            float x1 = init;
            float fx1,f1x1;
            float c=0, fc;
            int count = 0;
            try
            {
                coff[0] = float.Parse(textBox8.Text);
                coff[1] = float.Parse(textBox7.Text);
                coff[2] = float.Parse(textBox6.Text);
                coff[3] = float.Parse(textBox5.Text);
                coff[4] = float.Parse(textBox4.Text);
                coff[5] = float.Parse(textBox3.Text);
                coff[6] = float.Parse(textBox2.Text);
                coff[7] = float.Parse(textBox1.Text);
                fx1 = f(x1,coff);
                f1x1 = f1(x1, coff);
                if (Math.Abs(fx1) < 0.0000001)
                {
                    ans = true;
                    return x1;
                }
                c = x1;
                fc = fx1;
                while (count < 20)
                {
                    if (f1x1 != 0)
                        x1 = x1 - (fx1 / f1x1);
                    else
                        x1 = x1 + 5;
                    fx1 = f(x1, coff);
                    f1x1 = f1(x1, coff);
                    if (Math.Abs(fx1) < 0.0000001)
                    {
                        ans = true;
                        return x1;
                    }
                    if (Math.Abs(fx1) < Math.Abs(fc))
                    {
                        c = x1;
                        fc = fx1;
                    }   
                    //MessageBox.Show(x2.ToString());
                    count += 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There seems to be a problem. Please enter the equation again");
                inp = false;
                return 0.0F;
            }
            ans = false;
            return c;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox9.Visibility = Visibility.Collapsed;
            textBlock8.Visibility = Visibility.Collapsed;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
        // pop up the link to rate and review the app
        MarketplaceReviewTask review = new MarketplaceReviewTask();
        review.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/about.xaml",UriKind.Relative));
        }
    }
}