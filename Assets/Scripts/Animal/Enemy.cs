using System.Collections;
using UnityEngine;

public class Enemy : Animal
{
    [SerializeField] private HumanLegs _humanLegs;
    [SerializeField] private Axe _axe;
    [SerializeField] private Paddle _paddle;

    private readonly float _toolChangeDelay = 1.0f;
    private readonly float _legSetDelay = 1.7f;
    private Coroutine _coroutine;
    private bool _isCoroutineRunning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isCoroutineRunning == false)
        {
            if (other.gameObject.TryGetComponent<Obstacle>(out _))
            {
                RunCoroutine(_axe);
            }
            else if (other.gameObject.TryGetComponent<Water>(out _))
            {
                RunCoroutine(_paddle);
            }
        }
    }

    private void RunCoroutine(Tool tool)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(DelayedToolChange(tool));
    }

    private IEnumerator DelayedToolChange(Tool tool)
    {
        _isCoroutineRunning = true;

        yield return new WaitForSeconds(_toolChangeDelay);
        toolChanger.EnableChoosenTool(tool);
        yield return new WaitForSeconds(_legSetDelay);
        toolChanger.EnableChoosenTool(_humanLegs);

        _isCoroutineRunning = false;
    }
}