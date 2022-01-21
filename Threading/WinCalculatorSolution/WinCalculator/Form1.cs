using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalculator
{
    public partial class txtA : Form
    {
        public txtA()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var stringA = textA.Text;
            var stringB = txtB.Text;

            if (int.TryParse(stringA, out int a) && int.TryParse(stringB, out int b))
            {
                // Task.Run(() => LongAdd(a, b))
                //     .ContinueWith(t => UpdateAnswer(t.Result));

                var result = await Task.Run(() => LongAdd(a, b));
                UpdateAnswer(result);
            }
        }

        private void UpdateAnswer(object res)
        {
            lblAnswer.Text = res.ToString();
        }

        private int LongAdd(int a, int b)
        {
            Task.Delay(5000).Wait();
            return a + b;
        }
    }
}