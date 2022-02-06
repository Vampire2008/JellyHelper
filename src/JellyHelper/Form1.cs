using Citizen17.JellyHelper.Properties;
using System;
using System.Windows.Forms;

namespace Citizen17.JellyHelper
{
    public partial class JellyForm : Form
    {
        public JellyForm()
        {
            InitializeComponent();
            thinCountBox.Maximum = decimal.MaxValue;
            richCountBox.Maximum = decimal.MaxValue;
            royalCountBox.Maximum = decimal.MaxValue;
            honeyAssCurrentBox.Maximum = decimal.MaxValue;
            royalRequiredBox.Maximum = decimal.MaxValue;
            thinCountBox.Value = Settings.Default.ThinCount;
            richCountBox.Value = Settings.Default.RichCount;
            royalCountBox.Value = Settings.Default.RoyalCount;
            honeyAssCurrentBox.Value = Settings.Default.HoneyAssCurrent;
            honeyAss2StepCheck.Checked = Settings.Default.HonetAss2Step;
            royalRequiredBox.Value = Settings.Default.RoyalRequired;
            GetHoneyAssLeftCount();
            GetRotalLeftCount();
        }

        private decimal GetThinCount(bool withRich = true)
        {
            return thinCountBox.Value + (withRich ? richCountBox.Value * 4 : 0) + royalCountBox.Value * 8;
        }

        private void GetHoneyAssLeftCount()
        {
            decimal result;
            // 1 thin = 5 rep
            // 1 step = 3500
            // 2 step = 7000
            if (honeyAssCurrentBox.Value != 0)
            {
                var left = honeyAss2StepCheck.Checked ? 7000m : 10500m;
                left -= honeyAssCurrentBox.Value;
                result = Math.Ceiling(left / 5 - GetThinCount());
                if (result < 0)
                    result = 0;
            }
            else
            {
                result = honeyAss2StepCheck.Checked ? 1400m : 2100m;
            }

            honeyAssLeftLabel.Text = result.ToString();
        }

        private void GetRotalLeftCount()
        {
            var result = 0m;
            if (royalRequiredBox.Value != 0)
            {
                result = royalRequiredBox.Value * 8 - GetThinCount(false);
                if (result < 0)
                    result = 0;
            }

            royalLeftLabel.Text = result.ToString();
        }

        private void countBox_ValueChanged(object sender, EventArgs e)
        {
            GetHoneyAssLeftCount();
            GetRotalLeftCount();
        }

        private void honeyAssCurrentBox_ValueChanged(object sender, EventArgs e)
        {
            GetHoneyAssLeftCount();
        }

        private void honeyAss2StepCheck_CheckedChanged(object sender, EventArgs e)
        {
            GetHoneyAssLeftCount();
        }

        private void royalRequiredBox_ValueChanged(object sender, EventArgs e)
        {
            GetRotalLeftCount();
        }

        private void JellyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.ThinCount = thinCountBox.Value;
            Settings.Default.RichCount = richCountBox.Value;
            Settings.Default.RoyalCount = royalCountBox.Value;
            Settings.Default.HoneyAssCurrent = honeyAssCurrentBox.Value;
            Settings.Default.HonetAss2Step = honeyAss2StepCheck.Checked;
            Settings.Default.RoyalRequired = royalRequiredBox.Value;
            Settings.Default.Save();
        }

        private void numericUpDown_Leave(object sender, EventArgs e)
        {
            if (!(sender is NumericUpDown numericUpDown))
                return;
            if (string.IsNullOrWhiteSpace(numericUpDown.Text))
                numericUpDown.Value = 0;
        }
    }
}
