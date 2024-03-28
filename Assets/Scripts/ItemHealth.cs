public class ItemHealth : Item
{
    public override void ApplyEffect()
    {

        if (GameSession.Instance.PlayerLives >= 5) return;
        GameSession.Instance.PlayerLives += 1;

        Destroy(gameObject);
    }

    public override void Start()
    {
        base.Start();
    }

}
