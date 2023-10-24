using UnityEngine;
using System.Linq;

public class InitializerController : MonoBehaviour
{
    [Tooltip("Add in order of execution (AWAKE)")]
    [SerializeField] private GameObject[] ObjectToInitializeAwake;

    [Tooltip("Add in order of execution (Start)")]
    [SerializeField] private GameObject[] ObjectToInitializeStart;

    private void Awake()
    {
        AllAwake();
    } 

    private void Start()
    {
        AllStart();
    }

    public void InitializeAwake()
    {
        AllAwake();
    }

    public void AllAwake()
    {
        if (ObjectToInitializeAwake.Length == 0) return;

        ObjectToInitializeAwake.ToList().ForEach((x) =>
        {
            if (x.TryGetComponent(out IInitialize interf))
            {
                interf.InitializeAwake();
                Debug.Log("Initalized: " + x.name);
            }
        });

    }

    public void AllStart()
    {
        if (ObjectToInitializeStart.Length == 0) return;

        ObjectToInitializeStart.ToList().ForEach((x) =>
        {
            if (x.TryGetComponent(out IInitialize interf))
            {
                interf.InitializeStart();
                Debug.Log("Started: " + x.name);
            }
        });
    }
}