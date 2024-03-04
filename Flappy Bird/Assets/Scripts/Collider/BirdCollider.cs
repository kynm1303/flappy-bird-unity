using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollider : MyCircleCollider
{
    public float x;
    public float y;
    public float radius = 0.2f;

    public BirdCollider(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public override CircleData GetCircleData()
    {
        CircleData data = new CircleData();
        data.x = gameObject.transform.position.x;
        data.y = gameObject.transform.position.y;
        data.radius = this.radius;
        return data;
    }

    internal override void onCollideEnter(ColliderController.MyCollider other)
    {
        Debug.Log("Bird Collider onCollide");
        if (other.gameObject.tag == "Pipe" || other.gameObject.tag == "Ground")
        {
            GameController.Instance.changeGameState(GameState.GAME_OVER);
        }
        if (other.gameObject.tag == "ScoreRange")
        {
            GameController.Instance.scoreController.HandleAddScore();
        }
    }

    internal override void onCollideExit(ColliderController.MyCollider other)
    {
    }
}
