using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings _settings = null;
        //Kredit kredit = new Kredit();
        //Deposit deposit = new Deposit();
        public Account account;

        internal static List<Offer> kredits = new List<Offer>();
        internal static List<Offer> deposits = new List<Offer>();
        public MainWindow()
        {
            InitializeComponent();

            _settings = Settings.GetSettings();


            _initControlls();
        }

        private void _initControlls()
        {
            textBoxName.Text = _settings.Name;
            textBoxSecondname.Text = _settings.Secondname;
            textBoxPassword.Text = _settings.Password;


        }


        private void button_SignIn_Click(object sender, EventArgs e)
        {
            _settings.Name = textBoxName.Text;
            _settings.Secondname = textBoxSecondname.Text;
            _settings.Password = textBoxPassword.Text;

            _settings.Save();
            this.account = new Account(textBoxName.Text, textBoxSecondname.Text, textBoxPassword.Text);
            _settings = Settings.GetSettings();

            if (!this.account.DoesExist())
                this.account.AddAccount(this.account);

            textBoxAmountDp.Text = _settings.amountDp;
            textBoxPercentDp.Text = _settings.percentDp;
            textBoxCurrencyDp.Text = _settings.currencyDp;

            textBoxAmountKr.Text = _settings.amountKr;
            textBoxPercentKr.Text = _settings.percentKr;
            textBoxCurrencyKr.Text = _settings.currencyKr;

            //label4.Visible = label5.Visible = label6.Visible = label7.Visible = label8.Visible = label9.Visible = label11.Visible = label12.Visible = listBoxDp.Visible = listBoxKr.Visible = textBoxAmountKr.Visible = textBoxAmountDp.Visible = textBoxCurrencyDp.Visible = textBoxCurrencyKr.Visible = textBoxPercentDp.Visible = textBoxPercentKr.Visible = buttonAddKr.Visible = buttonAddDp.Visible = label14.Visible = label15.Visible = label16.Visible = label13.Visible = textBoxAmountCh.Visible = textBoxCurrencyTo.Visible = textBoxCurrencyFrom.Visible = Change.Visible = true;
        }

        private void buttonAddKr_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(textBoxAmountKr.Text) > 1 && Convert.ToInt32(textBoxPercentKr.Text) > 0)
            {
                int num = this.account.GetKredits().Count;
                Kredit kredit = new Kredit(Convert.ToInt32(textBoxAmountKr.Text), Convert.ToInt32(textBoxPercentKr.Text), textBoxCurrencyKr.Text, num);
                this.account.AddKredit(kredit);
                listBoxKr.Items.Clear();
                foreach (Offer kr in this.account.GetKredits())
                {
                    listBoxKr.Items.Add(kr.Show());

                }


                _settings.amountKr = textBoxAmountKr.Text;
                _settings.currencyKr = textBoxCurrencyKr.Text;
                _settings.percentKr = textBoxPercentKr.Text;

                _settings.Save();

            }
            else
            {
                MessageBox.Show("Try to fill all fields correctly");
            }
        }

        private void buttonAddDp_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxAmountDp.Text) > 1 && Convert.ToInt32(textBoxPercentDp.Text) > 0)
            {
                int num = this.account.GetDeposits().Count;
                Deposit deposit = new Deposit(Convert.ToInt32(textBoxAmountDp.Text), Convert.ToInt32(textBoxPercentDp.Text), textBoxCurrencyDp.Text, num);
                this.account.AddDeposit(deposit);
                listBoxDp.Items.Clear();
                foreach (Offer dp in this.account.GetDeposits())
                {
                    listBoxDp.Items.Add(dp.Show());

                }
                _settings.amountDp = textBoxAmountDp.Text;
                _settings.currencyDp = textBoxCurrencyDp.Text;
                _settings.percentDp = textBoxPercentDp.Text;

                _settings.Save();

            }
            else
            {
                MessageBox.Show("Try to fill all fields correctly");
            }
        }

        private void Change_Click(object sender, EventArgs e)
        {

            if (textBoxAmountCh.Text != "" || textBoxCurrencyFrom.Text != "" || textBoxCurrencyTo.Text != "")
            {
                result.Content = Changer.change(Convert.ToDouble(textBoxAmountCh.Text), Changer.choose(textBoxCurrencyFrom.Text), Changer.choose(textBoxCurrencyTo.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Try to fill all fields correctly");
            }
        }

        public void DeleteKredit(object sender, EventArgs e)
        {
            if (KreditIdTBox.Text != "" && KreditIdTBox.Text != null)
            {
                List<Offer> kredits = this.account.DeleteKredit(Convert.ToInt32(KreditIdTBox.Text));
                listBoxKr.Items.Clear();
                foreach (Offer kr in kredits)
                {
                    listBoxKr.Items.Add(kr.Show());

                }
            }
            else
            {
                MessageBox.Show("Try to fill all fields correctly");
            }
        }


        public void DeleteDeposit(object sender, EventArgs e)
        {
            if (DepositIdTBox.Text != "" && DepositIdTBox.Text != null)
            {
                List<Offer> deposits = this.account.DeleteDeposit(Convert.ToInt32(DepositIdTBox.Text));
                listBoxDp.Items.Clear();
                foreach (Offer dp in deposits)
                {
                    listBoxDp.Items.Add(dp.Show());
                }
            }
            else
            {
                MessageBox.Show("Try to fill all fields correctly");
            }
        }
    }
}
