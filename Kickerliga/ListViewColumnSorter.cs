using System;
using System.Collections;
using System.Windows.Forms;

namespace Kickerliga
{
    class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort;
        private SortOrder OrderOfSort;
        private CaseInsensitiveComparer ObjectCompare;

        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.None;
            ObjectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            string stringContentX = listviewX.SubItems[ColumnToSort].Text;
            string stringContentY = listviewY.SubItems[ColumnToSort].Text;
            int intContentX;
            int intContentY;

            if (Int32.TryParse(stringContentX, out intContentX) && Int32.TryParse(stringContentY, out intContentY))
            {
                compareResult = ObjectCompare.Compare(intContentX, intContentY);
            }
            else
            {
                compareResult = ObjectCompare.Compare(stringContentX, stringContentY);
            }

            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }
    }
}
