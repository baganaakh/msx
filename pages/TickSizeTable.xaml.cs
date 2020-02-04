﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using pages.dbBind;

namespace pages
{
    /// <summary>
    /// Interaction logic for TickSizeTable.xaml
    /// </summary>
    public partial class TickSizeTable : Page
    {
        public TickSizeTable()
        {
            InitializeComponent();
            FillDataGrid();
            bindCombo();
        }
        string connectionString = Properties.Settings.Default.ConnectionString;
        static string id,statid,tid,name;
        #region edit
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var values = DateTable2.SelectedItem as DataRowView;
            if (null == values) return;
            id = values.Row[0].ToString();
            string tableId = values.Row[1].ToString();
            string Tick= values.Row[2].ToString();
            string price = values.Row[3].ToString();
            string State = values.Row[4].ToString();

            tableid.SelectedValue=tableId;
            tickk.Text=Tick;
            pricee.Text=price;
            stat.SelectedValue= State ;
            upd.IsEnabled = true;
        }
        #endregion
        #region insert
        private void insertFunc(object sender, RoutedEventArgs e)
        {
            if (statid == null || tid == null)
                return;
            upd.IsEnabled = true;
            string tick= tickk.Text;
            string price = pricee.Text;
          
            System.Data.SqlClient.SqlConnection sqlConnection1 =
           new System.Data.SqlClient.SqlConnection(connectionString);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into dbo.TickSizeTable (tableid, tick, price, state, name) values" +
                " ('" + tid+ "',N'" + tick+ "',N'" + price+ "',N'" + statid+ "', N'"+ name+"')";

            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            FillDataGrid();
        }
        #endregion
        #region numbers
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        #endregion
        #region fill
        private void FillDataGrid()
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                 string CmdString = "SELECT * FROM dbo.TickSizeTable";
                SqlCommand cmd = new SqlCommand(CmdString, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Securities");
                sda.Fill(dt);
                DateTable2.ItemsSource = dt.DefaultView;
            }
        }
        private void refreshh(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }
        #endregion
        #region new
        private void newData(object sender, RoutedEventArgs e)
        {
            tableid.Text = null;
            tickk.Text = null;
            pricee.Text = null;
            stat.Text = null;
            id = null;
            statid = null;
        }
        #endregion
        #region delete
        private void delete(object sender, RoutedEventArgs e)
        {
            var value = DateTable2.SelectedItem as DataRowView;
            if (null == value) return;
            id = value.Row[0].ToString();
            System.Data.SqlClient.SqlConnection sqlConnection1 =
           new System.Data.SqlClient.SqlConnection(connectionString);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE demo.dbo.TickSizeTable WHERE id='" + id + "'";
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            FillDataGrid();
        }
        #endregion
        #region update
        private void update(object sender, RoutedEventArgs e)
        {
            string tick = tickk.Text;
            string price = pricee.Text;

            System.Data.SqlClient.SqlConnection sqlConnection1 =
           new System.Data.SqlClient.SqlConnection(connectionString);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE demo.dbo.TickSizeTable SET " +
                "tableid= '" + tid + "', " +
                "tick= '" + tick+ "', " +
                "price= '" + price + "', " +
                "state= '" + statid + "', " +
                "name= N'" + name + "' " +
                "WHERE id = '" + id + "'";

            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            FillDataGrid();
        }
        #endregion
        #region combos
        public List<State> statt { get; set; }
        public List<Ttable> tabble { get; set; }

        private void bindCombo()
        {
            demoEntities10 st = new demoEntities10();
            var items = st.States.ToList();
            statt = items;
            stat.ItemsSource = statt;
            
            var titems = st.Ttables.ToList();
            tabble = titems;
            tableid.ItemsSource = tabble;
        }

        private void tableid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var items = tableid.SelectedItem as Ttable;
            try
            {
                name = items.name.ToString();
                tid = items.id.ToString();
            }
            catch
            {
                return;
            }
        }

        private void sstate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var items = stat.SelectedItem as State;
            try
            {
                statid = items.id.ToString();
            }
            catch
            {
                return;
            }
        }
        #endregion
    }
}
