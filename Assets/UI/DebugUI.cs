using TMPro;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public static DebugUI Instance;

    public static void Log(string message)
    {
        if (Instance == null || Instance.text == null)
            return;

        Instance.text.text += message + "\n";
    }

    [SerializeField] TMP_Text text;
    private void OnEnable()
    {
        if(Instance == null)
            Instance = this;
    }
    private void OnDisable()
    {
        if(Instance == this)
            Instance = null;
    }
}
