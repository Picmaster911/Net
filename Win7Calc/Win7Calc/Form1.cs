using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Win7Calc;

internal enum Doing
{
    Plus,
    Minus,
    Degree,
    Multyple,
    Equels,
    Sqrt
}

namespace Calculator
{
    public partial class Calc : Form
    {
        private bool _isShowResult = true;
        private double? _memory;
        private double? _number1;
        private double? _number2;
        private char _singht;
        private CalcTest _calcTest;
        public Calc()
        {
            InitializeComponent();
            Table.Text = 0.ToString();
            KeyPreview = true;
            _calcTest = new CalcTest();
        }

        private void GetNumber()
        {
            if (_isShowResult)
            {
                return;
            }
            if (_number1 == null)
            {
                _number1 = double.Parse(Table.Text);
                Table.Text = _number1.ToString();
                _isShowResult = true;
            }
            else if (_number2 == null)
            {
                _number2 = double.Parse(Table.Text);

            }
        }
        private void CulculateNew(char singht)
        {

            _number1 = CalcTest.Operators[singht](_number1.Value, _number2.Value);
            Table.Text = _number1.ToString();
            _isShowResult = true;
            _number2 = null;
        }
   
        private void ButtonSinght_Click(object sender, EventArgs e)
        {
            var pusdButton = sender as Button;
            GetNumber();
            _singht = pusdButton.Text[0];
        }

        private void ButtonNum_Click(object sender, EventArgs e)
        {
            if (_isShowResult)
            {
                _isShowResult = false;
                Table.Text = "";
            }
            if ((sender as Button).Text == ",")
            {
                if (Table.Text.Contains(",") == false)
                    Table.Text += (sender as Button).Text;
            }
            else
            {
                Table.Text += (sender as Button).Text;
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!_isShowResult && Table.Text.Length != 0)
            {
                var TText = new StringBuilder(Table.Text);
                TText.Remove(TText.Length - 1, 1);
                Table.Text = TText.ToString();
            }
        }

        private void ButtonClearC_Click(object sender, EventArgs e)
        {
            _isShowResult = true;
            _number1 = null;
            _number2 = null;
            Table.Text = "0";
        }

        private void ButtonClearCE_Click(object sender, EventArgs e)
        {
            _isShowResult = true;
            Table.Text = "0";
        }

        private void ButtonInverse_Click(object sender, EventArgs e)
        {
            if (Table.Text.Length != 0)
            {
                if (Table.Text[0] != '-')
                    Table.Text = Table.Text.Insert(0, "-");
                else
                    Table.Text = Table.Text.Remove(0, 1);

                if (_isShowResult)
                    _number1 = -_number1;
            }
        }

        private void ButtonSqrt_Click(object sender, EventArgs e)
        {
            Table.Text = Math.Sqrt(double.Parse(Table.Text)).ToString();
            _isShowResult = true;
        }

        private void ButtonFraction_Click(object sender, EventArgs e)
        {
            Table.Text = (1 / double.Parse(Table.Text)).ToString();
            _isShowResult = true;
        }

        private void ButtonEquels_Click(object sender, EventArgs e)
        {
            GetNumber();
            CulculateNew(_singht);
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {
            if (_isShowResult)
            {
                ButtonClearC_Click(sender, e);
                _isShowResult = false;
            }
            ButtonNum_Click(sender, e);
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            if (Table.Text != "")
            {
                _memory = double.Parse(Table.Text);
                buttonMC.Enabled = true;
                buttonMR.Enabled = true;
            }
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            _memory = null;
            buttonMC.Enabled = false;
            buttonMR.Enabled = false;
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            if (_memory != null)
                Table.Text = _memory.ToString();
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            if (_memory != null)
                _memory += double.Parse(Table.Text);
            else buttonMS_Click(sender, e);
        }

        private void buttonMMinus_Click(object sender, EventArgs e)
        {
            if (_memory != null)
                _memory -= double.Parse(Table.Text);
            else buttonMS_Click(sender, e);
        }   
    }
}