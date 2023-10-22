
namespace Characters
{
    public class CharacterProfile
    {
        public float FriendshipValue { get; private set; }
        public float HateValue { get; private set; }

        private readonly CharacterInfo character;

        public CharacterProfile(CharacterInfo characterInfo)
        {
            character = characterInfo;
            FriendshipValue = 0;
            HateValue = 0;
        }

        public CharacterProfile(CharacterInfo characterInfo, float friendship)
        {
            character = characterInfo;
            this.FriendshipValue = 0;
            HateValue = 0;
        }
    }
}