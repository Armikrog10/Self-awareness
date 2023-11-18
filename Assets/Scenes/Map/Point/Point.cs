using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public Image[] Way;
    public int Sloi;
    void Start()
    {
        for (int i = 0; i < Way.Length; i++)
        {
            Way[i].enabled = false;
        }
        if (Sloi < 4 && Sloi > 0)
        {
            switch (MapBas.PointMap[Sloi - 1])
            {
                case 1:
                    switch (MapBas.PointMap[Sloi])
                    {
                        case 1: Way[2].enabled = true; break;
                        case 2:
                            Way[1].enabled = true;
                            Way[3].enabled = true; break;
                        case 3:
                            Way[0].enabled = true;
                            Way[2].enabled = true;
                            Way[4].enabled = true; break;
                    }
                    break;
                case 2:
                    switch (MapBas.PointMap[Sloi])
                    {
                        case 1: Way[2].enabled = true;
                                Way[5].enabled = true; break;
                        case 2:
                            int Vozmojnost = Random.Range(1, 5);
                            switch(Vozmojnost)
                            {
                                case 1: Way[3].enabled = true; break;
                                case 2: Way[4].enabled = true; break;
                                case 3: Way[3].enabled = true;
                                        Way[4].enabled = true; break;
                                default: break;
                            }
                            Way[1].enabled = true;
                            Way[6].enabled = true; break;
                        case 3:
                            Vozmojnost = Random.Range(1, 4);
                            switch (Vozmojnost)
                            {
                                case 1: Way[2].enabled = true; break;
                                case 2: Way[5].enabled = true; break;
                                case 3:
                                    Way[2].enabled = true;
                                    Way[5].enabled = true; break;
                            }
                            Way[0].enabled = true;
                            Way[7].enabled = true; break;
                    }
                    break;
                case 3:
                    switch (MapBas.PointMap[Sloi])
                    {
                        case 1:
                            Way[2].enabled = true;
                            Way[5].enabled = true;
                            Way[8].enabled = true; break;
                        case 2:
                            int Vozmojnost = Random.Range(1, 4);
                            switch (Vozmojnost)
                            {
                                case 1: Way[4].enabled = true; break;
                                case 2: Way[6].enabled = true; break;
                                case 3:
                                    Way[4].enabled = true;
                                    Way[6].enabled = true; break;
                            }
                            Way[1].enabled = true;
                            Way[9].enabled = true; break;
                        case 3:
                            Vozmojnost = Random.Range(1, 3);
                            if (Vozmojnost == 1)
                            {
                                Way[2].enabled = true;
                            }
                            Vozmojnost = Random.Range(1, 3);
                            if (Vozmojnost == 1)
                            {
                                Way[8].enabled = true;
                            }
                            Vozmojnost = Random.Range(1, 5);
                            switch (Vozmojnost)
                            {
                                case 1: Way[3].enabled = true; break;
                                case 2: Way[7].enabled = true; break;
                                case 3:
                                    Way[3].enabled = true;
                                    Way[7].enabled = true; break;
                                default: break;

                            }
                            Way[0].enabled = true;
                            Way[5].enabled = true;
                            Way[10].enabled = true; break;
                    }
                    break;
            }
        }
        if (Sloi == 0)
        {
            switch (MapBas.PointMap[0])
            {
                case 1: Way[2].enabled = true; break;
                case 2: Way[1].enabled = true;
                        Way[3].enabled = true; break;
                case 3:
                        Way[0].enabled = true;
                        Way[2].enabled = true;
                        Way[4].enabled = true; break;
            }
        }
        if (Sloi == 5)
        {
            Debug.Log("Djdf");
            switch (MapBas.PointMap[3])
            {
                case 1: Way[7].enabled = true; break;
                case 2:
                    Way[6].enabled = true;
                    Way[8].enabled = true; break;
                case 3:
                    Way[5].enabled = true;
                    Way[7].enabled = true;
                    Way[9].enabled = true; break;
            }
        }
    }
}
