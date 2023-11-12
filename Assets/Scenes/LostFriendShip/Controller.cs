using System.Linq;
using UnityEngine;

namespace LostFriendship
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Interactable _gift; 
        [SerializeField] private DialogueInteraction[] _secondPart;
        [SerializeField] private string[] _seconDialogue;

        [SerializeField] private bool _debuggin;

        private void Start()
        {
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
        }

        public void UnlockGift()
        {
            _gift.blocked = false;
        }
    }
}