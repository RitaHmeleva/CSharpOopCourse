using TemperatureTask.Views;

namespace TemperatureTask
{
    public partial class MainForm : Form, IMainForm
    {
        public Action<string>? SaveSourceScale;

        public Action<string>? SaveTargetScale;

        public Action<double>? ConvertTemperature;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Закрыть конвертер?", "Конвертер темературы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btRun_Click(object sender, EventArgs e)
        {
            if (cbSourceScale.SelectedIndex == cbTargetScale.SelectedIndex)
            {
                MessageBox.Show("Конвертация не требуется", "Конвертер темературы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (double.TryParse(tbSourceTemperature.Text, out double value))
            {
                ConvertTemperature?.Invoke(value);
            }
            else
            {
                MessageBox.Show("Некорректное значение температуры", "Конвертер темературы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetSourceScales(Dictionary<string, string> scales)
        {
            cbSourceScale.DataSource = new BindingSource(scales, null);
            cbSourceScale.ValueMember = "Key";
            cbSourceScale.DisplayMember = "Value";
        }

        public void SetTargetScales(Dictionary<string, string> scales)
        {
            cbTargetScale.DataSource = new BindingSource(scales, null);
            cbTargetScale.ValueMember = "Key";
            cbTargetScale.DisplayMember = "Value";
        }

        public void SetSourceTemperature(double value)
        {
            tbSourceTemperature.Text = value.ToString();
        }

        public void SetTargetTemperature(double value)
        {
            tbTargetTemperature.Text = value.ToString();
        }

        public void SetSourceScale(string scaleCode)
        {
            cbSourceScale.SelectedValue = scaleCode;
        }

        public void SetTargetScale(string scaleCode)
        {
            cbTargetScale.SelectedValue = scaleCode;
        }

        private void cbSourceScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSourceScale?.Invoke((string)cbSourceScale.SelectedValue);
        }

        private void cbTargetScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveTargetScale?.Invoke((string)cbTargetScale.SelectedValue);
        }
    }
}