using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class mapGenerator : MonoBehaviour
{
    public Road[] Roads;
    public List<Intersection> intersections;
    public List<Road> roads;
    public Intersection Intersection;
    public Road Road;
    //string path = "Assets/NewYorkCo.txt";
    // Start is called before the first frame update
    void Start()
    {
        string line;
        string[] subs;
        Application.targetFrameRate = 30;
        
        StreamReader sr = new StreamReader("Assets/NewYorkCo.txt");
        int V = int.Parse(sr.ReadLine());
        for (int i = 0; i < V; i++)
        {
            line = sr.ReadLine();
            subs = line.Split(',');
            int num = int.Parse(subs[0]);
            float x = float.Parse(subs[1])/100;
            float y = float.Parse(subs[2])/100;
            Vector3 pos = new Vector3(x, y, 0);
            intersections.Add(Instantiate(Intersection, pos, Quaternion.identity));
           
        }

        sr.Close();

        sr = new StreamReader("Assets/NewYorkLen.txt");
        line = sr.ReadLine();
        subs = line.Split(' ');
        int E = int.Parse(subs[1]);
        for (int i = 0; i < E; i++)
        {
            line = sr.ReadLine();
            subs = line.Split(' ');
            int s = int.Parse(subs[0]);
            int d = int.Parse(subs[1]);
            Vector3 pos = new Vector3(0,0,0);
            Road r = (Instantiate(Road, pos, Quaternion.identity));
            r.set(intersections[s], intersections[d]);
            roads.Add(r);
        }
    }

    // Update is called once per frame
}
