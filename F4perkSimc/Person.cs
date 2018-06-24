using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4perkSimc
{
    public class Person : INotifyPropertyChanged
    {
        // SPECIAL
        public List<Stat> StatList { get => _statList; set { if (_statList != value) { _statList = value; OnPropertyChanged("StatList"); } } }
        private List<Stat> _statList;

        // Perk
        public List<List<Perk>> PkList { get => _pklist; set { if (_pklist != value) { _pklist = value; OnPropertyChanged("PkList"); } } }
        private List<List<Perk>> _pklist;

        public Person()
        {
            // SPECIAL
            var stat_s = new Stat { Name = "S 力量", Point = 1, Tips = "影响负重，及所有近战伤害" };
            var stat_p = new Stat { Name = "P 感知", Point = 1, Tips = "影响VATS武器准度" };
            var stat_e = new Stat { Name = "E 耐力", Point = 1, Tips = "影响生命值和冲刺时消耗的点数" };
            var stat_c = new Stat { Name = "C 魅力", Point = 1, Tips = "影响对话和讲价时的说服率" };
            var stat_i = new Stat { Name = "I 智力", Point = 1, Tips = "影响获得的经验" };
            var stat_a = new Stat { Name = "A 敏捷", Point = 1, Tips = "影响VATS中的AP和潜行能力" };
            var stat_l = new Stat { Name = "L 幸运", Point = 1, Tips = "影响暴击条填充速度" };
            _statList = new List<Stat>() { stat_s, stat_p, stat_e, stat_c, stat_i, stat_a, stat_l };

            // PERK
            // S
            var s1 = new Perk() { Name = "铁拳", Level = 1, Parent = stat_s, SubPerk = { 1, 9, 18, 31, 46 }, Tips = "1.拳击伤害+20%\n2.拳击伤害+40%，且能够破坏装备\n3.拳击伤害+60%，徒手重击有一定几率瘫痪一个部位\n4.拳击伤害+80%，徒手重击有更高纪律瘫痪一个部位\n5.拳击伤害加倍，VATS中的暴击可以使对手麻痹" };
            var s2 = new Perk() { Name = "大联盟", Level = 2, Parent = stat_s, SubPerk = { 1, 7, 15, 27, 42 }, Tips = "1.近战武器伤害+20%\n2.近战武器伤害+40%，一定几率缴械\n3.近战武器伤害+60%，更高几率缴械\n4.近战武器伤害+80%，可击中面前所有目标\n5.近战武器伤害加倍，一定几率瘫痪目标，或打飞头颅" };
            var s3 = new Perk() { Name = "装甲商", Level = 3, Parent = stat_s, SubPerk = { 1, 13, 25, 39, }, Tips = "1.1级装甲改造\n2.2级装甲改造\n3.3级装甲改造\n4.4级装甲改造" };
            var s4 = new Perk() { Name = "工匠", Level = 4, Parent = stat_s, SubPerk = { 1, 16, 29 }, Tips = "1.1级近战武器改造\n2.2级近战武器改造\n3.3级近战武器改造" };
            var s5 = new Perk() { Name = "重枪手", Level = 5, Parent = stat_s, SubPerk = { 1, 11, 21, 35, 47 }, Tips = "1.重枪伤害+20%\n2.重枪伤害+40%，盲射准确度提升\n3.重枪伤害+60%，盲射准确度进一步提升\n4.重枪伤害+80%，一定几率使对手畏缩\n5.重枪伤害加倍" };
            var s6 = new Perk() { Name = "虎背", Level = 6, Parent = stat_s, SubPerk = { 1, 10, 20, 30, 40 }, Tips = "1.负重+25\n2.负重+50\n3.过重时，可以花费点数奔跑\n4.过重时，可以快速移动\n5.过重时，奔跑花费点数减半" };
            var s7 = new Perk() { Name = "稳定瞄准", Level = 7, Parent = stat_s, SubPerk = { 1, 28, 49 }, Tips = "1.提高盲射准度\n2.进一步提高盲射准度\n3.盲射伤害增加" };
            var s8 = new Perk() { Name = "破坏者", Level = 8, Parent = stat_s, SubPerk = { 1, 5, 14, 26, }, Tips = "1.近射伤害+25%\n2.近射伤害+50%，可瘫痪敌人\n3.近射伤害+75%，瘫痪率提高\n4.近射伤害加倍，瘫痪率提高，可能暴击" };
            var s9 = new Perk() { Name = "扎根", Level = 9, Parent = stat_s, SubPerk = { 1, 22, 43 }, Tips = "1.不动时，抗性+25，近战伤害+25%\n2.不动时，抗性+50，近战伤害+50%\n3.不动时，可能使对你近战攻击的敌人自动缴械" };
            var s10 = new Perk() { Name = "天堂路", Level = 10, Parent = stat_s, SubPerk = { 1, 24, 50 }, Tips = "1.穿机甲冲向敌人，可伤害并畏缩敌人（机械和巨型敌人无畏）\n2.穿机甲冲向敌人，可造成巨大伤害更强畏缩。降落冲击，可造成更多伤害（机械及巨型无畏）\n3.穿机甲冲向敌人，可造成巨大伤害并击倒。降落冲击，可造成更多伤害。" };
            var ps = new List<Perk>() { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };
            // P
            var p1 = new Perk() { Level = 1, Name = "扒手", Parent = stat_p, SubPerk = { 1, 6, 17, 30 }, Tips = "1.扒窃成功率+25%\n2.扒窃成功率+50%，可在对方道具栏中放置开保险的手榴弹\n3.扒窃成功率+75%，可扒窃装备中武器\n4.扒窃成功率极高，可扒窃装备物品" };
            var p2 = new Perk() { Level = 2, Name = "步枪手", Parent = stat_p, SubPerk = { 1, 9, 18, 31, 46 }, Tips = "1.非自动步枪伤害+20%\n2.非自动步枪伤害+40%，忽略目标装甲15%\n3.非自动步枪伤害+60%，忽略目标装甲20%\n4.非自动步枪伤害+80%，忽略25%护甲，一定几率瘫痪部位\n5.非自动步枪伤害加倍，忽略30%护甲，较高几率部位瘫痪" };
            var p3 = new Perk() { Level = 3, Name = "察觉力", Parent = stat_p, SubPerk = { 1, 14 }, Tips = "1.可以在VATS中查看目标伤害抗性资讯\n2.在VATRS中几率和伤害增加5%" };
            var p4 = new Perk() { Level = 4, Name = "锁匠", Parent = stat_p, SubPerk = { 1, 7, 18, 41 }, Tips = "1.可撬开进阶锁\n2.可撬开专家锁\n3.可撬开大师锁\n4.发卡不会坏掉" };
            var p5 = new Perk() { Level = 5, Name = "破坏专家", Parent = stat_p, SubPerk = { 1, 10, 22, 34 }, Tips = "1.爆裂物伤害+25%，可在化学工作台制作爆裂物\n2.爆裂物伤害+50%，手榴弹显示抛物线\n3.爆裂物伤害+75%，杀伤范围更大\n4.爆裂物伤害加倍，VATS的地雷和手榴弹造成加倍爆破伤害" };
            var p6 = new Perk() { Level = 6, Name = "夜猫子", Parent = stat_p, SubPerk = { 1, 25, 37 }, Tips = "1.晚6点到早6点间智力和感知+2\n2.晚间智力和感知+3，潜行获得夜视能力\n3.晚间生命+30" };
            var p7 = new Perk() { Level = 7, Name = "折射镜", Parent = stat_p, SubPerk = { 1, 11, 21, 35, 42 }, Tips = "1.能量抗性+10\n2.能量抗性+20\n3.能量抗性+30\n4.能量抗性+40\n5.能量抗性+50" };
            var p8 = new Perk() { Level = 8, Name = "狙击手", Parent = stat_p, SubPerk = { 1, 13, 26 }, Tips = "1.狙击屏气更久\n2.非自动狙击枪，一定几率击倒\n3.非自动狙击枪，VATS爆头准度+25%" };
            var p9 = new Perk() { Level = 9, Name = "贯穿", Parent = stat_p, SubPerk = { 1, 28 }, Tips = "1.VATS中遮住的部位仅准度下降\n2.VATS中遮住的部位准度不降" };
            var p10 = new Perk() { Level = 10, Name = "集中火力", Parent = stat_p, SubPerk = { 1, 26, 50 }, Tips = "1.VATS多次攻击同一部位准度+10%\n2.VATS多次攻击同一部位准度+15%\n3.VATS多次攻击同一部位准度+20%，伤害+20%" };
            var pp = new List<Perk>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
            // E
            var e1 = new Perk() { Level = 1, Name = "坚韧", Parent = stat_e, SubPerk = { 1, 9, 18, 31, 46 }, Tips = "1.伤害抗性+10\n2.伤害抗性+20\n3.伤害抗性+30\n4.伤害抗性+40\n5.伤害抗性+50" };
            var e2 = new Perk() { Level = 2, Name = "铜肠铁胃", Parent = stat_e, SubPerk = { 1, 6, 17 }, Tips = "1.进食辐射量减少\n2.进食辐射量进一步减少\n3.进食无辐射" };
            var e3 = new Perk() { Level = 3, Name = "赐命者", Parent = stat_e, SubPerk = { 1, 8, 20 }, Tips = "1.最大生命+20\n2.最大生命+40\n3.最大生命+60，可缓慢回血" };
            var e4 = new Perk() { Level = 4, Name = "药物抗性", Parent = stat_e, SubPerk = { 1, 22 }, Tips = "1.药物成瘾率-50%\n2.免疫药物成瘾" };
            var e5 = new Perk() { Level = 5, Name = "水男孩", Parent = stat_e, SubPerk = { 1, 21 }, Tips = "1.游泳无辐射，可水下呼吸\n2.潜在水中不会被发现" };
            var e6 = new Perk() { Level = 6, Name = "抗辐射", Parent = stat_e, SubPerk = { 1, 13, 26, 35, }, Tips = "1.辐射抗性+10\n2.辐射抗性+20\n3.辐射抗性+30\n4.辐射抗性+40" };
            var e7 = new Perk() { Level = 7, Name = "超合金骨骼", Parent = stat_e, SubPerk = { 1, 13, 26 }, Tips = "1.部位伤害-30%\n2.部位伤害-60%\n3.部位不受伤害" };
            var e8 = new Perk() { Level = 8, Name = "食人族", Parent = stat_e, SubPerk = { 1, 19, 38 }, Tips = "1.吃人类尸体回血\n2.吃尸鬼或变种人回血\n3.食尸生命回复提高" };
            var e9 = new Perk() { Level = 9, Name = "尸鬼体质", Parent = stat_e, SubPerk = { 1, 24, 48, 50, }, Tips = "1.辐射可回血\n2.回血增加\n3.回血更多，且尸鬼会随机友善\n4.回复辐射" };
            var e10 = new Perk() { Level = 10, Name = "太阳能", Parent = stat_e, SubPerk = { 1, 27, 50 }, Tips = "1.早6点到晚6点，力量耐力+2\n2.阳光治疗辐射\n3.阳光回血" };
            var pe = new List<Perk>() { e1, e2, e3, e4, e5, e6, e7, e8, e9, e10 };
            // C
            var c1 = new Perk() { Level = 1, Name = "瓶盖收集者", Parent = stat_c, SubPerk = { 1, 20, 41 }, Tips = "1.价格优惠\n2.价格更优惠\n3.投资500，提高商店购买力" };
            var c2 = new Perk() { Level = 2, Name = "少女杀手", Parent = stat_c, SubPerk = { 1, 7, 16 }, Tips = "1.对异性伤害+5%，对话更易说服\n2.异性伤害+10%，更易说服，更易以恐吓安抚\n3.异性伤害+15%，更易说服，更易恐吓安抚" };
            var c3 = new Perk() { Level = 3, Name = "独行侠", Parent = stat_c, SubPerk = { 1, 17, 40, 50 }, Tips = "1.无伙伴时，减伤15%，负重+50\n2.减伤30%，负重+100\n3.伤害+25%\n4.AP+25" };
            var c4 = new Perk() { Level = 4, Name = "攻击犬", Parent = stat_c, SubPerk = { 1, 9, 25, 31 }, Tips = "1.狗可以咬住敌人，VATS攻击准度提高\n2.咬住的部位几率瘫痪\n3.咬住几率失血\n4.与狗一起减伤10%" };
            var c5 = new Perk() { Level = 5, Name = "动物朋友", Parent = stat_c, SubPerk = { 1, 12, 28 }, Tips = "1.枪瞄准低级动物，几率安抚\n2.成功安抚，可煽动攻击\n3.成功安抚，可下指令" };
            var c6 = new Perk() { Level = 6, Name = "地方领导者", Parent = stat_c, SubPerk = { 1, 14 }, Tips = "1.可在工坊间建立补给线\n2.可在工坊建造商店和工作台" };
            var c7 = new Perk() { Level = 7, Name = "派对男孩", Parent = stat_c, SubPerk = { 1, 15, 37 }, Tips = "1.免疫酒精成瘾\n2.酒精效力加倍\n3.酒精效力间幸运+3" };
            var c8 = new Perk() { Level = 8, Name = "激励", Parent = stat_c, SubPerk = { 1, 19, 43 }, Tips = "1.同伴伤害提高，且不会误伤\n2.同伴抗性提高，且不会被我误伤\n3.同伴负重提高" };
            var c9 = new Perk() { Level = 9, Name = "废土低语者", Parent = stat_c, SubPerk = { 1, 21, 49 }, Tips = "1.枪瞄准低级生物，几率安抚\n2.成功安抚，可煽动攻击\n3.成功安抚，可下指令" };
            var c10 = new Perk() { Level = 10, Name = "恐吓", Parent = stat_c, SubPerk = { 1, 23, 50 }, Tips = "1.枪瞄低级人类，几率安抚\n2.成功安抚，可煽动攻击\n3.成功安抚，可下指令" };
            var pc = new List<Perk>() { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10 };
            // I
            var i1 = new Perk() { Level = 1, Name = "导航系统", Parent = stat_i, SubPerk = { 1, 36 }, Tips = "1.VATS中显示任务路径\n2.感知+2" };
            var i2 = new Perk() { Level = 2, Name = "医护", Parent = stat_i, SubPerk = { 1, 18, 30, 49 }, Tips = "1.治疗针治疗40%，消辐宁消辐40%\n2.效果60%\n3.效果80%\n4.效果100%，且效用加快" };
            var i3 = new Perk() { Level = 3, Name = "枪技迷", Parent = stat_i, SubPerk = { 1, 13, 25, 39 }, Tips = "1.等级1枪械改造开放\n2.等级2开放\n3.等级3开放\n4.等级4开放" };
            var i4 = new Perk() { Level = 4, Name = "骇客", Parent = stat_i, SubPerk = { 1, 9, 21, 33 }, Tips = "1.破解进阶终端\n2.破解专家终端\n3.破解大师终端\n4.突发情况不会锁定终端" };
            var i5 = new Perk() { Level = 5, Name = "拆解专家", Parent = stat_i, SubPerk = { 1, 23, 40 }, Tips = "1.拆武器装甲，可出现罕见零件，铜铝螺丝\n2.拆卸获得更罕见零件，电路元件、核子材料、光学纤维\n3.拆卸收获更多\n4." };
            var i6 = new Perk() { Level = 6, Name = "科学", Parent = stat_i, SubPerk = { 1, 17, 28, 41 }, Tips = "1.开放1级高科技改造\n2.开放2级科技改造\n3.开放3级科技改造\n4.开放4级科技改造" };
            var i7 = new Perk() { Level = 7, Name = "药剂师", Parent = stat_i, SubPerk = { 1, 16, 32, 45 }, Tips = "1.药效时间+50%\n2.药效时间加倍\n3.药效时间+150%\n4.药效时间+200%" };
            var i8 = new Perk() { Level = 8, Name = "机器人专家", Parent = stat_i, SubPerk = { 1, 19, 44 }, Tips = "1.破解机器人，可开关或自爆\n2.破解后，可煽动其进攻\n3.破解后，可下命令" };
            var i9 = new Perk() { Level = 9, Name = "核物理学家", Parent = stat_i, SubPerk = { 1, 14, 26 }, Tips = "1.辐射武器伤害+50%，核心寿命+25%\n2.辐射武器伤害加倍，核心寿命+50%\n3.核心可弹出，如同破坏力巨大的手榴弹。核心寿命加倍" };
            var i10 = new Perk() { Level = 10, Name = "忍无可忍", Parent = stat_i, SubPerk = { 1, 31, 50 }, Tips = "1.生命低于20%时，时间减慢，伤害抗性+20，伤害+20%\n2.愤怒伤害抗性+30，伤害+30%\n3.愤怒伤害抗性+40，伤害+40%，杀敌可回血" };
            var pi = new List<Perk>() { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10 };
            // A
            var a1 = new Perk() { Level = 1, Name = "双枪侠", Parent = stat_a, SubPerk = { 1, 7, 15, 27, 42 }, Tips = "1.非自动手枪伤害+20%\n2.非自动手枪伤害+40%，提高射程\n3.非自动手枪伤害提高+60%，射程更提高\n4.非自动手枪伤害+80%，可缴械\n5.非自动手枪伤害加倍，更高几率缴械，可瘫痪部位" };
            var a2 = new Perk() { Level = 2, Name = "突击队", Parent = stat_a, SubPerk = { 1, 11, 21, 35, 49 }, Tips = "1.自动武器伤害+20%\n2.自动武器伤害+40%，盲射准度提高\n3.自动武器伤害+60%，盲射准度提升更多\n4.自动武器伤害+80%，几率畏缩\n5.自动武器伤害加倍，更高几率畏缩" };
            var a3 = new Perk() { Level = 3, Name = "潜行", Parent = stat_a, SubPerk = { 1, 5, 12, 23, 38 }, Tips = "1.潜行被发现难度+20%\n2.潜行+30%，不触发地板陷阱\n3.潜行+40%，不引爆地雷\n4.潜行+50%，消除跑步影响\n5.进入隐匿时，远方的敌人看不清你的踪迹" };
            var a4 = new Perk() { Level = 4, Name = "睡魔", Parent = stat_a, SubPerk = { 1, 17, 30 }, Tips = "1.消音武器偷袭伤害+15%\n2.消音偷袭伤害+30%\n3.消音偷袭伤害+50%" };
            var a5 = new Perk() { Level = 5, Name = "行动派男孩", Parent = stat_a, SubPerk = { 1, 18, 38 }, Tips = "1.AP回复+25%\n2.回复+50%\n3.回复+75%" };
            var a6 = new Perk() { Level = 6, Name = "移动标靶", Parent = stat_a, SubPerk = { 1, 24, 44 }, Tips = "1.冲刺时，伤害抗性+25，能量抗性+25\n2.冲刺时，伤害抗性+50，能量抗性+50\n3.冲刺消耗点数-50%" };
            var a7 = new Perk() { Level = 7, Name = "忍者", Parent = stat_a, SubPerk = { 1, 16, 33 }, Tips = "1.远程偷袭提升2.5倍，近战偷袭伤害提升4倍\n2.远程3倍，近程5倍\n3.远程3.5倍，近程10倍" };
            var a8 = new Perk() { Level = 8, Name = "快手", Parent = stat_a, SubPerk = { 1, 28, 40 }, Tips = "1.加快装填\n2.VATS中装填不消耗点数\n3.AP+10" };
            var a9 = new Perk() { Level = 9, Name = "雷电突袭", Parent = stat_a, SubPerk = { 1, 29 }, Tips = "1.VATS近战距离提高\n2.VATS近战距离进一步提高，距离越远，伤害越大" };
            var a10 = new Perk() { Level = 10, Name = "功夫枪法", Parent = stat_a, SubPerk = { 1, 26, 50 }, Tips = "1.VATS中对第二个以上的目标伤害+25%\n2.VATS中对第三个以上的目标伤害+50%\n3.VATS中对第四个以上目标暴击" };
            var pa = new List<Perk>() { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 };
            // L
            var l1 = new Perk() { Level = 1, Name = "寻宝高手", Parent = stat_l, SubPerk = { 1, 5, 25, 40 }, Tips = "1.可发现更多瓶盖\n2.发现的瓶盖更多\n3.更多瓶盖\n4.更多瓶盖，杀死敌人时，敌人可能会炸成一堆瓶盖" };
            var l2 = new Perk() { Level = 2, Name = "搜刮者", Parent = stat_l, SubPerk = { 1, 7, 24, 37 }, Tips = "1.发现更多弹药\n2.更多弹药\n3.更多弹药\n4.发射弹夹最后一颗子弹后，有几率获得弹药" };
            var l3 = new Perk() { Level = 3, Name = "血肉横飞", Parent = stat_l, SubPerk = { 1, 9, 31, 47 }, Tips = "1.伤害+5%%，不时使敌人血肉横飞\n2.伤害+10%\n3.伤害+15%\n4.敌人爆炸时，附近的敌人同样下场" };
            var l4 = new Perk() { Level = 4, Name = "神秘客", Parent = stat_l, SubPerk = { 1, 22, 41, 49 }, Tips = "1.神秘客不时在VATS中帮忙\n2.更经常出现在VATS中\n3.更常出现，其每杀死一个对手，几率填充暴击条\n4.更常出现，其每杀死一个对手，高几率填充暴击条" };
            var l5 = new Perk() { Level = 5, Name = "白痴学者", Parent = stat_l, SubPerk = { 1, 11, 34 }, Tips = "1.任何行动几率获得3倍经验，反相关与智力\n2.5倍经验\n3.5倍经验，获得之后短期杀敌3倍经验" };
            var l6 = new Perk() { Level = 6, Name = "暴击强化", Parent = stat_l, SubPerk = { 1, 15, 40 }, Tips = "1.爆伤+50%\n2.爆伤+100%\n3.爆伤+150%" };
            var l7 = new Perk() { Level = 7, Name = "暴击储蓄", Parent = stat_l, SubPerk = { 1, 17, 43, 50 }, Tips = "1.可以存储1个暴击\n2.可存2个暴击\n3.可存3个暴击，每存一个几率送一个\n4.可存4个暴击" };
            var l8 = new Perk() { Level = 8, Name = "死神的冲刺", Parent = stat_l, SubPerk = { 1, 19, 46 }, Tips = "1.VATS杀敌，有15%几率回满AP\n2.25%几率\n3.35%几率回满AP，并填充暴击条" };
            var l9 = new Perk() { Level = 9, Name = "幸运四叶草", Parent = stat_l, SubPerk = { 1, 13, 32, 48 }, Tips = "1.VATS每次命中，几率填充暴击条\n2.几率提高\n3.几率更高\n4.几率极高" };
            var l10 = new Perk() { Level = 10, Name = "跳弹", Parent = stat_l, SubPerk = { 1, 29, 50 }, Tips = "1.敌人的远程攻击几率反弹打死自己。血越低，几率越高\n2.几率提高\n3.敌人反弹死自己时，几率补充暴击条" };
            var pl = new List<Perk>() { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10 };

            _pklist = new List<List<Perk>>() { ps, pp, pe, pc, pi, pa, pl };
        }

        public int Level
        {
            get => _level;
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged("Level");
                    OnLevelChanged(new EventArgs());
                }
            }
        }
        private int _level = 1;

        public int OriginPoint
        {
            get => _originPoint;
            set
            {
                if (_originPoint != value)
                {
                    _originPoint = value;
                    if (_originPoint == 0 && ZGlobal.progress == ZProgress.Stat)
                    {
                        EventArgs e = new EventArgs();
                        OnInitStatOver(e);
                    }
                    OnPropertyChanged("OriginPoint");
                }
            }
        }
        private int _originPoint = Origin;
        public static int Origin = 21;

        public int Weight { get; set; }

        public event EventHandler InitStatOver;
        private void OnInitStatOver(EventArgs e)
        {
            InitStatOver?.Invoke(this, e);
        }

        public void PointReset()
        {
            foreach (var s in StatList)
                s.Point = 1;
            foreach (var pl in PkList)
                foreach (var p in pl)
                {
                    p.SubLevel = 0;                    
                }

            Origin = 21;    // reset extra point
            OriginPoint = Origin;

            Level = 1;
        }

        public event EventHandler LevelChanged;
        private void OnLevelChanged(EventArgs e)
        {
            LevelChanged?.Invoke(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
