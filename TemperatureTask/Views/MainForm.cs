using TemperatureTask.Views;

namespace TemperatureTask
{
    public partial class MainForm : Form, IMainForm
    {
        public Action<int>? SaveSourceScale;

        public Action<int>? SaveTargetScale;

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

        public void SetSourceScales(List<string> scales)
        {
            foreach (string scale in scales)
            {
                cbSourceScale.Items.Add(scale);
            }
        }

        public void SetTargetScales(List<string> scales)
        {
            foreach (string scale in scales)
            {
                cbTargetScale.Items.Add(scale);
            }
        }

        public void SetSourceTemperature(double value)
        {
            tbSourceTemperature.Text = value.ToString();
        }

        public void SetTargetTemperature(double value)
        {
            tbTargetTemperature.Text = value.ToString();
        }

        public void SetSourceScale(int index)
        {
            cbSourceScale.SelectedIndex = index;
        }

        public void SetTargetScale(int index)
        {
            cbTargetScale.SelectedIndex = index;
        }

        private void cbSourceScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSourceScale?.Invoke(cbSourceScale.SelectedIndex);
        }

        private void cbTargetScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveTargetScale?.Invoke(cbTargetScale.SelectedIndex);
        }
    }
}