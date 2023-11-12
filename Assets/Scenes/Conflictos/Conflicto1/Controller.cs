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
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.3f);
            GameManager.instance.MustFollowPlayer = false;
        } 
    }
}