using System.Collections;
using UnityEngine;

public class CircleGenerator : MonoBehaviour
{
    public static int slowly = 100;//slow down speed
    public Vector2 direction;
    public float minTimeDiff; // between spawn
    public float maxTimeDiff; // between spawn
    public Circle objectToSpawn; // object what will be spawned
    [HideInInspector] public int randomScale = 0;
    private int minCircleScale = 1; 
    private int maxCircleScale = 5; 
    private float randomSpace;//value where was spawn (x)
    private Vector2 spawn;// value where was spawn (x,y)

    private void Start()
    {
        StartCoroutine(CreateObjectsAtRandom());
    }

    private IEnumerator CreateObjectsAtRandom()//generation circle
    {
        while (true)
        { 
            randomScale = Random.Range(minCircleScale, maxCircleScale);//random size
            randomSpace = Random.Range(-6f, 6f); //space (axis x) where be spawn.
            spawn = new Vector2(randomSpace, transform.position.y);
            Circle circleInstance = Instantiate(objectToSpawn, spawn, Quaternion.identity);//create cicle
            circleInstance.Initialize(slowly, direction, randomScale);
            circleInstance.GetComponent<Renderer>().material.color = Random.ColorHSV();//take random color
            circleInstance.transform.localScale = Vector2.one * randomScale;//tale random size
            yield return new WaitForSeconds(Random.Range(minTimeDiff, maxTimeDiff)); // wait for a random time before spawning the next object.
        }
    }
}
