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

namespace F4perkSimc
{
    /// <summary>
    /// UCState.xaml 的交互逻辑
    /// </summary>
    public partial class UCState : UserControl
    {
        public UCState()
        {
            InitializeComponent();
        }
        private Stat _stat;

        private void Inc_Button(object sender, RoutedEventArgs e)
        {
            // todo
            if (_stat == null)
                _stat = DataContext as Stat;

            var role = ZGlobal.role;
            if (role.OriginPoint > 0 &&_stat.Point<10)
            {                
                role.OriginPoint--;
                _stat.Point++;
            }
        }

        private void Dec_Button(object sender, RoutedEventArgs e)
        {
            if (_stat == null)
                _stat = DataContext as Stat;
            if (_stat.Point > 1)
            {
                // 如果当前stat等级上有perk点，则不可消除
                var role = ZGlobal.role;
                var index = role.StatList.IndexOf(_stat);
                if (role.PkList[index][_stat.Point - 1].SubLevel == 0)
                {
                    _stat.Point--;
                    ZGlobal.role.OriginPoint++;
                }
            }
        }
    }
}
