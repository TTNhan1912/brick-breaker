using UnityEngine;
public class ItemBottle : Item
{
    public override void ApplyEffect()
    {
        Debug.Log(4);

        GameSession.Instance.Cancel();

        Destroy(gameObject);
    }

}
