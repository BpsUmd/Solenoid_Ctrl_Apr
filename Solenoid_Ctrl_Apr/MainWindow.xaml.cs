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
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
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
            SetItem("test", 100);
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
        private void TxbWait_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Txb = (TextBox)sender;
            string strVal = Txb.Text;
            bool blBtnEnable = false;

            if (strVal != null && strVal != "" && strVal != "0") blBtnEnable = true;

            switch (Txb.Name)
            {
                case "TxbWait":
                    if (Btn_SetWait != null)
                        Btn_SetWait.IsEnabled = blBtnEnable;
                    break;
                case "TxbLeft":
                    if (Btn_SetLeft != null)
                        Btn_SetLeft.IsEnabled = blBtnEnable;
                    break;
                case "TxbRight":
                    if (Btn_SetRight != null)
                        Btn_SetRight.IsEnabled = blBtnEnable;
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
                case "TxbLeft":
                    if (TxbLeft != null)
                        strVal = TxbLeft.Text + e.Text;
                    break;
                case "TxbRight":
                    if (TxbRight != null)
                        strVal = TxbRight.Text + e.Text;
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
                case "Btn_SetLeft":
                    SetItem("Left", int.Parse(TxbLeft.Text));
                    break;
                case "Btn_SetRight":
                    SetItem("Right", int.Parse(TxbRight.Text));
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
