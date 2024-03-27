public class ItemGear : Item
{
    public override void ApplyEffect()
    {

        GameSession.Instance.ScalePaddle();
        Destroy(gameObject);



    }

}
