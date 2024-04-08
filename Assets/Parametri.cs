using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public static Tuple<string, int[], int, int, int>[] weapons =
    {
        Tuple.Create("�������", new int[]{0,0,0}, 5, 35, 0),
        Tuple.Create("���",new int[]{0,1,1}, 10, 30, 1),
        Tuple.Create("��������", new int[]{0,0,2}, 1, 50, 0),
        Tuple.Create("���", new int[]{0,1,1}, 10, 30, 0),
        Tuple.Create("��������", new int[]{0,0,2}, 1, 60, -2)
    };
    //�������� ���������
    public static string[] predmet =
    {
        "�������",
        "����������",
        "����� �����",
        "�������",
        "����",
        "�������",
        "���",
        "��������",
        "���",
        "��������"
    };
    //�������� �����
    public static string[] yslygi =
    {
        "�������"
    };
    //���������� �����
    public static void Actions(string action)
    {
        switch(action)
        {
            case "�������":
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
    //�������� ������
    public static Tuple<string, int>[] enemy_par =
    {
        Tuple.Create("��������� ���������", 100)
    };
    //�������� ������
    public static string[] enemy =
    {
        "��������� ���������"
    };
    //����� ���������� ��������
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
