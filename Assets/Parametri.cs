using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametri : MonoBehaviour
{
    //���, ��, ����, ��������, �������, ������������
    public static Tuple<string, int, int, int, int, int, int>[] gameClass =
    {
        Tuple.Create("����������", 5, 5, 5, 8, 0, 7),
        Tuple.Create("����", 4, 0, 6, 2, 8, 10),
        Tuple.Create("������", 6, 8, 2, 2, 2, 10),
        Tuple.Create("������", 8, 6, 0, 5, 1, 10),
        Tuple.Create("����������", 5, 5, 6, 0, 4, 10),
        Tuple.Create("�����", 4, 4, 4, 4, 4, 11)
    };
}
