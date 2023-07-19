using Game.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialGameplayController : MonoBehaviour
{
    public void Pause()
    {
        GameManager.Instance.GameplayMode?.Pause();
    }
}
