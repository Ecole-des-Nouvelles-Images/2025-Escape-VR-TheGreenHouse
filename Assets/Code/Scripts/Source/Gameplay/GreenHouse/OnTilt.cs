using UnityEngine;

public class OnTilt : MonoBehaviour
{
    [SerializeField] ParticleSystem _waterParticle;
    [Range(0,180)] [SerializeField] private float _orientationTreshold = 60f;
    
    void Update()
    {
        CheckOrientation();
    }

    private void CheckOrientation()
    {
        float angle = Vector3.Angle(transform.forward, Vector3.down);

        if (angle < _orientationTreshold)
        {
           OnWaterBegin();
        }
        else
        {
           OnWaterEnd();
        }
    }
    
    private void OnWaterBegin()
    {
        if (!_waterParticle.isPlaying) _waterParticle.Play();
    }
    
    private void OnWaterEnd()
    {
        if (_waterParticle.isPlaying) _waterParticle.Stop();
    }
}
