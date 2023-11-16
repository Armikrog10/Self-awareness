using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametri : MonoBehaviour
{
    //имя, хп, сила, ловкость, харизма, самосознание
    public static Tuple<string, int, int, int, int, int, int>[] gameClass =
    {
        Tuple.Create("Инквизитор", 5, 5, 5, 8, 0, 7),
        Tuple.Create("Поэт", 4, 0, 6, 2, 8, 10),
        Tuple.Create("Бандит", 6, 8, 2, 2, 2, 10),
        Tuple.Create("Солдат", 8, 6, 0, 5, 1, 10),
        Tuple.Create("Кавалерист", 5, 5, 6, 0, 4, 10),
        Tuple.Create("Живой", 4, 4, 4, 4, 4, 11)
    };
}
