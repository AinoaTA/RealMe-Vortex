using System.Collections;
using UnityEngine;

/// <summary>
/// Level: player needs to go far away from that person to
/// complete the level.
/// </summary>
namespace Conflicto_1
{
    public class Controller : MonoBehaviour
    {
        private void Start()
        { 
            GameManager.instance.MustFollowPlayer = false;
        } 
    }
}