using UnityEngine;

public class ItemGear : Item
{
    public override void ApplyEffect()
    {
        Debug.Log(2);
        GameSession.Instance.ScalePaddle();
        Destroy(gameObject);



    }

}
