using UnityEngine;

public class ItemHealth : Item
{
    public override void ApplyEffect()
    {
        Debug.Log(1);
        Destroy(gameObject);
        if (GameSession.Instance.PlayerLives >= 5) return;
        GameSession.Instance.PlayerLives += 1;


        Debug.Log(GameSession.Instance.PlayerLives);


    }

}
