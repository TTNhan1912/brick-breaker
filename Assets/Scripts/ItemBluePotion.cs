using UnityEngine;
public class ItemBluePotion : Item
{

    public override void ApplyEffect()
    {
        Debug.Log(3);
        GameSession.Instance.SlowSpeed();

        Destroy(gameObject);
    }


}
