using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class mapGeneration : MonoBehaviour
{
    public List<RoadSO> roadList;
    public List<IntersectionSO> intersectionList;
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
            float xCO = float.Parse(subs[1]) / 100;
            float yCO = float.Parse(subs[2]) / 100;

            IntersectionSO iSO = ScriptableObject.CreateInstance<IntersectionSO>();
            iSO.x = xCO; iSO.y = yCO;
            intersectionList.Add(iSO);
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
            float distane = float.Parse(subs[2]);
            RoadSO rSO = ScriptableObject.CreateInstance<RoadSO>();
            rSO.dest = d; rSO.src = s; rSO.speedLimit = 30; rSO.distance = distane;

            roadList.Add(rSO);
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
