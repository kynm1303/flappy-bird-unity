using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDetect : MonoBehaviour
{
    public float width;
    public float height;
    private ScoreRangeCollider scoreCollider;
    private void Awake()
    {
        this.scoreCollider = new ScoreRangeCollider(gameObject);
        scoreCollider.width = width;
        scoreCollider.height = height;
    }

    private void OnDestroy()
    {
        this.scoreCollider.DestroyCollider();
    }
}
