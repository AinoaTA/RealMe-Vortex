using System.Collections;
using System.Linq;
using UnityEngine;

namespace BrokenHeart
{
    public enum StateScene
    {
        NONE = 0,
        CIGARRILLOS_INTRO,
        MUST_ELEK_TALK, GIVE_CIGARRILLOS,
        FIND_PILLS, FOUND_PILLS,
        FIND_MULETA, ELEK_TALKTO_LOGAN,
        FOUND_MULETA,
        BAD_TALKED, ELEK_COMES_TO_HELP,

        END_STATE
    }

    public class Controller : MonoBehaviour
    {
        public static Controller instance;
        [SerializeField] private Interactable[] _allInteractables;
        [SerializeField] private bool _debuggin;
        [SerializeField] private NPC.ChuckDialogue _chuck;
        [SerializeField] private StateScene _chuckState;

        [SerializeField] private ElekDialogue _elek;
        [SerializeField] private Transform _elekPos1;

        private void Awake()
        {
            instance = this;
        }

        private IEnumerator Start()
        {
            GameManager.instance.MustFollowPlayer = false;

            if (!_debuggin)
            {
                _allInteractables.ToList().ForEach(n =>
                {
                    n.blocked = true;
                    n.enabled = false;
                });
            }

            _chuckState = StateScene.NONE;
            yield return new WaitForSeconds(0.3f);

            if (!_debuggin)
                GameManager.instance.StartConver("BrokenHeart/Intro_BrokenHeart", true);
            //GameManager.instance.StartConver("BrokenHeart/Vacio", true);
        }

        public bool CheckState(StateScene chuckState)
        {
            return _chuckState == chuckState;
        }

        public void NextState()
        {
            _chuckState++;

            switch (_chuckState)
            { 
                case StateScene.CIGARRILLOS_INTRO: 
                    _chuck.blocked = true;
                    _elek.blocked = true;
                    break;
                case StateScene.MUST_ELEK_TALK: 
                    _elek.blocked = false;
                    _chuck.blocked = true;
                    GameManager.instance.StartConver("BrokenHeart/Elek_Talk");
                    break;
                case StateScene.FIND_PILLS:
                    _chuck.blocked = true;
                    break;
                case StateScene.FIND_MULETA:
                    _elek.transform.position = _elekPos1.position;
                    _chuck.blocked = true;
                    
                    break;
                case StateScene.ELEK_TALKTO_LOGAN:
                    GameManager.instance.StartConver("BrokenHeart/Elek_PreTalking2",true); 
                    _elek.blocked = false;
                    _chuck.blocked = true;
                    break;

                case StateScene.FOUND_PILLS:
                case StateScene.GIVE_CIGARRILLOS:
                case StateScene.FOUND_MULETA:
                    _chuck.blocked = false;
                    _elek.blocked = true;
                    break;
                case StateScene.END_STATE:
                    break;
                default:
                    break;
            }
        }

        public void GoodEnding() 
        {
        
        }

        public StateScene CurrentState() => _chuckState;
    }
}