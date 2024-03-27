public class ItemBluePotion : Item
{

    public override void ApplyEffect()
    {
        GameSession.Instance.SlowSpeed();

        Destroy(gameObject);
    }


}
