namespace Awakening
{
    public class Mesilla : DialogueInteraction
    {
        public override void Interact()
        {
            base.Interact();

            if (!Controller.instance.KeyUnlocked)
            {
                GameManager.instance.StartConver(_dialogue);
            }
            else
            {
                blocked = true;
                GameManager.instance.StartConver("Mesilla_Key");
            } 
        }
    }
}
