using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traveler : MonoBehaviour
{
    public Intersection Home, Goal;
    public float startTime, tripLength;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.enabled = false;
        gameObject.GetComponent<Camera>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float progress = (Time.time - startTime) * 1;
        float tripPercentage = progress / tripLength;
        transform.position = Vector3.Lerp(Home.transform.position, Goal.transform.position, tripPercentage);

    }

    public void beginTrip(Intersection _home, Intersection _goal)
    {
        Home = _home;
        Goal = _goal;

        startTime = Time.time;
        tripLength = Vector3.Distance(Home.transform.position, Goal.transform.position);
    }
}
