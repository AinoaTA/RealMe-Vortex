// Recompile at 01/11/2023 19:53:20


// Copyright (c) Pixel Crushers. All rights reserved.

using UnityEngine;

namespace PixelCrushers.DialogueSystem.Demo.Wrappers
{

    /// <summary>
    /// This wrapper class keeps references intact if you switch between the 
    /// compiled assembly and source code versions of the original class.
    /// </summary>
    [AddComponentMenu("Pixel Crushers/Dialogue System/Actor/Demo/Navigate On Mouse Click")]
#if USE_NAVMESH
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
#endif
    public class NavigateOnMouseClick : PixelCrushers.DialogueSystem.Demo.NavigateOnMouseClick
    {
    }

}
