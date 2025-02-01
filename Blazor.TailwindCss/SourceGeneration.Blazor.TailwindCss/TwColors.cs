using System.Collections.Frozen;

namespace SourceGeneration.Blazor.TailwindCss;

internal static class TwColors
{
    private static FrozenDictionary<string, string>? _colors;

    private static FrozenDictionary<string, string> Colors
    {
        get
        {
            if (_colors == null)
            {
                Dictionary<string, string> dic = [];
                foreach (var field in typeof(TwColors).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
                {
                    dic.Add(field.Name.Replace('_', '-'), (string)field.GetValue(null)!);
                }
                _colors = dic.ToFrozenDictionary();
            }
            return _colors;
        }
    }

    public static bool TryGetColorStyle(string name, out string? color)
    {
        color = null;
        var index = name.IndexOf('/');
        if (index > 0)
        {
            if (!byte.TryParse(name.Substring(index + 1), out var b))
                return false;
            if (b > 100)
                return false;

            name = name.Substring(0, index);
            if (!Colors.TryGetValue(name.ToString(), out var c))
                return false;

            if (!c.EndsWith(")"))
                return false;
            
            color = $"rgba({c.Substring(4, c.Length - 5)},{b / 100.0})";
            return true;
        }
        else
        {
            return Colors.TryGetValue(name.ToString(), out color);
        }
    }

    public static readonly string transparent = "transparent";
    public static readonly string black = "rgb(0,0,0)";
    public static readonly string white = "rgb(255,255,255)";
    public static readonly string slate_50 = "rgb(248,250,252)";
    public static readonly string slate_100 = "rgb(241,245,249)";
    public static readonly string slate_200 = "rgb(226,232,240)";
    public static readonly string slate_300 = "rgb(203,213,225)";
    public static readonly string slate_400 = "rgb(148,163,184)";
    public static readonly string slate_500 = "rgb(100,116,139)";
    public static readonly string slate_600 = "rgb(71,85,105)";
    public static readonly string slate_700 = "rgb(51,65,85)";
    public static readonly string slate_800 = "rgb(30,41,59)";
    public static readonly string slate_900 = "rgb(15,23,42)";
    public static readonly string slate_950 = "rgb(2,6,23)";
    public static readonly string gray_50 = "rgb(249,250,251)";
    public static readonly string gray_100 = "rgb(243,244,246)";
    public static readonly string gray_200 = "rgb(229,231,235)";
    public static readonly string gray_300 = "rgb(209,213,219)";
    public static readonly string gray_400 = "rgb(156,163,175)";
    public static readonly string gray_500 = "rgb(107,114,128)";
    public static readonly string gray_600 = "rgb(75,85,99)";
    public static readonly string gray_700 = "rgb(55,65,81)";
    public static readonly string gray_800 = "rgb(31,41,55)";
    public static readonly string gray_900 = "rgb(17,24,39)";
    public static readonly string gray_950 = "rgb(3,7,18)";
    public static readonly string zinc_50 = "rgb(250,250,250)";
    public static readonly string zinc_100 = "rgb(244,244,245)";
    public static readonly string zinc_200 = "rgb(228,228,231)";
    public static readonly string zinc_300 = "rgb(212,212,216)";
    public static readonly string zinc_400 = "rgb(161,161,170)";
    public static readonly string zinc_500 = "rgb(113,113,122)";
    public static readonly string zinc_600 = "rgb(82,82,91)";
    public static readonly string zinc_700 = "rgb(63,63,70)";
    public static readonly string zinc_800 = "rgb(39,39,42)";
    public static readonly string zinc_900 = "rgb(24,24,27)";
    public static readonly string zinc_950 = "rgb(9,9,11)";
    public static readonly string neutral_50 = "rgb(250,250,250)";
    public static readonly string neutral_100 = "rgb(245,245,245)";
    public static readonly string neutral_200 = "rgb(229,229,229)";
    public static readonly string neutral_300 = "rgb(212,212,212)";
    public static readonly string neutral_400 = "rgb(163,163,163)";
    public static readonly string neutral_500 = "rgb(115,115,115)";
    public static readonly string neutral_600 = "rgb(82,82,82)";
    public static readonly string neutral_700 = "rgb(64,64,64)";
    public static readonly string neutral_800 = "rgb(38,38,38)";
    public static readonly string neutral_900 = "rgb(23,23,23)";
    public static readonly string neutral_950 = "rgb(10,10,10)";
    public static readonly string stone_50 = "rgb(250,250,249)";
    public static readonly string stone_100 = "rgb(245,245,244)";
    public static readonly string stone_200 = "rgb(231,229,228)";
    public static readonly string stone_300 = "rgb(214,211,209)";
    public static readonly string stone_400 = "rgb(168,162,158)";
    public static readonly string stone_500 = "rgb(120,113,108)";
    public static readonly string stone_600 = "rgb(87,83,78)";
    public static readonly string stone_700 = "rgb(68,64,60)";
    public static readonly string stone_800 = "rgb(41,37,36)";
    public static readonly string stone_900 = "rgb(28,25,23)";
    public static readonly string stone_950 = "rgb(12,10,9)";
    public static readonly string red_50 = "rgb(254,242,242)";
    public static readonly string red_100 = "rgb(254,226,226)";
    public static readonly string red_200 = "rgb(254,202,202)";
    public static readonly string red_300 = "rgb(252,165,165)";
    public static readonly string red_400 = "rgb(248,113,113)";
    public static readonly string red_500 = "rgb(239,68,68)";
    public static readonly string red_600 = "rgb(220,38,38)";
    public static readonly string red_700 = "rgb(185,28,28)";
    public static readonly string red_800 = "rgb(153,27,27)";
    public static readonly string red_900 = "rgb(127,29,29)";
    public static readonly string red_950 = "rgb(69,10,10)";
    public static readonly string orange_50 = "rgb(255,247,237)";
    public static readonly string orange_100 = "rgb(255,237,213)";
    public static readonly string orange_200 = "rgb(254,215,170)";
    public static readonly string orange_300 = "rgb(253,186,116)";
    public static readonly string orange_400 = "rgb(251,146,60)";
    public static readonly string orange_500 = "rgb(249,115,22)";
    public static readonly string orange_600 = "rgb(234,88,12)";
    public static readonly string orange_700 = "rgb(194,65,12)";
    public static readonly string orange_800 = "rgb(154,52,18)";
    public static readonly string orange_900 = "rgb(124,45,18)";
    public static readonly string orange_950 = "rgb(67,20,7)";
    public static readonly string amber_50 = "rgb(255,251,235)";
    public static readonly string amber_100 = "rgb(254,243,199)";
    public static readonly string amber_200 = "rgb(253,230,138)";
    public static readonly string amber_300 = "rgb(252,211,77)";
    public static readonly string amber_400 = "rgb(251,191,36)";
    public static readonly string amber_500 = "rgb(245,158,11)";
    public static readonly string amber_600 = "rgb(217,119,6)";
    public static readonly string amber_700 = "rgb(180,83,9)";
    public static readonly string amber_800 = "rgb(146,64,14)";
    public static readonly string amber_900 = "rgb(120,53,15)";
    public static readonly string amber_950 = "rgb(69,26,3)";
    public static readonly string yellow_50 = "rgb(254,252,232)";
    public static readonly string yellow_100 = "rgb(254,249,195)";
    public static readonly string yellow_200 = "rgb(254,240,138)";
    public static readonly string yellow_300 = "rgb(253,224,71)";
    public static readonly string yellow_400 = "rgb(250,204,21)";
    public static readonly string yellow_500 = "rgb(234,179,8)";
    public static readonly string yellow_600 = "rgb(202,138,4)";
    public static readonly string yellow_700 = "rgb(161,98,7)";
    public static readonly string yellow_800 = "rgb(133,77,14)";
    public static readonly string yellow_900 = "rgb(113,63,18)";
    public static readonly string yellow_950 = "rgb(66,32,6)";
    public static readonly string lime_50 = "rgb(247,254,231)";
    public static readonly string lime_100 = "rgb(236,252,203)";
    public static readonly string lime_200 = "rgb(217,249,157)";
    public static readonly string lime_300 = "rgb(190,242,100)";
    public static readonly string lime_400 = "rgb(163,230,53)";
    public static readonly string lime_500 = "rgb(132,204,22)";
    public static readonly string lime_600 = "rgb(101,163,13)";
    public static readonly string lime_700 = "rgb(77,124,15)";
    public static readonly string lime_800 = "rgb(63,98,18)";
    public static readonly string lime_900 = "rgb(54,83,20)";
    public static readonly string lime_950 = "rgb(26,46,5)";
    public static readonly string green_50 = "rgb(240,253,244)";
    public static readonly string green_100 = "rgb(220,252,231)";
    public static readonly string green_200 = "rgb(187,247,208)";
    public static readonly string green_300 = "rgb(134,239,172)";
    public static readonly string green_400 = "rgb(74,222,128)";
    public static readonly string green_500 = "rgb(34,197,94)";
    public static readonly string green_600 = "rgb(22,163,74)";
    public static readonly string green_700 = "rgb(21,128,61)";
    public static readonly string green_800 = "rgb(22,101,52)";
    public static readonly string green_900 = "rgb(20,83,45)";
    public static readonly string green_950 = "rgb(5,46,22)";
    public static readonly string emerald_50 = "rgb(236,253,245)";
    public static readonly string emerald_100 = "rgb(209,250,229)";
    public static readonly string emerald_200 = "rgb(167,243,208)";
    public static readonly string emerald_300 = "rgb(110,231,183)";
    public static readonly string emerald_400 = "rgb(52,211,153)";
    public static readonly string emerald_500 = "rgb(16,185,129)";
    public static readonly string emerald_600 = "rgb(5,150,105)";
    public static readonly string emerald_700 = "rgb(4,120,87)";
    public static readonly string emerald_800 = "rgb(6,95,70)";
    public static readonly string emerald_900 = "rgb(6,78,59)";
    public static readonly string emerald_950 = "rgb(2,44,34)";
    public static readonly string teal_50 = "rgb(240,253,250)";
    public static readonly string teal_100 = "rgb(204,251,241)";
    public static readonly string teal_200 = "rgb(153,246,228)";
    public static readonly string teal_300 = "rgb(94,234,212)";
    public static readonly string teal_400 = "rgb(45,212,191)";
    public static readonly string teal_500 = "rgb(20,184,166)";
    public static readonly string teal_600 = "rgb(13,148,136)";
    public static readonly string teal_700 = "rgb(15,118,110)";
    public static readonly string teal_800 = "rgb(17,94,89)";
    public static readonly string teal_900 = "rgb(19,78,74)";
    public static readonly string teal_950 = "rgb(4,47,46)";
    public static readonly string cyan_50 = "rgb(236,254,255)";
    public static readonly string cyan_100 = "rgb(207,250,254)";
    public static readonly string cyan_200 = "rgb(165,243,252)";
    public static readonly string cyan_300 = "rgb(103,232,249)";
    public static readonly string cyan_400 = "rgb(34,211,238)";
    public static readonly string cyan_500 = "rgb(6,182,212)";
    public static readonly string cyan_600 = "rgb(8,145,178)";
    public static readonly string cyan_700 = "rgb(14,116,144)";
    public static readonly string cyan_800 = "rgb(21,94,117)";
    public static readonly string cyan_900 = "rgb(22,78,99)";
    public static readonly string cyan_950 = "rgb(8,51,68)";
    public static readonly string sky_50 = "rgb(240,249,255)";
    public static readonly string sky_100 = "rgb(224,242,254)";
    public static readonly string sky_200 = "rgb(186,230,253)";
    public static readonly string sky_300 = "rgb(125,211,252)";
    public static readonly string sky_400 = "rgb(56,189,248)";
    public static readonly string sky_500 = "rgb(14,165,233)";
    public static readonly string sky_600 = "rgb(2,132,199)";
    public static readonly string sky_700 = "rgb(3,105,161)";
    public static readonly string sky_800 = "rgb(7,89,133)";
    public static readonly string sky_900 = "rgb(12,74,110)";
    public static readonly string sky_950 = "rgb(8,47,73)";
    public static readonly string blue_50 = "rgb(239,246,255)";
    public static readonly string blue_100 = "rgb(219,234,254)";
    public static readonly string blue_200 = "rgb(191,219,254)";
    public static readonly string blue_300 = "rgb(147,197,253)";
    public static readonly string blue_400 = "rgb(96,165,250)";
    public static readonly string blue_500 = "rgb(59,130,246)";
    public static readonly string blue_600 = "rgb(37,99,235)";
    public static readonly string blue_700 = "rgb(29,78,216)";
    public static readonly string blue_800 = "rgb(30,64,175)";
    public static readonly string blue_900 = "rgb(30,58,138)";
    public static readonly string blue_950 = "rgb(23,37,84)";
    public static readonly string indigo_50 = "rgb(238,242,255)";
    public static readonly string indigo_100 = "rgb(224,231,255)";
    public static readonly string indigo_200 = "rgb(199,210,254)";
    public static readonly string indigo_300 = "rgb(165,180,252)";
    public static readonly string indigo_400 = "rgb(129,140,248)";
    public static readonly string indigo_500 = "rgb(99,102,241)";
    public static readonly string indigo_600 = "rgb(79,70,229)";
    public static readonly string indigo_700 = "rgb(67,56,202)";
    public static readonly string indigo_800 = "rgb(55,48,163)";
    public static readonly string indigo_900 = "rgb(49,46,129)";
    public static readonly string indigo_950 = "rgb(30,27,75)";
    public static readonly string violet_50 = "rgb(245,243,255)";
    public static readonly string violet_100 = "rgb(237,233,254)";
    public static readonly string violet_200 = "rgb(221,214,254)";
    public static readonly string violet_300 = "rgb(196,181,253)";
    public static readonly string violet_400 = "rgb(167,139,250)";
    public static readonly string violet_500 = "rgb(139,92,246)";
    public static readonly string violet_600 = "rgb(124,58,237)";
    public static readonly string violet_700 = "rgb(109,40,217)";
    public static readonly string violet_800 = "rgb(91,33,182)";
    public static readonly string violet_900 = "rgb(76,29,149)";
    public static readonly string violet_950 = "rgb(46,16,101)";
    public static readonly string purple_50 = "rgb(250,245,255)";
    public static readonly string purple_100 = "rgb(243,232,255)";
    public static readonly string purple_200 = "rgb(233,213,255)";
    public static readonly string purple_300 = "rgb(216,180,254)";
    public static readonly string purple_400 = "rgb(192,132,252)";
    public static readonly string purple_500 = "rgb(168,85,247)";
    public static readonly string purple_600 = "rgb(147,51,234)";
    public static readonly string purple_700 = "rgb(126,34,206)";
    public static readonly string purple_800 = "rgb(107,33,168)";
    public static readonly string purple_900 = "rgb(88,28,135)";
    public static readonly string purple_950 = "rgb(59,7,100)";
    public static readonly string fuchsia_50 = "rgb(253,244,255)";
    public static readonly string fuchsia_100 = "rgb(250,232,255)";
    public static readonly string fuchsia_200 = "rgb(245,208,254)";
    public static readonly string fuchsia_300 = "rgb(240,171,252)";
    public static readonly string fuchsia_400 = "rgb(232,121,249)";
    public static readonly string fuchsia_500 = "rgb(217,70,239)";
    public static readonly string fuchsia_600 = "rgb(192,38,211)";
    public static readonly string fuchsia_700 = "rgb(162,28,175)";
    public static readonly string fuchsia_800 = "rgb(134,25,143)";
    public static readonly string fuchsia_900 = "rgb(112,26,117)";
    public static readonly string fuchsia_950 = "rgb(74,4,78)";
    public static readonly string pink_50 = "rgb(253,242,248)";
    public static readonly string pink_100 = "rgb(252,231,243)";
    public static readonly string pink_200 = "rgb(251,207,232)";
    public static readonly string pink_300 = "rgb(249,168,212)";
    public static readonly string pink_400 = "rgb(244,114,182)";
    public static readonly string pink_500 = "rgb(236,72,153)";
    public static readonly string pink_600 = "rgb(219,39,119)";
    public static readonly string pink_700 = "rgb(190,24,93)";
    public static readonly string pink_800 = "rgb(157,23,77)";
    public static readonly string pink_900 = "rgb(131,24,67)";
    public static readonly string pink_950 = "rgb(80,7,36)";
    public static readonly string rose_50 = "rgb(255,241,242)";
    public static readonly string rose_100 = "rgb(255,228,230)";
    public static readonly string rose_200 = "rgb(254,205,211)";
    public static readonly string rose_300 = "rgb(253,164,175)";
    public static readonly string rose_400 = "rgb(251,113,133)";
    public static readonly string rose_500 = "rgb(244,63,94)";
    public static readonly string rose_600 = "rgb(225,29,72)";
    public static readonly string rose_700 = "rgb(190,18,60)";
    public static readonly string rose_800 = "rgb(159,18,57)";
    public static readonly string rose_900 = "rgb(136,19,55)";
    public static readonly string rose_950 = "rgb(76,5,25)";
}
