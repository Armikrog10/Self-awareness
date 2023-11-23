using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    int[] PointMap = new int[4];
    public GameObject Canvas, Point, CharacterPoint;
    public static Transform Target;
    public static GameObject[][] Points = new GameObject[4][];
    public static GameObject[] PointsBaz = new GameObject[2];
    public static bool[][][] Way = new bool[3][][];
    void Vivod()
    {
        GameObject PointStandart = new GameObject();
        for (int i = 0; i < 2; i++)
        {
            PointsBaz[i] = Instantiate(Point, Canvas.transform);
            switch (i)
            {
                case 0: PointsBaz[i].transform.position = new Vector2(170, 82);
                        Target = PointsBaz[i].transform; break;
                case 1: PointsBaz[i].transform.position = new Vector2(170, 498); break;
            }
            PointsBaz[i].GetComponent<Point>().Sloi[0] = i * 5;
        }
        for (int i = 3; i > -1; i--)
        {
            switch (MapBas.PointMap[i])
            {
                case 1: Points[i] = new GameObject[] {Instantiate(Point, Canvas.transform)}; 
                        Points[i][0].transform.position = new Vector2(150 + Random.Range(0, 41), 155 + (76 * i) + Random.Range(0, 21));
                        Points[i][0].GetComponent<Point>().Sloi[0] = i + 1;
                        Points[i][0].GetComponent<Point>().Sloi[1] = 1;
                        if (i == 0)
                        {
                            Points[i][0].GetComponent<Button>().interactable = true;
                        }
                        break;
                case 2: Points[i] = new GameObject[] {Instantiate(Point, Canvas.transform), Instantiate(Point, Canvas.transform)};
                        for (int j = 0; j < 2; j++)
                        {
                            Points[i][j].transform.position = new Vector2(108 + (82*j) + Random.Range(0, 41), 155 + (76 * i) + Random.Range(0, 21));
                            Points[i][j].GetComponent<Point>().Sloi[0] = i + 1;
                            Points[i][j].GetComponent<Point>().Sloi[1] = j + 1;
                            if (i == 0)
                            {
                                Points[i][j].GetComponent<Button>().interactable = true;
                            }
                        }
                        break;
                case 3: Points[i] = new GameObject[] {Instantiate(Point, Canvas.transform), Instantiate(Point, Canvas.transform), Instantiate(Point, Canvas.transform)};
                        for (int j = 0; j < 3; j++)
                        {
                            Points[i][j].transform.position = new Vector2(65 + (85 * j) + Random.Range(0, 41), 155 + (76 * i) + Random.Range(0, 21));
                            Points[i][j].GetComponent<Point>().Sloi[0] = i + 1;
                            Points[i][j].GetComponent<Point>().Sloi[1] = j + 1;
                            if (i == 0)
                            {
                                Points[i][j].GetComponent<Button>().interactable = true;
                            }
                        }
                        break;
            }
        }
    }
    void Bild()
    {
        for (int i = 0; i < 4; i++)
        {
            PointMap[i] = Random.Range(1, 4);
        }
        MapBas.PointMap = PointMap;
        for (int i = 3; i > 0; i--)
        {
            switch (MapBas.PointMap[i])
            {
                case 1:
                        switch (MapBas.PointMap[i - 1])
                        {
                            case 1: Way[i-1] = new bool[][] { new bool[] {true} }; break;
                            case 2: Way[i - 1] = new bool[][] { new bool[] { true }, new bool[] { true } }; break;
                            case 3: Way[i - 1] = new bool[][] { new bool[] { true }, new bool[] { true }, new bool[] { true } }; break;
                        }
                        break;
                case 2:
                        switch (MapBas.PointMap[i - 1])
                        {
                            case 1: Way[i - 1] = new bool[][] { new bool[] { true, true } }; break;
                            case 2:
                                int Vibor = Random.Range(0, 4);
                                switch (Vibor)
                                {
                                    case 0: Way[i - 1] = new bool[][] { new bool[] { true, false }, new bool[] { false, true } }; break;
                                    case 1: Way[i - 1] = new bool[][] { new bool[] { true, true }, new bool[] { false, true } }; break;
                                    case 2: Way[i - 1] = new bool[][] { new bool[] { true, false }, new bool[] { true, true } }; break;
                                    case 3: Way[i - 1] = new bool[][] { new bool[] { true, true }, new bool[] { true, true } }; break;
                                }
                                break;
                            case 3:
                                Vibor = Random.Range(0, 3);
                                switch (Vibor)
                                {
                                    case 0: Way[i - 1] = new bool[][] { new bool[] { true, false }, new bool[] { true, true }, new bool[] { false, true }}; break;
                                    case 1: Way[i - 1] = new bool[][] { new bool[] { true, false }, new bool[] { false, true }, new bool[] { false, true }}; break;
                                    case 2: Way[i - 1] = new bool[][] { new bool[] { true, false }, new bool[] { true, false }, new bool[] { false, true }}; break;
                                }
                                break;
                        }
                        break;
                case 3:
                        switch (MapBas.PointMap[i - 1])
                        {
                            case 1: Way[i - 1] = new bool[][] { new bool[] { true, true, true } }; break;
                            case 2:
                                int Vibor = Random.Range(0, 3);
                                switch (Vibor)
                                {
                                    case 0: Way[i - 1] = new bool[][] { new bool[] { true, false, false }, new bool[] { false, true, true } }; break;
                                    case 1: Way[i - 1] = new bool[][] { new bool[] { true, true, false }, new bool[] { false, false, true } }; break;
                                    case 2: Way[i - 1] = new bool[][] { new bool[] { true, true, false }, new bool[] { false, true, true } }; break;
                                }
                                break;
                            case 3:
                                bool[][] Digital_wellbeing = new bool[3][];
                                Vibor = Random.Range(0, 2);
                                switch (Vibor) 
                                {
                                    case 0: Digital_wellbeing[0] = new bool[] { true, false, false }; break;
                                    case 1: Digital_wellbeing[0] = new bool[] { true, true, false }; break;
                                }
                                Vibor = Random.Range(0, 4);
                                switch (Vibor)
                                {
                                    case 0: Digital_wellbeing[1] = new bool[] { true, true, true }; break;
                                    case 1: Digital_wellbeing[1] = new bool[] { true, true, false }; break;
                                    case 2: Digital_wellbeing[1] = new bool[] { false, true, true }; break;
                                    case 3: Digital_wellbeing[1] = new bool[] { false, true, false }; break;
                                }
                                Vibor = Random.Range(0, 2);
                                switch (Vibor)
                                {
                                    case 0: Digital_wellbeing[2] = new bool[] { false, false, true }; break;
                                    case 1: Digital_wellbeing[2] = new bool[] { false, true, true }; break;
                                }
                                Way[i - 1] = Digital_wellbeing;
                                break;
                        }
                        break;
            }
        }
    }
    void Start()
    {
        if (MapBas.gotovo < 4)
        {
            Bild();
        }
        Vivod();
        CharacterPoint = Instantiate(CharacterPoint, Canvas.transform);
        CharacterPoint.transform.position = Target.position;
        //Debug.Log(Player.gameClass);
    }

    // Update is called once per frame
    void Update()
    {
        if(CharacterPoint.transform.position != Target.position)
        {
            CharacterPoint.transform.position = Vector3.MoveTowards(CharacterPoint.transform.position, Target.position, 100 * Time.deltaTime);
        }
    }
}
