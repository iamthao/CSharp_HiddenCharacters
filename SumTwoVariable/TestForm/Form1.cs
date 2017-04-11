using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        

        BindingSource bs = new BindingSource();
        List<MyClass>
          list = new List<MyClass>();

        public int total = 0;
        public int skip = 0;
        public int take = 2;
        public int page = 0;
        public Form1()
        {
            InitializeComponent();
            CreateList();
            LoadNavigate();
        }

       

        private void CreateList()
        {
            for (int i = 0; i < 3; i++)
            {
                list.Add(new MyClass { Id = i + 1, Name1 = "A_" + i });
            }
        }
      
        public void LoadNavigate()
        {

            bindingNavigator1.BindingSource = bs;
            //bs.PositionChanged += bs_PositionChanged;
            bs_PositionChanged(bs, EventArgs.Empty);

        }

        void bs_PositionChanged(object sender, EventArgs e)
        {
            if (bs.Position == 0)
            {
                page = bs.Position;
                skip = page * take;
                var data = GetData();
                bs.DataSource = new PageOffsetList(take, total);
                dataGridView1.DataSource = data;
            }
            else
            {
                page = bs.Position;
                skip = page*take;
                var data = GetData();
                bs.DataSource = new PageOffsetList(take, total);

                while (data.Count == 0)
                {
                    page = bs.Position;
                    skip = page*take;
                    data = GetData();
                    bs.DataSource = new PageOffsetList(take, total);
                }
                if (data.Count > 0)
                    dataGridView1.DataSource = data;
            }
        }

        public class MyClass
        {
            public int Id { get; set; }
            public string Name1 { get; set; }
        }

        public List<MyClass> GetData()
        {
            total = list.Count();
            var data = list.OrderBy(o => o.Id).Skip(skip).Take(take).ToList();
            return data;
        }

        public class  ObjReturn
        {
            public int TotalRecords;
            public int PageSize ;
        }
        public class PageOffsetList : IListSource
        {
            public bool ContainsListCollection
            {
                get;
                protected set;
            }
            private int TotalRecords = 0;
            private int pageSize = 0;
            public PageOffsetList(int pageSize, int total)
            {
                this.TotalRecords = total;
                this.pageSize = pageSize;
            }
            public IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"   
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < TotalRecords; offset = offset + pageSize)
                {
                    pageOffsets.Add(offset);
                }
                return pageOffsets;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex].Name == "Delete")
            {
                var assessmentId = senderGrid.Rows[e.RowIndex].Cells["Id"].Value;
                list.Remove(list.FirstOrDefault(s => s.Id == Convert.ToInt32(assessmentId)));
                bs_PositionChanged(bs, EventArgs.Empty);
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            page = bs.Position + 1;
            bs_PositionChanged(bs, EventArgs.Empty);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            page = bs.Position - 1;
            bs_PositionChanged(bs, EventArgs.Empty);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            GetData();
            page = total/take - 1;
            bs_PositionChanged(bs, EventArgs.Empty);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            page = 0;
            bs_PositionChanged(bs, EventArgs.Empty);
        }

        private void bindingNavigatorPositionItem_Leave(object sender, EventArgs e)
        {
            page = bs.Position - 1;
            bs_PositionChanged(bs, EventArgs.Empty);
        }
    }
}
