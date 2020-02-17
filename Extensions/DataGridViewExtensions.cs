//-----------------------------------------------------------------------
// <copyright file="DataGridViewExtensions.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Extensions
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Extension methods for <see cref="DataGridView"/>
    /// </summary>
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Adds a row to a <see cref="DataGridView"/> with a single column.
        /// </summary>
        /// <param name="dataGridView">The <see cref="DataGridView"/></param>
        /// <param name="columnName">The name of the column to add</param>
        /// <param name="value">The value of the cell to add</param>
        /// <param name="tag">The tag to set on the row</param>
        /// <param name="selected">Will select the row if <c>true</c></param>
        /// <param name="makeBold">Will make the text bold if <c>true</c></param>
        public static void AddRow(this DataGridView dataGridView, string columnName, string value, object tag = null, bool selected = false, bool makeBold = false)
        {
            int rowId = dataGridView.Rows.Add();
            DataGridViewRow row = dataGridView.Rows[rowId];

            if (makeBold)
            {
                row.DefaultCellStyle.Font = new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Bold);
            }

            row.Selected = selected;
            row.Tag = tag ?? value;
            row.Cells[columnName].Value = value;
        }

        /// <summary>
        /// Gets a list of the tags for all selected rows in a <see cref="DataGridView"/>
        /// </summary>
        /// <typeparam name="T">The data type of the tags</typeparam>
        /// <param name="dataGridView">The <see cref="DataGridView"/></param>
        /// <returns>A list of the tags for all selected rows</returns>
        public static List<T> GetSelectedRowTags<T>(this DataGridView dataGridView) where T : class
        {
            List<T> values = new List<T>();

            for (int i = dataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView.SelectedRows[i];

                if (row.Tag == null)
                {
                    continue;
                }

                T value = row.Tag as T;
                values.Add(value);
            }

            return values;
        }

        /// <summary>
        /// Gets a list of the tags for all selected rows in a <see cref="DataGridView"/> used for filtering
        /// </summary>
        /// <typeparam name="T">The data type of the tags</typeparam>
        /// <param name="dataGridView">The <see cref="DataGridView"/></param>
        /// <returns>A list of the tags for all selected rows</returns>
        public static List<T> GetSelectedFilterRowTags<T>(this DataGridView dataGridView) where T : class
        {
            return dataGridView.GetSelectedFilterRowTags<T>(out _);
        }

        /// <summary>
        /// Gets a list of the tags for all selected rows in a <see cref="DataGridView"/> used for filtering
        /// </summary>
        /// <typeparam name="T">The data type of the tags</typeparam>
        /// <param name="dataGridView">The <see cref="DataGridView"/></param>
        /// <param name="showAll">Set to <c>true</c> if all rows were returned</param>
        /// <returns>A list of the tags for all selected rows</returns>
        public static List<T> GetSelectedFilterRowTags<T>(this DataGridView dataGridView, out bool showAll) where T : class
        {
            showAll = false;
            List<T> values = new List<T>();

            if (dataGridView.SelectedRows.Count == 0)
            {
                // No selection implies no filter
                showAll = true;
            }
            else
            {
                for (int i = dataGridView.SelectedRows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView.SelectedRows[i];

                    if (row.Tag == null)
                    {
                        continue;
                    }

                    if (row.Tag.Equals("(All)"))
                    {
                        showAll = true;
                        break;
                    }

                    T value = row.Tag as T;
                    values.Add(value);
                }
            }

            if (showAll)
            {
                values.Clear();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.Visible
                        || row.Tag == null
                        || row.Tag.Equals("(All)"))
                    {
                        continue;
                    }

                    T value = row.Tag as T;
                    values.Add(value);
                }
            }

            return values;
        }

        /// <summary>
        /// Gets a list of the tags for all visible rows in a <see cref="DataGridView"/>
        /// </summary>
        /// <typeparam name="T">The data type of the tags</typeparam>
        /// <param name="dataGridView">The <see cref="DataGridView"/></param>
        /// <returns>A list of the tags for all visible rows</returns>
        public static List<T> GetAllVisibleRowTags<T>(this DataGridView dataGridView) where T : class
        {
            List<T> values = new List<T>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.Visible
                    || row.Tag == null
                    || row.Tag.Equals("(All)"))
                {
                    continue;
                }

                T value = row.Tag as T;
                values.Add(value);
            }

            return values;
        }
    }
}
