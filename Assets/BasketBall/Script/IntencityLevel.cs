using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntencityLevel : MonoBehaviour
{
    [SerializeField] BallThrower ballThrower;
    [SerializeField] float travelHeight = 780;
    [SerializeField] RectTransform level;

    private void Update()
    {
        if (ballThrower == null)
            return;

        UpdateHeight();
    }

    private void UpdateHeight()
    {
        float intencity = ballThrower.sinValue;
        Vector3 localPos = level.localPosition;
        localPos.y = travelHeight * intencity;
        level.localPosition = localPos;
    }

}
