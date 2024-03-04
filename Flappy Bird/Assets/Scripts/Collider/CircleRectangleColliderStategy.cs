using System;
using UnityEngine;
public static class CircleRectangleColliderStategy
{
    public static bool isCollide(MyCircleCollider circle, MyRectangleCollider rectangle)
    {
        CircleData cir = circle.GetCircleData();
        RectangleData rect = rectangle.GetRectangleData();
        float testY;
        float testX;
        float cx = cir.x, cy = cir.y, rx = rect.x, ry = rect.y, rw = rect.width, rh = rect.height;
        // If the circle is to the LEFT of the square, check against the LEFT edge.
        if (cx < rx) testX = rx;
        else if
            //If the circle is to the RIGHT of the square, check against the RIGHT edge.
            (cx > rx + rw) testX = rx + rw;
        else testX = cir.x; // If the circle is between LEFT & RIGHT of the square => distanceX = 0

        //If the circle is ABOVE the square, check against the TOP edge.
        if (cy < ry) testY = ry;
        else if //If the circle is to the BELOW the square, check against the BOTTOM edge.
            (cy > ry + rh) testY = ry + rh;
        else testY = cir.y; // If the circle is between TOP & BOTTOM of the square => distanceY = 0

        //Debug.DrawLine(new Vector3(cx, cy, 0), new Vector3(cx + cir.radius, cy, 0), Color.red, 0.2f);
        //Debug.DrawLine(new Vector3(rx, ry, 0), new Vector3(rx, ry + rh, 0), Color.red, 0.2f);
        //Debug.DrawLine(new Vector3(rx, ry, 0), new Vector3(rx + rw, ry, 0), Color.red, 0.2f);
        //Debug.DrawLine(new Vector3(rx + rw, ry, 0), new Vector3(rx + rw, ry + rh, 0), Color.red, 0.2f);
        //Debug.DrawLine(new Vector3(rx, ry + rh, 0), new Vector3(rx + rw, ry + rh, 0), Color.red, 0.2f);
        float distX = cx - testX;
        float distY = cy - testY;
        float distance = (float)Math.Sqrt((distX * distX) + (distY * distY));

        if (distance <= cir.radius)
        {
            return true;
        }
        return false;
    }
}