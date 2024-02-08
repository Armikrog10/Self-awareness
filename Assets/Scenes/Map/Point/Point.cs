using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public LineRenderer line;
    public int[] Sloi = new int[2];
    public int Dostyp = 0;
    public void Prioritet()
    {
        if (Sloi[0] < 4)
        {
            for (int i = 0; i < MapBas.PointMap[Sloi[0] - 1]; i++)
            {
                Map.Points[Sloi[0] - 1][i].GetComponent<Button>().interactable = false;
            }
            for (int i = 0; i < MapBas.PointMap[Sloi[0]]; i++)
            {
                if (Map.Way[Sloi[0] - 1][Sloi[1] - 1][i])
                {
                    Map.Points[Sloi[0]][i].GetComponent<Button>().interactable = true;
                }
            }
        }
        else if(Sloi[0] < 5)
        {
            for (int i = 0; i < MapBas.PointMap[Sloi[0] - 1]; i++)
            {
                Map.Points[Sloi[0] - 1][i].GetComponent<Button>().interactable = false;
            }
            Map.PointsBaz[1].GetComponent<Button>().interactable = true;
        }
        Map.Target = transform.position;
    }
    void Start()
    {
        line = GetComponent<LineRenderer>();
        if (Sloi[0] < 4 && Sloi[0] > 0)
        {
            for(int i = 0; i < MapBas.PointMap[Sloi[0]]; i++)
            {
                if (Map.Way[Sloi[0]-1][Sloi[1] - 1][i])
                {
                    Dostyp++;
                }
            }
            line.positionCount = Dostyp*2;
            int Verno = 0;
            for (int i = 0; i < MapBas.PointMap[Sloi[0]]; i++)
            {
                if (Map.Way[Sloi[0]-1][Sloi[1] - 1][i])
                {
                    line.SetPosition(Verno, transform.position);
                    line.SetPosition(1 + Verno, Map.Points[Sloi[0]][i].transform.position);
                    Verno += 2;
                }
            }
        }
        if (Sloi[0] == 0)
        {
            line.positionCount = Map.Points[Sloi[0]].Length * 2;
            for (int i = 0; i < Map.Points[Sloi[0]].Length; i++)
            {
                line.SetPosition(i * 2, transform.position);
                line.SetPosition(1 + (i * 2), Map.Points[Sloi[0]][i].transform.position);
            }
        }
        if (Sloi[0] == 4)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, new Vector2(170, 498));
        }
    }
}
