using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int gameClass, HpStat, StrStat, DexStat, DurStat, CharStat, Self;
    public static string[] inventar = new string[5];
    public static int Hp,HpMax;
    public static void Add_Inventar(List<string> predmeti)
    {
        List<int> pusto = new List<int>();
        for(int i = 0; i < 5; i++)
        {
            if (inventar[i] == null)
            {
                pusto.Add(i);
            }
        }
        for(int i = 0;i < pusto.Count; i++)
        {
            if (i < predmeti.Count)
            {
                inventar[pusto[i]] = predmeti[i];
            }
        }
    }
    public static int Proverka_Ydachi(int[] varianti)
    {
        for(int i = 0;i<varianti.Length;i++) 
        {
            int Rand = Random.Range(0, 100);
            if(Rand <= varianti[i])
            {
                return (i);
            }
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
