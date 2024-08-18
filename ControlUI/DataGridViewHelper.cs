namespace ControlUI
{
    public static class DataGridViewHelper
    {
        public static void LoadDataGrid<T>(DataGridView dataGridView, List<T> data) where T : class
        {
            dataGridView.DataSource = data.OrderByDescending(d => d.GetType().GetProperty("Id").GetValue(d)).ToList();
            HideUnwantedColumns(dataGridView);
        }

        private static void HideUnwantedColumns(DataGridView dataGridView)
        {
            if (dataGridView.Columns["UserId"] != null)
            {
                dataGridView.Columns["UserId"].Visible = false;
            }
            if (dataGridView.Columns["Email"] != null)
            {
                dataGridView.Columns["Email"].Visible = false;
            }
        }
    }
}
