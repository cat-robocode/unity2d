using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // new
public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float _directionMove;
    private Rigidbody2D _rb2d;
    private float _screenWidth;
    [SerializeField] private Text score;
    public int rubyCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        _directionMove = Input.GetAxis("Horizontal") * movementSpeed;

        if(transform.position.x > _screenWidth)
        {
            transform.position = new Vector3(-_screenWidth, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -_screenWidth)
        {
            transform.position = new Vector3(_screenWidth, transform.position.y, transform.position.z);
        }
    }
    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(_directionMove,_rb2d.linearVelocity.y);
        _rb2d.linearVelocity = velocity;
    }
    public void RestartLevel()
    {
            Debug.Log("You lose!");
            Invoke("LoadSceneNow", 0f);
    }
    public void LoadSceneNow()
    {
        SceneManager.LoadScene(0);
    }
    public void AddRubie()
    {
        rubyCount++;
        score.text = rubyCount.ToString();
    }
}
