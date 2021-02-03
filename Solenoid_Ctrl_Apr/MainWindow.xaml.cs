using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using System.Text.RegularExpressions;//電話番号の入力制限用


namespace Solenoid_Ctrl_Apr
{
   public struct _BtnName
    {
        public const string WAIT = "TxbWait";
        public const string SOL0 = "TxbSol0";
        public const string SOL1 = "TxbSol1";

        public enum EnmTest
        {
            Enm0,
            Enm1,
            Enm2
        };

        public const string Test0 = "00";
        public const string Test1 = "11";
        public const string Test2 = "22";
        public const string TestA = "AA";
    }

    public partial class MainWindow : Window
    {
        clsData cls_Data = new clsData();

        public MainWindow()
        {
            InitializeComponent();
            //var dataList = new ObservableCollection<clsData>();

            //DG_Sequence.ItemsSource = dataList;

        }

        //********************************************************************
        //********************************************************************
        //********************************************************************
        private void BtnDebug_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(int.Parse(_BtnName.Test0).ToString());
            MessageBox.Show(int.Parse(_BtnName.Test1).ToString());
            MessageBox.Show(int.Parse(_BtnName.Test2).ToString());
            try
            {
                MessageBox.Show(int.Parse(_BtnName.TestA).ToString());
            }
            catch(Exception)
            {
                MessageBox.Show("Err");
            }
        }

        //********************************************************************
        //********************************************************************
        //********************************************************************

        void Select_DG(DataGrid dg, int selectIndex)
        {
            dg.Focus();
            dg.SelectedIndex = selectIndex;
        }



        //********************************************************************
        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {

        }

        //********************************************************************
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string str;
            int LoopNum = DG_Sequence.Items.Count;
            for(int i = 0; i < LoopNum; i++)
            {

            }
        }

        //********************************************************************
        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //********************************************************************
        void SetItem(string str_name, int time)
        {
            //var data = new clsData() { Item = str_name, time = time, Unit = "ms" };
            DG_Sequence.Items.Add(new clsData() { Item = str_name, Time = time, Unit = "ms" });

        }



        //********************************************************************
        private void Txb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Txb = (TextBox)sender;
            string strVal = Txb.Text;
            bool blBtnEnable = false;

            if (strVal != null && strVal != "" && strVal != "0") blBtnEnable = true;

            switch (Txb.Name)
            {
                case _BtnName.WAIT:
                    if (Btn_SetWait != null)
                        Btn_SetWait.IsEnabled = blBtnEnable;
                    break;
                case _BtnName.SOL0:
                    if (Btn_SetSol0 != null)
                        Btn_SetSol0.IsEnabled = blBtnEnable;
                    break;
                case _BtnName.SOL1:
                    if (Btn_SetSol1 != null)
                        Btn_SetSol1.IsEnabled = blBtnEnable;
                    break;
            }

        }

        //********************************************************************
        private void Txb_LimitOnlyNumver(object sender, TextCompositionEventArgs e)
        {
            var Txb = (TextBox)sender;
            string strVal = Txb.Text;
            Regex regex = new Regex("[^0-9.-]+");

            switch (Txb.Name)
            {
                case "TxbWait":
                    if (Btn_SetWait != null)
                        strVal = TxbWait.Text + e.Text;
                    break;
                case "TxbSol0":
                    if (TxbSol0 != null)
                        strVal = TxbSol0.Text + e.Text;
                    break;
                case "TxbSol1":
                    if (TxbSol1 != null)
                        strVal = TxbSol1.Text + e.Text;
                    break;
            }

            e.Handled = regex.IsMatch(strVal);
        }

        //********************************************************************
        private void Btn_Set_Click(object sender, RoutedEventArgs e)
        {
            var Btn = (Button)sender;

            switch (Btn.Name)
            {
                case "Btn_SetWait":
                    SetItem("Wait", int.Parse(TxbWait.Text));
                    break;
                case "Btn_SetSol0":
                    SetItem("Sol0", int.Parse(TxbSol0.Text));
                    break;
                case "Btn_SetSol1":
                    SetItem("Sol1", int.Parse(TxbSol1.Text));
                    break;
            }
            //最終行にスクロール
            DG_Sequence.ScrollIntoView(DG_Sequence.Items.GetItemAt(DG_Sequence.Items.Count - 1));

            Select_DG(DG_Sequence, DG_Sequence.Items.Count - 1);

            BtnDel.IsEnabled = true;
            BtnSave.IsEnabled = true;
            BtnRun.IsEnabled = true;
        }

        //********************************************************************
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            int SelectIndex = DG_Sequence.SelectedIndex;

            if (SelectIndex < 0)
                MessageBox.Show("選択無し");
            DG_Sequence.Items.Remove(DG_Sequence.Items[SelectIndex]);

            Select_DG(DG_Sequence, DG_Sequence.Items.Count - 1);

            if (DG_Sequence.Items.Count <= 0 || SelectIndex < 0)
                BtnDel.IsEnabled = false;
        }
    }

}
