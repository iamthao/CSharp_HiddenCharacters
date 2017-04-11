using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagingDatagird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int currentPageIndex = 1;
        int pageSize = 17;
        int pageNumber = 0;
        int fistRow, lastRow;
        int rows;
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QLSX;Integrated Security=True");


        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "select count(*) as MaxNumber from KyHieuSo";//Muc dich de lay ra so dong.
            //string sql = "select * from KyHieuSo";
            SqlCommand cmd = new SqlCommand(sql, conn);
            //conn.Open();
            rows = 100;//Convert.ToInt32(cmd.ExecuteScalar());
            pageTotal();
            //conn.Close();
            //MessageBox.Show(rows.ToString());
        }
        void pageTotal()
        {
            pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
            label3.Text = " / " + pageNumber.ToString();
            cmbPage.Items.Clear();
            for (int i = 1; i < pageNumber; i++)
            {
                cmbPage.Items.Add(i + "");
            }
            cmbPage.SelectedIndex = 0;
        }

        private void cmbPage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //currentPageIndex = Convert.ToInt32(cmbPage.Text);
            //fistRow = pageSize * (currentPageIndex - 1); //Dong dau
            //lastRow = pageSize * (currentPageIndex);//Dong cuoi cua 1 trang duoc chon.
            ////MessageBox.Show(fistRow + " " + lastRow);
            //string sql = "select Row_number() over(order by KyHieu) STT, * from KyHieuSo";
            //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds, fistRow, pageSize, "KyHieuSo");
            //dataGridView1.DataSource = ds.Tables[0];
                
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(numericUpDown1.Value);
            pageTotal();
        }

        private void cmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPageIndex = Convert.ToInt32(cmbPage.Text);
            fistRow = pageSize * (currentPageIndex - 1); //Dong dau
            lastRow = pageSize * (currentPageIndex);//Dong cuoi cua 1 trang duoc chon.
            //MessageBox.Show(fistRow + " " + lastRow);
            //string sql = "select Row_number() over(order by KyHieu) STT, * from KyHieuSo";
            //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds, fistRow, pageSize, "KyHieuSo");
            var list = new List<MyClass>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new MyClass { Id = i +1, Name = "A_"+i });
            }

            dataGridView1.DataSource = list;
        }

        public class MyClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
