using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidPrefab;

    [SerializeField]
    private float splitSpeed = 2;

    private int splitDepth = 0;

    public void Split()
    {
        var asteroidPrefab1 = Instantiate(asteroidPrefab);
        var asteroidPrefab2 = Instantiate(asteroidPrefab);

        asteroidPrefab1.transform.position = transform.position;
        asteroidPrefab2.transform.position = transform.position;

        asteroidPrefab1.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle * splitSpeed;
        asteroidPrefab2.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle * splitSpeed;

        asteroidPrefab1.GetComponent<Asteroid>().setSize(splitDepth + 1);
        asteroidPrefab2.GetComponent<Asteroid>().setSize(splitDepth + 1);

        Destroy(gameObject);
    }

    public void setSize(int depth)
    {
        this.splitDepth = depth;

        if (splitDepth == 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (splitDepth == 1)
        {
            transform.localScale = Vector3.one * 0.66f;
        }
        else
        {
            transform.localScale = Vector3.one * 0.33f;
        }

        if (splitDepth <= 2)
        {
            Split();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullets"))
        {
            Debug.Log("Bullet Hit Asteroid");
            Destroy(collision.gameObject);
            Split();
        }
    }
}
