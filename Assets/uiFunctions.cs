using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiFunctions : MonoBehaviour
{
    public traveler traveler;
    public mapGenerator mg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newTraveler(int start, int end)
    {
        traveler t = Instantiate(traveler, mg.intersections[start].transform);
        t.beginTrip(mg.intersections[start], mg.intersections[end]);
    }
}
