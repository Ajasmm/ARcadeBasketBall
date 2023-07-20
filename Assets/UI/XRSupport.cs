using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class XRSupport : MonoBehaviour
{
    [SerializeField] ARSession ARSession;

    private void Start()
    {
        StartCoroutine(StartARSession());
    }

    private void Update()
    {
        DebugUI.Log(ARSession.state.ToString());
    }

    IEnumerator StartARSession()
    {
        while(ARSession == null)
        {
            yield return null;
        }

        if(ARSession.state == ARSessionState.None || ARSession.state == ARSessionState.Ready)
        {
            yield return ARSession.CheckAvailability();
        }
    }
}
