using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public static Tuple<string, int, int, int, int>[] weapons =
    {
        Tuple.Create("Мосинка", 0, 5, 35, 0),
        Tuple.Create("СВТ", 0, 10, 30, 1),
        Tuple.Create("Берданка", 0, 1, 50, 0),
        Tuple.Create("СКС", 0, 10, 30, 0),
        Tuple.Create("Мушкетон", 0, 1, 60, -2)
    };
    //перечень предметов
    public static string[] predmet =
    {
        "Аспирин",
        "Стимулятор",
        "Пакет крови",
        "Аптечка"
    };
}
