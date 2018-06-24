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
using System.ComponentModel;

namespace F4perkSimc
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _role = FindResource("role") as Person;
            ZGlobal.role = _role;

            us_s.DataContext = _role.StatList[0];
            us_p.DataContext = _role.StatList[1];
            us_e.DataContext = _role.StatList[2];
            us_c.DataContext = _role.StatList[3];
            us_i.DataContext = _role.StatList[4];
            us_a.DataContext = _role.StatList[5];
            us_l.DataContext = _role.StatList[6];

            _role.InitStatOver += _role_InitStatOver;

            if (ZGlobal.progress == ZProgress.Stat)
                ExtraOff();

            for (int r = 1; r <= 10; r++)
            {
                for (int c = 0; c < 7; c++)
                {
                    UCPerk up = new UCPerk
                    {
                        DataContext = _role.PkList[c][r - 1]
                    };                    
                    if (r == 1)
                    {
                        up.MainLock = false;
                        up.SubLock = false;
                    }
                    grid_perk.Children.Add(up);
                    Grid.SetRow(up, r);
                    Grid.SetColumn(up, c);
                }
            }
        }

        private Dictionary<char, int> _dict = new Dictionary<char, int>
        {
            ['s'] = 0,
            ['p'] = 1,
            ['e'] = 2,
            ['c'] = 3,
            ['i'] = 4,
            ['a'] = 5,
            ['l'] = 6
        };

        private void _role_InitStatOver(object sender, EventArgs e)
        {
            ZGlobal.progress = ZProgress.Perk;
            ExtraOn();
        }

        private static Person _role;

        private void ResetBt_Click(object sender, RoutedEventArgs e)
        {
            _role.PointReset();
            ZGlobal.progress = ZProgress.Stat;
            ExtraOff();
        }

        #region Extra Stat Point
        private void ExtraStat_Click(object sender, RoutedEventArgs e)
        {
            var src = e.OriginalSource as Button;
            var name = src.Name;
            if (name == "extra_stat")
            {
                _role.OriginPoint++;
            }
            else
            {
                var c = name.Last();
                var st = _role.StatList[_dict[c]];
                st.Point++;
                ZGlobal.record.Add(new Tuple<int, string>(_role.Level,"+"+st.Name));
            }
            Person.Origin++;
            src.IsEnabled = false;
        }
        private void ExtraOff()
        {
            extra_stat.IsEnabled = false;
            extra_s.IsEnabled = false;
            extra_p.IsEnabled = false;
            extra_e.IsEnabled = false;
            extra_c.IsEnabled = false;
            extra_i.IsEnabled = false;
            extra_a.IsEnabled = false;
            extra_l.IsEnabled = false;
        }
        private void ExtraOn()
        {
            extra_stat.IsEnabled = true;
            extra_s.IsEnabled = true;
            extra_p.IsEnabled = true;
            extra_e.IsEnabled = true;
            extra_c.IsEnabled = true;
            extra_i.IsEnabled = true;
            extra_a.IsEnabled = true;
            extra_l.IsEnabled = true;
        }
        #endregion

        private void PerkHeader_PreviewLMBUp(object sender, MouseButtonEventArgs e)
        {
            // inc
            // 超过10，则不通过
            // 存在 剩余属性点，则不加等级
            var src = e.OriginalSource as TextBlock;
            var name = src.Name;
            var c = name.Last();
            var index = _dict[c];
            var st = _role.StatList[_dict[c]];

            if ( st.Point < 10)
            {
                // 如果stat point总和小于基础点，则消耗点数
                // 如果stat point总和大于等于基础点，则升级
                var sum = SumOfStatPoint();
                if (sum < Person.Origin + 7)
                    _role.OriginPoint--;
                else
                {
                    _role.Level++;
                    ZGlobal.record.Add(new Tuple<int, string>(_role.Level,"+"+ st.Name));
                }
                st.Point++;
            }
        }

        private void PerkHeader_PreviewRMBUp(object sender, MouseButtonEventArgs e)
        {
            // dec
            var src = e.OriginalSource as TextBlock;
            var name = src.Name;
            var c = name.Last();
            var index = _dict[c];
            var st = _role.StatList[_dict[c]];

            if (st.Point > 1)
            {
                // 如果当前stat等级上有perk点，则不可消除               
                if (_role.PkList[index][st.Point - 1].SubLevel == 0)
                {
                    // 消除
                    st.Point--;

                    // 如果 当前stat point的和大于基础点数， 则 降级+不返还点
                    // 如果 当前stat point的和小于基础点， 则不降级+返还点
                    // 如果 当前stat point的和等于基础点（28+extra），则降级
                    var sum = SumOfStatPoint();
                    if (sum < Person.Origin + 7)
                        ZGlobal.role.OriginPoint++;
                    else
                    {
                        _role.Level--;
                        ZGlobal.record.Add(new Tuple<int, string>(_role.Level, "-"+st.Name));
                    }
                }
            }
        }

        private int SumOfStatPoint()
        {
            var sum = 0;
            foreach (var s in _role.StatList)
            {
                sum += s.Point;
            }
            return sum;
        }

        private void RecordClick(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var t in ZGlobal.record)
            {
                sb.Append(t.Item1);
                sb.Append(" ");
                sb.AppendLine(t.Item2);
            }
            MessageBox.Show(sb.ToString());
        }
    }

}
