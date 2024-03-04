using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class MyCircleCollider : ColliderController.MyCollider
{
    public MyCircleCollider()
    {
        colliderType = ColliderType.CIRCLE;
    }
    internal override bool isCollide(ColliderController.MyCollider other)
    {
        switch (other.colliderType)
        {
            case ColliderType.CIRCLE:
                return CircleCircleColliderStategy.isCollide(this, (MyCircleCollider)other);
            case ColliderType.RECTANGLE:
                return CircleRectangleColliderStategy.isCollide(this, (MyRectangleCollider)other);
            default:
                return false;
        }
    }

    public abstract CircleData GetCircleData();

    internal abstract override void onCollideEnter(ColliderController.MyCollider other);
}

public class CircleData
{
    public float x;
    public float y;
    public float radius;
}