using System.Linq;
using UnityEngine;

namespace LostFriendship
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Interactable _gift;
        [SerializeField] private Interactable _initDoor;
        [SerializeField] private Interactable _lastDoor;
        [SerializeField] private DialogueInteraction[] _secondPart;
        [SerializeField] private string[] _seconDialogue;

        [SerializeField] private bool _debuggin;

        private void Start()
        {
            FMODSpecial.instance.ChangeMusic(EnumsData.MusicScene.SCENE3);

            _gift.blocked = true;
 
            GameManager.instance.MustFollowPlayer = true;
            if(!_debuggin)
            GameManager.instance.StartConver("LostFriendship/Intro", true);
        }

        public void SecondPhase()
        {
            for (int i = 0; i < _seconDialogue.Length; i++)
            {
                _secondPart[i]._dialogue = "LostFriendship/" + _seconDialogue[i];
            }

            _secondPart.ToList().ForEach(n => n.BlockInteraction(false));

            _initDoor.blocked = true;
            _initDoor.enabled = false;
        }

        public void UnlockGift()
        {
            _gift.blocked = false;
        }

        public void UnlockDoor()
        {
            _initDoor.blocked = true;
            _initDoor.enabled = false;

            _lastDoor.blocked = false;
            _lastDoor.enabled = true;
        }
    }
}