using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class GOL : Form
    {
        int GridSize = 25;
        int Neighbours = 0;
        int Generation = 1;
        DataTable dtBecomesGreen = new DataTable();
        DataTable dtBecomesGray = new DataTable();
        public GOL()
        {
            InitializeComponent();
            dtBecomesGreen.Columns.Add("rowIndex");
            dtBecomesGreen.Columns.Add("columnIndex");

            dtBecomesGray.Columns.Add("rowIndex");
            dtBecomesGray.Columns.Add("columnIndex");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateGrid();
            InitializeGrid();
            tmrspeed.Start();
        }

        private void GenerateGrid()
        {
            for (int mi = 0; mi < GridSize; mi++)
            {
                dgvcells.Columns.Add("", "");
                dgvcells.Columns[mi].Width = 40;
                dgvcells.Rows.Add();
            }
        }

        private void InitializeGrid()
        {
            Random randomRow = new Random();
            Random randomColumn = new Random();

            Random minValue = new Random();
            Random maxValue = new Random();

            int rowIndex = 0;
            int columnIndex = 0;
            for (int mi = 0; mi < (GridSize * GridSize); mi++)
            {

                rowIndex = randomRow.Next(0, 12);
                columnIndex = randomColumn.Next(0, 10);
                dgvcells.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Green;
                dgvcells.Rows[rowIndex].Cells[columnIndex].Style.SelectionBackColor = Color.Green;

                rowIndex = randomRow.Next(10, 25);
                columnIndex = randomColumn.Next(0, 25);
                dgvcells.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Green;
                dgvcells.Rows[rowIndex].Cells[columnIndex].Style.SelectionBackColor = Color.Green;

                rowIndex = randomRow.Next(minValue.Next(0, 15), maxValue.Next(0, 15));
                columnIndex = randomColumn.Next(minValue.Next(18, 24), maxValue.Next(20, 24));
                dgvcells.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Green;
                dgvcells.Rows[rowIndex].Cells[columnIndex].Style.SelectionBackColor = Color.Green;

            }
        }

        private int ActiveCells()
        {
            int activeCells = 0;
            for (int mi = 0; mi < GridSize; mi++)
            {
                activeCells += dgvcells.Rows.Cast<DataGridViewRow>().AsEnumerable().Count(r => r.Cells[mi].Style.BackColor == Color.Green);
            }
            return activeCells;
        }

        private void ProcessGrid()
        {
            for (int mi = 0; mi < dgvcells.Rows.Count; mi++)
            {
                for (int mj = 0; mj < GridSize; mj++)
                {
                    if (dgvcells.Rows[mi].Cells[mj].Style.BackColor == Color.Green)
                    {
                        var rowIndex = dgvcells.Rows[mi].Cells[mj].RowIndex;
                        var columnIndex = dgvcells.Rows[mi].Cells[mj].ColumnIndex;
                        ScanActive(rowIndex, columnIndex);
                    }
                    else
                    {
                        var rowIndex = dgvcells.Rows[mi].Cells[mj].RowIndex;
                        var columnIndex = dgvcells.Rows[mi].Cells[mj].ColumnIndex;
                        ScanInActive(rowIndex, columnIndex);
                    }
                }
            }
            GenerateNextPattern();
        }

        private void ScanActive(int RowIndex, int ColumnIndex)
        {
            Neighbours = 0;
            ScanTop(RowIndex, ColumnIndex);
            ScanTopRight(RowIndex, ColumnIndex);
            ScanRight(RowIndex, ColumnIndex);
            ScanBottomRight(RowIndex, ColumnIndex);
            ScanBottom(RowIndex, ColumnIndex);
            ScanBottomLeft(RowIndex, ColumnIndex);
            ScanLeft(RowIndex, ColumnIndex);
            ScanTopLeft(RowIndex, ColumnIndex);
            if (Neighbours != 2 && Neighbours != 3)
            {
                dtBecomesGray.Rows.Add();
                dtBecomesGray.Rows[dtBecomesGray.Rows.Count - 1]["rowIndex"] = RowIndex;
                dtBecomesGray.Rows[dtBecomesGray.Rows.Count - 1]["columnIndex"] = ColumnIndex;
            }
        }

        private void ScanInActive(int RowIndex, int ColumnIndex)
        {
            Neighbours = 0;
            ScanTop(RowIndex, ColumnIndex);
            ScanTopRight(RowIndex, ColumnIndex);
            ScanRight(RowIndex, ColumnIndex);
            ScanBottomRight(RowIndex, ColumnIndex);
            ScanBottom(RowIndex, ColumnIndex);
            ScanBottomLeft(RowIndex, ColumnIndex);
            ScanLeft(RowIndex, ColumnIndex);
            ScanTopLeft(RowIndex, ColumnIndex);
            if (Neighbours == 3)
            {
                dtBecomesGreen.Rows.Add();
                dtBecomesGreen.Rows[dtBecomesGreen.Rows.Count - 1]["rowIndex"] = RowIndex;
                dtBecomesGreen.Rows[dtBecomesGreen.Rows.Count - 1]["columnIndex"] = ColumnIndex;
            }
        }

        private void ScanTop(int RowIndex, int ColumnIndex)
        {
            if (RowIndex > 0)
            {
                var backColour = dgvcells.Rows[RowIndex - 1].Cells[ColumnIndex].Style.BackColor;
                if (backColour.Name == "Green")
                {
                    Neighbours++;
                }
            }
        }

        private void ScanTopRight(int RowIndex, int ColumnIndex)
        {
            if (RowIndex > 0 && ColumnIndex < dgvcells.Columns.Count - 1)
            {
                var backColour = dgvcells.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Style.BackColor;
                if (backColour.Name == "Green")
                {
                    Neighbours++;
                }
            }
        }

        private void ScanRight(int RowIndex, int ColumnIndex)
        {
            if (ColumnIndex < dgvcells.Columns.Count - 1)
            {
                var backColour = dgvcells.Rows[RowIndex].Cells[ColumnIndex + 1].Style.BackColor;
                if (backColour.Name == "Green")
                {
                    Neighbours++;
                }
            }
        }

        private void ScanBottomRight(int RowIndex, int ColumnIndex)
        {
            if (RowIndex < dgvcells.Rows.Count - 1 && ColumnIndex < dgvcells.Columns.Count - 1)
            {
                var backColour = dgvcells.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Style.BackColor;
                if (backColour.Name == "Green")
                {
                    Neighbours++;
                }
            }
        }

        private void ScanBottom(int RowIndex, int ColumnIndex)
        {
            if (RowIndex < dgvcells.Rows.Count - 1)
            {
                var backColour = dgvcells.Rows[RowIndex + 1].Cells[ColumnIndex].Style.BackColor;
                if (backColour.Name == "Green")
                {
                    Neighbours++;
                }
            }
        }

        private void ScanBottomLeft(int RowIndex, int ColumnIndex)
        {
            if (RowIndex < dgvcells.Rows.Count - 1 && ColumnIndex > 0)
            {
                var backColour = dgvcells.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Style.BackColor;
                if (backColour.Name == "Green")
                {
                    Neighbours++;
                }
            }
        }

        private void ScanLeft(int RowIndex, int ColumnIndex)
        {
            if (ColumnIndex > 0)
            {
                var backColour = dgvcells.Rows[RowIndex].Cells[ColumnIndex - 1].Style.BackColor;
                if (backColour.Name == "Green")
                {
                    Neighbours++;
                }
            }
        }

        private void ScanTopLeft(int RowIndex, int ColumnIndex)
        {
            if (RowIndex > 0 && ColumnIndex > 0)
            {
                var backColour = dgvcells.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Style.BackColor;
                if (backColour.Name == "Green")
                {
                    Neighbours++;
                }
            }
        }

        private void GenerateNextPattern()
        {
            for (int mi = 0; mi < dtBecomesGreen.Rows.Count; mi++)
            {
                dgvcells.Rows[Convert.ToInt32(dtBecomesGreen.Rows[mi]["rowIndex"].ToString())].Cells[Convert.ToInt32(dtBecomesGreen.Rows[mi]["columnIndex"].ToString())].Style.BackColor = Color.Green;
                dgvcells.Rows[Convert.ToInt32(dtBecomesGreen.Rows[mi]["rowIndex"].ToString())].Cells[Convert.ToInt32(dtBecomesGreen.Rows[mi]["columnIndex"].ToString())].Style.SelectionBackColor = Color.Green;
            }
            for (int mi = 0; mi < dtBecomesGray.Rows.Count; mi++)
            {
                dgvcells.Rows[Convert.ToInt32(dtBecomesGray.Rows[mi]["rowIndex"].ToString())].Cells[Convert.ToInt32(dtBecomesGray.Rows[mi]["columnIndex"].ToString())].Style.BackColor = Color.White;
                dgvcells.Rows[Convert.ToInt32(dtBecomesGray.Rows[mi]["rowIndex"].ToString())].Cells[Convert.ToInt32(dtBecomesGray.Rows[mi]["columnIndex"].ToString())].Style.SelectionBackColor = Color.White;
            }
            dtBecomesGray.Rows.Clear();
            dtBecomesGreen.Rows.Clear();
            Generation++;
            lblgen.Text = Generation.ToString();
        }

        private void tmrspeed_Tick(object sender, EventArgs e)
        {
            if (ActiveCells() > 0)
            {
                ProcessGrid();
            }
        }
    }
}
