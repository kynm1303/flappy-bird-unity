using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float speed = -3f;
    private float leftEdge;
    [SerializeField]
    GameObject topPipe;
    [SerializeField]
    GameObject bottomPipe;
    private PipeCollider topPipeCollider;
    private PipeCollider bottomPipeCollider;

    private void Awake()
    {
        topPipeCollider = new PipeCollider(topPipe);
        bottomPipeCollider = new PipeCollider(bottomPipe);
    }

    // Start is called before the first frame update
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.gameState == GameState.GAME_OVER) return;
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        this.topPipeCollider.DestroyCollider();
        this.bottomPipeCollider.DestroyCollider();
    }
}
