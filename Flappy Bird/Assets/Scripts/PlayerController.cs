using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private int spriteIndex = 0;
    [SerializeField]
    private Sprite[] birdSprites;
    private SpriteRenderer spriteRenderer;

    private Vector3 velocity;
    public static float jumpForce = 5f;
    private BirdCollider birdCollider;
    private Vector3 birdOriginal;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.birdCollider = new BirdCollider(gameObject);
        birdOriginal = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.InitBird();
        InvokeRepeating(nameof(AnimateBird), 0.15f, 0.15f);
    }

    public void InitBird()
    {
        velocity = Vector3.zero;
        transform.position = birdOriginal;
        transform.rotation = Quaternion.identity;
        velocity.y = PlayerController.jumpForce;
        spriteIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.gameState == GameState.START)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                velocity.y = PlayerController.jumpForce;
                SoundManager.Instance.playSound(SoundType.BirdFly);
            }

            velocity.y -= Constant.gravity * Time.deltaTime;
            Vector3 newPosition = transform.position + velocity * Time.deltaTime;
            transform.position = newPosition;
            Vector3 directionVector = new Vector3(5f, velocity.y, 0);
            transform.eulerAngles = new Vector3(0, 0, Utils.getAnglesFromVector(directionVector));
        }
    }
    private void AnimateBird()
    {
        if (GameController.Instance.gameState == GameState.START
            || GameController.Instance.gameState == GameState.IDLE)
        spriteIndex++;
        if (spriteIndex >= this.birdSprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = birdSprites[spriteIndex];
    }

    private void OnDestroy()
    {
        this.birdCollider.DestroyCollider();
    }
}
