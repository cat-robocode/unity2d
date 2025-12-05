using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject rubyPrefab;
    [SerializeField] private GameObject bombPrefab;
    private float _screenWidth;
    private Vector3 _nextSpot = Vector3.zero;
    private float _highestPoint = 0f;

    private int _platformCount = 0;

    private void Start()
    {
        _screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    } 
    private void Update()
    {
        if (player.position.y > _highestPoint - 10f)
        {
            MakePlatforms();
        }

    }
    private void MakePlatforms()
    {
        for (int i = 0; i < 20; i ++)
        {
            _nextSpot.x = Random.Range(-_screenWidth + 0.5f, _screenWidth - 0.5f);
            _nextSpot.y += Random.Range(1.5f, 2.5f);

            Instantiate(platformPrefab, _nextSpot, Quaternion.identity);
            if (i % 3  == 0) Instantiate(rubyPrefab, _nextSpot, Quaternion.identity);
            if (i % 13 == 0) Instantiate(bombPrefab, _nextSpot, Quaternion.identity);
            _highestPoint = _nextSpot.y;
            _platformCount++;
        }
    }
}
