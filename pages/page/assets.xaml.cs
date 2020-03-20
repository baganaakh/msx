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
using System.Data;
using System.Text.RegularExpressions;
using Admin.dbBind;
using System.Globalization;

namespace Admin
{
    /// <summary>
    /// Interaction logic for assets.xaml
    /// </summary>
    public partial class assets : Page
    {
        public assets()
        {
            InitializeComponent();
            FillDataGrid();
        }
        string connectionString = Properties.Settings.Default.ConnectionString;
        string id;
        demoEntities10 DE = new demoEntities10();
        #region edit
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            upd.IsEnabled = true;
            var values = DateTable2.SelectedItem as Asset;
            if (null == values) return;
            avolume.Text = values.volume.ToString();
            acode.Text = values.code;
            aname.Text = values.name;
            aprice.Text = values.price.ToString();
            anote.Text = values.note;
            artio.Text =values.ratio.ToString();
            aexpire.SelectedDate = values.expireDate;
            astate.SelectedIndex= values.state+1;
        }
        #endregion
        #region insert
        private void insertFunc(object sender, RoutedEventArgs e)
        {
            if (aexpire.SelectedDate == null)
            {
                MessageBox.Show("Please Set Date !!!!!");
                return;
            }
            using(demoEntities10 contx=new demoEntities10())
            {
                Asset ast = new Asset
                {
                    code = acode.Text,
                    name = aname.Text,
                    price=Convert.ToDecimal(aprice.Text),
                    note=anote.Text,
                    ratio=Convert.ToDecimal( artio.Text)/100,
                    expireDate=Convert.ToDateTime( aexpire.SelectedDate),
                    state=Convert.ToInt16(astate.SelectedIndex -1),
                    volume = Convert.ToInt32(avolume.Text),
                };
                contx.Assets.Add(ast);
                contx.SaveChanges();
            }
            FillDataGrid();
        }
        #endregion
        #region refresh, new, Number and FillGrid
        private void FillDataGrid()
        {
            demoEntities10 de = new demoEntities10();
            DateTable2.ItemsSource = de.Assets.ToList();
        }
        private void refreshh(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }
        private void newData(object sender, RoutedEventArgs e)
        {
            acode.Text = null;
            aname.Text = null;
            aprice.Text = null;
            anote.Text = null;
            artio.Text = "00.00";
            aexpire.SelectedDate = null;
            astate.Text = null;
            id = null;
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            App.TextBox_PreviewTextInput(sender, e);
        }
        #endregion
        #region delete
        private void delete(object sender, RoutedEventArgs e)
        {
            var value = DateTable2.SelectedItem as Asset;
            if (value == null) return;
            using(demoEntities10 conx=new demoEntities10())
            {
                var del = conx.Assets.Where(x => x.id == value.id).First();
                conx.Assets.Remove(del);
                conx.SaveChanges();
            }
            FillDataGrid();
        }
        #endregion
        #region update
        private void update(object sender, RoutedEventArgs e)
        {
            var ac = DateTable2.SelectedItem as Asset;            
            using(demoEntities10 conx =new demoEntities10())
            {
                Asset asst = conx.Assets.FirstOrDefault(r => r.id == ac.id);
                asst.code = acode.Text;
                asst.name = aname.Text;
                asst.price = Convert.ToInt32(aprice.Text);
                asst.note = anote.Text;
                asst.state = Convert.ToInt16(astate.SelectedIndex - 1);
                asst.ratio = Convert.ToDecimal(artio.Text);
                asst.expireDate = Convert.ToDateTime( aexpire.SelectedDate);
                asst.volume = Convert.ToInt32(avolume.Text);
                conx.SaveChanges();
            }          
            FillDataGrid();
        }
        #endregion        
    }
}
