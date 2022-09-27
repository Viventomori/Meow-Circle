using UnityEngine;

public class Circle : MonoBehaviour
{
    private int slowly = 100;//slow down speed
    private Vector2 direction;
    private int randomScale = 0;

    private ScoreCounter scoreCounter;

    public void Initialize(int slowly, Vector2 direction, int randomScale)
    {
        this.slowly = slowly;
        this.direction = direction;
        this.randomScale = randomScale;
        scoreCounter = Camera.main.GetComponent<ScoreCounter>();
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * (randomScale * -1 + 6) / slowly);//move prefab clones
    }
    private void OnMouseDown()
    {
        scoreCounter.score += (randomScale * -1 + 6) * 10;// take points
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)//trigger to destroy object 
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
