using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework1Part2.encryptDecrypt;
using Homework1Part2.StockQuoteService;

namespace Homework1Part2
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("URL is empty");
            }else
            {
                webBrowser1.Navigate(textBox1.Text);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                MessageBox.Show("URL is Empty");
            else
                webBrowser1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            encryptDecrypt.Service service = new encryptDecrypt.Service();

            if(textBox2.Text.Length > 0)
            {
                String EncryptedText = service.Encrypt(textBox2.Text);
                textBox3.Text = EncryptedText;
            }
            else
            {
                MessageBox.Show("Enter String to Encrypt \nEmpty String not allowed");
            }
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length > 0)
                {
                    encryptDecrypt.Service service = new encryptDecrypt.Service();

                    String DecryptedText = service.Decrypt(textBox2.Text);
                    textBox4.Text = DecryptedText;
                }
                else
                {
                    MessageBox.Show("Enter String to Decrypt \nEmpty String not allowed");
                }
            }catch(Exception exception)
            {
                MessageBox.Show("Can Only Decrypt Encrypted Text\n More Details:\n"+exception.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                StockQuoteService.Service service = new StockQuoteService.Service();
                String stock = textBox5.Text;
                if (stock.Length > 0)
                {
                    String stockQuote = service.getStockquote(stock);

                    textBox6.Text = stockQuote;
                }else
                {
                    MessageBox.Show("Do not Leave the Stock Name Empty\nEnter Valid Stock Name");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
