using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class MyRectangleCollider : ColliderController.MyCollider
{
    public MyRectangleCollider()
    {
        colliderType = ColliderType.RECTANGLE;
    }
    internal override bool isCollide(ColliderController.MyCollider other)
    {
        switch (other.colliderType)
        {
            case ColliderType.CIRCLE:
                return CircleRectangleColliderStategy.isCollide((MyCircleCollider)other, this);
            default:
            case ColliderType.RECTANGLE:
                // handle later
                return false;
        }
    }

    public abstract RectangleData GetRectangleData();
    internal abstract override void onCollideEnter(ColliderController.MyCollider other);
}

public class RectangleData
{
    public float x;
    public float y;
    public float width;
    public float height;
}