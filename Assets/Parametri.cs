using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parametri : MonoBehaviour
{
    //имя, хп, сила, ловкость, стойкость, харизма, самосознание
    public static Tuple<string, int, int, int, int, int, int>[] gameClass =
    {
        Tuple.Create("Инквизитор", 5, 5, 5, 8, 0, 7),
        Tuple.Create("Поэт", 4, 0, 6, 2, 8, 10),
        Tuple.Create("Бандит", 6, 8, 2, 2, 2, 10),
        Tuple.Create("Солдат", 8, 6, 0, 5, 1, 10),
        Tuple.Create("Кавалерист", 5, 5, 6, 0, 4, 10),
        Tuple.Create("Живой", 4, 4, 4, 4, 4, 11)
    };
    //описание навыков классов
    public static string[] ClassSkillDes =
    {
        "Встать! - при смерти потрптьте 3 единицы самосознание что-бы полностью восстановить здоровье\n" +
            "Штык-молодец - увеличивает урон винторкой в рукопашном бою в 2 раза",
        "",
        "",
        "",
        "",
        ""
    };
    //перечень оружия
    public static Tuple<string, int[], int, int, int>[] weapons =
    {
        Tuple.Create("Мосинка", new int[]{0,0,0}, 5, 35, 0),
        Tuple.Create("СВТ",new int[]{0,1,1}, 10, 30, 1),
        Tuple.Create("Берданка", new int[]{0,0,2}, 1, 50, 0),
        Tuple.Create("СКС", new int[]{0,1,1}, 10, 30, 0),
        Tuple.Create("Мушкетон", new int[]{0,0,2}, 1, 60, -2)
    };
    //перечень предметов
    public static string[] predmet =
    {
        "Аспирин",
        "Стимулятор",
        "Пакет крови",
        "Аптечка",
        "Штык",
        "Мосинка",
        "СВТ",
        "Берданка",
        "СКС",
        "Мушкетон"
    };
    //перечень услуг
    public static string[] yslygi =
    {
        "Лечение"
    };
    //выполнение услуг
    public static void Actions(string action)
    {
        switch(action)
        {
            case "Лечение":
                if(Player.Hp + 50 <= Player.HpMax)
                {
                    Player.Hp += 50;
                }
                else
                {
                    Player.Hp = Player.HpMax;
                }
            break;
        }
    }
    //описание врагов
    public static Tuple<string, int>[] enemy_par =
    {
        Tuple.Create("Полоумная медсестра", 100)
    };
    //перечень врагов
    public static string[] enemy =
    {
        "Полоумная медсестра"
    };
    //поиск параметров предмета
    public static int[] Parametr(string predmet,int parametr)
    {
        switch(Array.IndexOf(Parametri.predmet, predmet))
        {
            case > 3 and <= 8:
                for (int i = 0; i<weapons.Length;i++)
                {
                    if (weapons[i].Item1 == predmet)
                    {
                        switch(parametr)
                        {
                            case 1: return (weapons[i].Item2);
                            case 2: return (new int[]{weapons[i].Item3});
                            case 3: return (new int[]{weapons[i].Item4});
                            case 4: return (new int[]{weapons[i].Item5});
                        }
                    }
                }
            break;
        }
        return new int[]{};
    }
}
