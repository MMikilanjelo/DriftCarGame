using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUpdate : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0 ; i < MonoCashe._allUpdates.Count ; i ++) MonoCashe._allUpdates[i].Tick();
    }
    private void FixedUpdate()
    {
        for (int i = 0 ; i < MonoCashe._allFixedUpdates.Count ; i ++) MonoCashe._allFixedUpdates[i].FixedTick();
    }
    private void LateUpdate()
    {
        for (int i = 0 ; i < MonoCashe._allLateUpdates.Count ; i ++) MonoCashe._allLateUpdates[i].LateTick();
    }
}
