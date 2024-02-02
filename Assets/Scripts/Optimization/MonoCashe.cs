using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCashe : MonoBehaviour
{
    private const int MAX_CASH_OBJECTS = 1001;
    public static List<MonoCashe> _allUpdates = new List<MonoCashe>(MAX_CASH_OBJECTS);
    public static List<MonoCashe> _allFixedUpdates = new List<MonoCashe>(MAX_CASH_OBJECTS);
    public static List<MonoCashe> _allLateUpdates = new List<MonoCashe>(MAX_CASH_OBJECTS);

    private void OnEnable() => _allUpdates.Add(this);
    private void OnDisable() => _allUpdates.Remove(this);
    private void OnDestroy () => _allUpdates.Remove(this);
    
    protected void AddLateUpdate() => _allLateUpdates.Add(this);
    protected void AddFixedUpdate() => _allFixedUpdates.Add(this);
    
    protected void RemoveLateUpdate() => _allLateUpdates.Remove(this);
    protected void RemoveFixedUpdate() => _allFixedUpdates.Remove(this);
    
    
    public void Tick() => OnTick();
    public void FixedTick() => OnFixedTick();
    public void LateTick() => OnLateTick();
    
    public virtual void OnTick() { }
    public virtual void OnFixedTick() {}
    public virtual void OnLateTick(){ }
}
