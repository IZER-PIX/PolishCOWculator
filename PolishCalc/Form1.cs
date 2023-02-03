namespace PolishCalc
{
    public partial class Form1 : Form
    {
        ConverterToPolish converter = new ConverterToPolish();
        string expresion = "";
        public Form1()
        {
            InitializeComponent();
            converter.OnResult += (int n1, int n2, char c) => richTextBox3.Text += $"{n1} {n2} {c}";
        }
        #region
        private void button1_Click(object sender, EventArgs e)
        {
            expresion += "1";
            richTextBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            expresion += "2";
            richTextBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            expresion += "3";
            richTextBox1.Text += "3";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            expresion += "4";
            richTextBox1.Text += "4";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            expresion += "5";
            richTextBox1.Text += "5";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            expresion += "6";
            richTextBox1.Text += "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            expresion += "7";
            richTextBox1.Text += "7";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            expresion += "8";
            richTextBox1.Text += "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            expresion += "9";
            richTextBox1.Text += "9";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            expresion += "0";
            richTextBox1.Text += "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            expresion += "-";
            richTextBox1.Text += "-";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            expresion += "+";
            richTextBox1.Text += "-";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            expresion += "/";
            richTextBox1.Text += "/";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            expresion += "*";
            richTextBox1.Text += "*";
        }
        #endregion
        private void button17_Click(object sender, EventArgs e)
        {
            converter.Convert(expresion);
            richTextBox2.Text += converter.Calc();
        }
    }
}