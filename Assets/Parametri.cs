using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametri : MonoBehaviour
{
    //���, ��, ����, ��������, ���������, �������, ������������
    public static Tuple<string, int, int, int, int, int, int>[] gameClass =
    {
        Tuple.Create("����������", 5, 5, 5, 8, 0, 7),
        Tuple.Create("����", 4, 0, 6, 2, 8, 10),
        Tuple.Create("������", 6, 8, 2, 2, 2, 10),
        Tuple.Create("������", 8, 6, 0, 5, 1, 10),
        Tuple.Create("����������", 5, 5, 6, 0, 4, 10),
        Tuple.Create("�����", 4, 4, 4, 4, 4, 11)
    };
    //�������� ������� �������
    public static string[] ClassSkillDes =
    {
        "������! - ��� ������ ��������� 3 ������� ������������ ���-�� ��������� ������������ ��������\n" +
            "����-������� - ����������� ���� ��������� � ���������� ��� � 2 ����",
        "",
        "",
        "",
        "",
        ""
    };
    //�������� ������
    public static Tuple<string, int, int, int, int>[] weapons =
    {
        Tuple.Create("�������", 0, 5, 35, 0),
        Tuple.Create("���", 0, 10, 30, 1),
        Tuple.Create("��������", 0, 1, 50, 0),
        Tuple.Create("���", 0, 10, 30, 0),
        Tuple.Create("��������", 0, 1, 60, -2)
    };
    //�������� ���������
    public static string[] predmet =
    {
        "�������",
        "����������",
        "����� �����",
        "�������"
    };
}
