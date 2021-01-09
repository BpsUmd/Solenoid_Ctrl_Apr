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

namespace Solenoid_Ctrl_Apr
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    /// 

    class Data
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
    }

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            // データグリッドにデータを設定します。
            // データグリッドのItemSourceに設定するデータはObservableCollectionにする必要があります。
            var dataList = new ObservableCollection<Data>();
            for (int i = 0; i < 5; ++i)
            {
                var prefix = i + 1;
                var data = CreateData(prefix);
                dataList.Add(data);
            }
            dataGrid.ItemsSource = dataList;
        }

        /**
         * @brief 追加ボタンが押下された時に呼び出されます。
         * 
         * @param [in] sender 追加ボタン
         * @param [in] e イベント
         */
        private void AddRowButton_Click(object sender, RoutedEventArgs e)
        {
            // データグリッドに行を追加します。
            var dataList = dataGrid.ItemsSource as ObservableCollection<Data>;
            var prefix = dataList.Count + 1;
            var data = CreateData(prefix);
            dataList.Add(data);
        }

        /**
         * @brief データを生成します。
         * 
         * @param [in] prefix 表示するデータの接頭文字
         * @return データ
         */
        private Data CreateData(int prefix)
        {
            var data = new Data { Value1 = $"{prefix}1", Value2 = $"{prefix}2", Value3 = $"{prefix}3" };
            return data;
        }
    }
}
