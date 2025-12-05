using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float jumpForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb2d = col.gameObject.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d?.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            }
        }
    }
    void Start()
    {
        Destroy(this.gameObject, 20f);
    } 
}

