using System;
using System.Drawing;
using System.Windows.Forms;
using SalesmanCore.Controls;

namespace SalesmanCore.Forms;

public partial class FormCalc : Form
{
    public FormCalc()
    {
        InitializeComponent();
    }

    public FormCalc(int?[,] matrix)
    {
        InitializeComponent();
        Matrix = matrix;
        MatrixLength = Matrix.GetLength(0);

        const int cellSize = 70;
        matrixGrid.GridSize = new Size(MatrixLength + 1, MatrixLength + 1);
        matrixGrid.Size = new Size(matrixGrid.GridSize.Width * cellSize, matrixGrid.GridSize.Height * cellSize);

        for (var i = 1; i <= MatrixLength; i++)
        {
            comboBoxFrom.Items.Add(i.ToString());
            comboBoxTo.Items.Add(i.ToString());
        }

        ButtonRunUpdate();
    }

    #region Свойства

    private int?[,] Matrix { get; }

    private int MatrixLength { get; }

    #endregion

    #region Методы

    private void ButtonRunUpdate()
    {
        buttonRun.Enabled = comboBoxFrom.SelectedIndex >= 0 && comboBoxTo.SelectedIndex >= 0 && comboBoxFrom.SelectedIndex != comboBoxTo.SelectedIndex;
    }

    #endregion

    #region События

    private void buttonRun_Click(object sender, EventArgs e)
    {
    }

    private void comboBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        ButtonRunUpdate();
    }

    private void comboBoxTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ButtonRunUpdate();
    }

    private void matrixGrid_CellNeeded(object sender, MatrixGrid.CellNeededEventArgs e)
    {
        if (e.Cell.X == 0) // заголовок по оси Y
        {
            e.BackColor = Color.BurlyWood;
            if (e.Cell.Y != 0)
            {
                e.Value = e.Cell.Y.ToString();
            }
        }
        else if (e.Cell.Y == 0) // заголовок по оси X
        {
            e.BackColor = Color.BurlyWood;
            if (e.Cell.X != 0)
            {
                e.Value = e.Cell.X.ToString();
            }
        }
        else
        {
            e.BackColor = Color.Bisque;
            e.Value = Matrix[e.Cell.X - 1, e.Cell.Y - 1].ToString();
        }
    }

    #endregion
}