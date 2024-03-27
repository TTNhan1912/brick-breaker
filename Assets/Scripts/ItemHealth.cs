public class ItemHealth : Item
{
    public override void ApplyEffect()
    {

        Destroy(gameObject);
        if (GameSession.Instance.PlayerLives >= 5) return;
        GameSession.Instance.PlayerLives += 1;





    }

}
