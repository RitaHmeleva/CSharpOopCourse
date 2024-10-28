using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Minesweeper.Gui.Views;

public partial class GamerForm : Form
{
    public string? GamerName { get; set; }

    public GamerForm()
    {
        InitializeComponent();
    }

    private void LevelForm_Load(object sender, EventArgs e)
    {
        tbGamerName.Text = GamerName;
    }

    private void btOK_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbGamerName.Text))
        {
            MessageBox.Show("Имя не может быть пустым.");

            return;
        }

        GamerName = tbGamerName.Text;

        DialogResult = DialogResult.OK;

        Close();
    }


}