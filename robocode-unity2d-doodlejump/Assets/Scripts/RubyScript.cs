using UnityEngine;

public class RubyScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerController>().AddRubie();
            Destroy(gameObject);
        }
    }
}
