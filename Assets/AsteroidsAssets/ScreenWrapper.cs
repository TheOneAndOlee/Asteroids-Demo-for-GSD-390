using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrapper : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Collider2D collider;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    void FixedUpdate()
    {
        var topLeft = Camera.ScreenToWorldPoint(Vector3.zero);
        var bottomRight = Camera.ScreentoWorldPoint(new Vector3(Camera.main.scaledPixelWidth, Camera.main.scaledPixelheight, 0f));

        if (transform.position.x - collider.bounds.extents.x > bottomRight.x - collider.bounds.extents.x && rigidbody.velocity.x > 0)
        {
            transform.position = new Vector2(topLeft.x, transform.position.y);
        }
    }

}
