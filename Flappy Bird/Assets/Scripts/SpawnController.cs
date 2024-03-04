
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    private float delayTime = 1.3f;
    private float maxHeight = 1.5f;
    private float minHeight = -2.5f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = delayTime;
    }

    private float currentTime = 0;
    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.gameState == GameState.START)
        currentTime += Time.deltaTime;
        if (currentTime > delayTime) {
            this.SpawnPipe();
            currentTime = 0;
        }
    }

    private void SpawnPipe()
    {
        GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        float height = Random.Range(minHeight, maxHeight);
        pipe.transform.position += new Vector3(0, height, 0);
    }
}
