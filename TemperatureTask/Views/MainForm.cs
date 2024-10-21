using TemperatureTask.Models.TemperatureScales;
using TemperatureTask.Views;

namespace TemperatureTask;

public partial class MainForm : Form, IMainForm
{
    public event Action<double>? ConvertTemperature;
    public event Action<string>? SaveSourceScale;
    public event Action<string>? SaveTargetScale;

    public MainForm()
    {
        InitializeComponent();
    }

    private void btRun_Click(object sender, EventArgs e)
    {
        if (cbSourceScale.SelectedIndex == cbTargetScale.SelectedIndex)
        {
            MessageBox.Show("Конвертация не требуется. Выбрана одинаковая шкала температур.", "Конвертер температуры", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else if (double.TryParse(tbSourceTemperature.Text, out double value))
        {
            ConvertTemperature?.Invoke(value);
        }
        else
        {
            MessageBox.Show("Некорректное значение температуры", "Конвертер температуры", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void SetTemperatureScales(IReadOnlyList<ITemperatureScale> scales)
    {
        cbSourceScale.DataSource = new BindingSource(scales, null);
        cbSourceScale.ValueMember = "Code";
        cbSourceScale.DisplayMember = "UnitsName";

        cbTargetScale.DataSource = new BindingSource(scales, null);
        cbTargetScale.ValueMember = "Code";
        cbTargetScale.DisplayMember = "UnitsName";
    }

    public void SetSourceTemperature(double temperature)
    {
        tbSourceTemperature.Text = temperature.ToString();
    }

    public void SetTargetTemperature(double temperature)
    {
        tbTargetTemperature.Text = Math.Round(temperature, 3, MidpointRounding.AwayFromZero).ToString();
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