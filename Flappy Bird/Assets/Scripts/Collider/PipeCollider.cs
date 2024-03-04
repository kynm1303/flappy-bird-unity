using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollider : MyRectangleCollider
{
    public float offsetX;
    public float offsetY;

    public PipeCollider(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public override RectangleData GetRectangleData()
    {
        RectangleData data = new RectangleData();
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            data.width = 0;
            data.height = 0;
        } else
        {
            data.width = spriteRenderer.size.x;
            data.height = spriteRenderer.size.y;
        }
        data.x = gameObject.transform.position.x - data.width / 2;
        data.y = gameObject.transform.position.y - data.height / 2;
        return data;
    }

    internal override void onCollideEnter(ColliderController.MyCollider other)
    {
    }

    internal override void onCollideExit(ColliderController.MyCollider other)
    {
    }
}
