using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    int[] PointMap = new int[4];
    public GameObject Canvas, Point0, Point1, Point2, Point3;
    void Vivod()
    {
        GameObject Point = new GameObject();
        for (int i = 0; i < 2; i++)
        {
            Point = Instantiate(Point0, Canvas.transform);
            switch (i)
            {
                case 0: Point.transform.position = new Vector2(170, 82); break;
                case 1: Point.transform.position = new Vector2(170, 498); break;
            }
            Point.GetComponent<Point>().Sloi = i * 5;
        }
        for (int i = 0; i < 4; i++)
        {
            switch (MapBas.PointMap[i])
            {
                case 1: Point = Instantiate(Point1, Canvas.transform); break;
                case 2: Point = Instantiate(Point2, Canvas.transform); break;
                case 3: Point = Instantiate(Point3, Canvas.transform); break;
            }
            Point.transform.position = new Vector2(170, 175 + (76 * i));
            Point.GetComponent<Point>().Sloi = i + 1;
        }
    }
    void Bild()
    {
        for (int i = 0; i < 4; i++)
        {
            PointMap[i] = Random.Range(1, 4);
        }
        MapBas.PointMap = PointMap;
    }
    void Start()
    {
        if (MapBas.gotovo < 4)
        {
            Bild();
        }
        Vivod();
        //Debug.Log(Player.gameClass);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
