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
    /// UCPerk.xaml 的交互逻辑
    /// </summary>
    public partial class UCPerk : UserControl
    {
        public UCPerk()
        {
            InitializeComponent();

            _block = FindResource("b_lock") as Brush;
            _bunlock = FindResource("b_unlock") as Brush;
            _bsublock = FindResource("b_sublock") as Brush;
            _bsubhave = FindResource("b_have") as Brush;

            _perk = DataContext as Perk;
            MainLock = true;
            SubLock = false;
            ZGlobal.role.LevelChanged += Role_LevelChanged;
        }

        private Perk _perk;
        private Brush _block;
        private Brush _bunlock;
        private Brush _bsublock;
        private Brush _bsubhave;

        public bool MainLock
        {
            get => _mainlock;
            set
            {
                if (_mainlock != value)
                {
                    _mainlock = value;
                    OnMainLockChanged();
                }
            }
        }
        private bool _mainlock;
        public bool SubLock
        {
            get => _sublock;
            set
            {
                if (_sublock != value)
                {
                    _sublock = value;
                    OnSubLockChanged();
                }
            }
        }
        private bool _sublock;

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (_perk == null)
            {
                _perk = DataContext as Perk;
                _perk.Parent.StatPointChanged += OnStatPointChanged;
            }
        }

        private void OnStatPointChanged(object sender, EventArgs e)
        {
            // perk层级 大于 stat point，则锁定
            if (_perk.Level > _perk.Parent.Point)
                MainLock = true;
            else
                MainLock = false;
        }

        private void Role_LevelChanged(object sender, EventArgs e)
        {
            // 当前subperk（从0开始）的下一级的级别 大于 角色等级，则锁定
            // 0级必定解锁
            if (_perk.SubLevel == 0)
                SubLock = false;
            else if (_perk.SubLevel == _perk.SubPerk.Count)
                SubLock = false;
            else if (_perk.SubPerk[_perk.SubLevel] > ZGlobal.role.Level)
                SubLock = true;
            else
                SubLock = false;

            if (_perk.SubLevel < _perk.SubPerk.Count)
            {
                label_nextlvl.Content = _perk.SubPerk[_perk.SubLevel];
                grid_nextlvl.Background = _bunlock;
            }
            else
            {
                label_nextlvl.Content = "NA";
                grid_nextlvl.Background = _block;
            }

            // 改变已经拥有的perk的底色
            if (_perk.SubLevel > 0)
                grid_have.Background = _bsubhave;
            else
                grid_have.Background = _bunlock;
        }

        private void OnMainLockChanged()
        {
            if (MainLock)
                grid_main.Background = _block;
            else
                grid_main.Background = _bunlock;
        }
        private void OnSubLockChanged()
        {
            if (SubLock)
                grid_sub.Background = _bsublock;
            else
                grid_sub.Background = _bunlock;
        }

        private void OnLeftMBUp(object sender, MouseButtonEventArgs e)
        {
            // inc
            // mainlock 则不通过
            // sublock 则不通过
            // 通过；
            // 未超过sub上限，增加等级，增加sublevel

            var role = ZGlobal.role;
            if (ZGlobal.progress == ZProgress.Perk)
                if (!MainLock)
                    if (!SubLock)
                    {
                        if (_perk.SubLevel < _perk.SubPerk.Count)
                        {
                            _perk.SubLevel++;
                            role.Level++;
                            ZGlobal.record.Add(new Tuple<int, string>(role.Level,"+"+_perk.Name));
                        }
                    }
        }

        private void OnRightMBUp(object sender, MouseButtonEventArgs e)
        {
            // dec
            // 如果sublevel大于0
            // 减等级，减sublevel
            var role = ZGlobal.role;
            if (_perk.SubLevel > 0)
            {
                _perk.SubLevel--;
                role.Level--;   // level change at last time for ui refresh
                ZGlobal.record.Add(new Tuple<int, string>(role.Level, "-"+_perk.Name));
            }
        }
    }
}
