using System;
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
        }
        //********************************************************************
        private void Btn_SetWait_Click(object sender, RoutedEventArgs e)
        {

        }

        //********************************************************************
        private void Btn_SetLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        //********************************************************************
        private void Btn_SetRight_Click(object sender, RoutedEventArgs e)
        {

        }

        //********************************************************************
        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {

        }

        //********************************************************************
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        //********************************************************************
        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {

        }

        //********************************************************************
        void SetItem(string str_name, int time)
        {
            cls_Data.Item = str_name;
            cls_Data.time = time;
            cls_Data.Unit = "ms";

            DG_Sequence.Items.Add(new clsData() { Item = str_name, time = time, Unit = "ms" });
            
        }



        //********************************************************************
        //********************************************************************
        //********************************************************************
        private void BtnDebug_Click(object sender, RoutedEventArgs e)
        {
            SetItem("test", 100);
        }


    }
}
