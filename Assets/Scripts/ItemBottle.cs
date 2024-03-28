public class ItemBottle : Item
{
    public override void ApplyEffect()
    {


        GameSession.Instance.Cancel();

        Destroy(gameObject);
    }
    public override void Start()
    {
        base.Start();
    }
}
