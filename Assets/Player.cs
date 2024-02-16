using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int gameClass, HpStat, StrStat, DexStat, DurStat, CharStat, Self;
    public static string[] inventar = new string[5];
    public static int Hp,HpMax;
    public static string[] nahodki = new string[5];
    public static string yslyga = null;
    public static int Proverka_Ydachi(int[] varianti)
    {
        int procent = 100;
        for(int i = 0;i<varianti.Length;i++) 
        {
            int Rand = Random.Range(0, procent);
            if(Rand <= varianti[i])
            {
                return (i);
            }
            procent -= varianti[i];
        }
        return 0;
    }
    public static int Proverka_Harizmi(int slojnost)
    {
        int h = Random.Range(0, 100);
        if((h+(CharStat-10)*3)-slojnost >= 50)
        {
            return (1);
        }
        else
        {
            return (0);
        }
    }
}
