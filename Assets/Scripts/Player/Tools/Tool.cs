using UnityEngine;
using UnityEngine.Events;

public abstract class Tool : MonoBehaviour
{
    [SerializeField] protected float _maxAngularVelocity;

    public float MaxAngularVelocity => _maxAngularVelocity;
}