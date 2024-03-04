using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MyRectangleCollider
{
    public float offsetX;
    public float offsetY;

    public GroundCollider(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public override RectangleData GetRectangleData()
    {
        RectangleData data = new RectangleData();
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            data.width = 0;
            data.height = 0;
        } else
        {
            data.width = meshRenderer.bounds.size.x;
            data.height = meshRenderer.bounds.size.y;
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
