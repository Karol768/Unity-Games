using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPointsController : MonoBehaviour
{
    public PlayerController playerController;

    public void UpdateRestartPoint(Transform newTransform)
    {
        playerController.startPoint = newTransform;
    }
}
