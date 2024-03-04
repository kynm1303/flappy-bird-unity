using UnityEngine;

public class ScoreRangeCollider : MyRectangleCollider
{
    public float width;
    public float height;
    public ScoreRangeCollider(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public override RectangleData GetRectangleData()
    {
        RectangleData data = new RectangleData();
        data.width = width;
        data.height = height;
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