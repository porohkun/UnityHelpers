using UnityEngine;

public class DestroyOnParticleFinish : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private bool _waitLastParticle;

    private void Reset()
    {
        if (_particle == null)
        {
            _particle = GetComponentInChildren<ParticleSystem>();
            if (_particle == null)
            {
                Debug.LogWarning($"Particle System is not attached to {name}", gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (_particle && !_particle.isPlaying && (!_waitLastParticle || _particle.particleCount == 0))
        {
            Destroy(gameObject);
        }
    }

    private void OnValidate()
    {
        if (_particle == null)
        {
            Debug.LogWarning($"Particle System is not attached to {name}", gameObject);
        }
    }
}