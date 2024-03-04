using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ColliderType
{
    CIRCLE,
    RECTANGLE
}

public class ColliderController
{
    public abstract class MyCollider
    {
        internal int colliderId;
        public GameObject gameObject;
        internal ColliderType colliderType;
        public List<MyCollider> collided = new List<MyCollider>();
        public MyCollider()
        {
            colliderId = ColliderController.currentId++;
            ColliderController.AddToPool(this);
        }

        internal abstract void onCollideEnter(MyCollider other);
        internal abstract void onCollideExit(MyCollider other);
        internal abstract bool isCollide(MyCollider other);
        public void DestroyCollider ()
        {
            foreach(MyCollider other in collided)
            {
                other.collided.Remove(this);
            }
            colliderPool.Remove(this);
        }
    }
    private static int currentId;
    private static List<MyCollider> colliderPool = new List<MyCollider>();
    private static void AddToPool(MyCollider newCollider)
    {
        colliderPool.Add(newCollider);
    }


    public void checkForCollide()
    {
        for (int i = 0; i < colliderPool.Count; i++)
        {
            for (int j = i + 1; j < colliderPool.Count; j++)
            {
                MyCollider colliderI = colliderPool[i];
                MyCollider colliderJ = colliderPool[j];
                if (colliderI.isCollide(colliderJ))
                {
                    if (!checkCollided(colliderI, colliderJ))
                    {
                        colliderI.onCollideEnter(colliderJ);
                        colliderJ.onCollideEnter(colliderI);
                        colliderI.collided.Add(colliderJ);
                        colliderJ.collided.Add(colliderI);
                    }
                } else
                {
                    if (checkCollided(colliderI, colliderJ))
                    {
                        colliderI.onCollideExit(colliderJ);
                        colliderJ.onCollideExit(colliderI);
                        colliderI.collided.Remove(colliderJ);
                        colliderJ.collided.Remove(colliderI);
                    }
                }
            }
        }
    }

    public bool checkCollided(MyCollider collider1, MyCollider collider2)
    {
        return collider1.collided.Contains(collider2) || collider2.collided.Contains(collider1);
    }
}
