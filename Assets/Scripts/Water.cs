using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float _floatingForce;
    
    private ParticleSystem _splashParticles;

    private void Start()
    {
        _splashParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.TryGetComponent<Rigidbody>(out _))
        {
            _splashParticles.transform.position = new(_splashParticles.transform.position.x,
                _splashParticles.transform.position.y, other.transform.position.z);

            PlayParticles();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rb))
        {
            Vector3 upwardForce = transform.TransformDirection(Vector3.up) * _floatingForce;

            rb.AddForce(upwardForce, ForceMode.Force);

            if (other.GetComponentInChildren<Paddle>() != null)
            {
                Vector3 upforwardForce = transform.TransformDirection(new Vector3(0, 0.5f, 0.7f)) * _floatingForce;

                other.GetComponent<Rigidbody>().AddForce(upforwardForce, ForceMode.Force);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out _))
        {
            StopParticles();
        }
    }

    private void PlayParticles()
    {
        if (_splashParticles != null && _splashParticles.isPlaying == false)
        {
            _splashParticles.Play();
        }
    }

    private void StopParticles()
    {
        if (_splashParticles != null && _splashParticles.isPlaying)
        {
            _splashParticles.Stop();
        }
    }
}
