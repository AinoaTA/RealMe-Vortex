using System.Collections;
using System.Linq;
using UnityEngine;

namespace BrokenHeart
{
    public enum StateScene
    {
        NONE = 0,
        CIGARRILLOS_INTRO,
        MUST_ELEK_TALK, ELEK_TALKED_FINISHED,
        FIND_PILLS, FOUND_PILLS,
        FIND_MULETA, ELEK_TALKTO_LOGAN,
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
            _chuckState = StateScene.CIGARRILLOS_INTRO;
            yield return new WaitForSeconds(0.3f);
            //GameManager.instance.StartConver("BrokenHeart/Intro_BrokenHeart", true);
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
                case StateScene.NONE:
                    break;
                case StateScene.CIGARRILLOS_INTRO:
                case StateScene.MUST_ELEK_TALK: 
                case StateScene.FIND_PILLS:
                case StateScene.FIND_MULETA:
                    _chuck.blocked = true;

                    break;
                case StateScene.FOUND_PILLS:
                case StateScene.ELEK_TALKED_FINISHED:
                    _chuck.blocked = false;
                    break;
                case StateScene.END_STATE:
                    break;
                default:
                    break;
            }
        }

        public StateScene CurrentState() => _chuckState;
    }
}