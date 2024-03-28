public class ItemBluePotion : Item
{

    public override void ApplyEffect()
    {
        GameSession.Instance.SlowSpeed();

        Destroy(gameObject);
    }

    public override void Start()
    {
        base.Start();
    }
}
