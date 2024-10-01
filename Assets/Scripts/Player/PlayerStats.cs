using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerStats : EntityStats
{
    #region Global Variables
    
    [SerializeField] private Transform _respawnPoint;

    CinemachineConfiner2D _cameraConfiner;

    PolygonCollider2D _newCameraBounds;

    VolumeProfile _postProcessVolume;
    Vignette vignette;
    [SerializeField]
    private Youdied youDied;

    private AudioSource _sfxHandler;
    [SerializeField] private AudioClip hurtEffect;

    public bool PlayerIsDead { get; private set; }

    public int MajorSoulsCollected { get; private set; }
    public int MinorSoulsCollected { get; private set; }


    #endregion

    #region Damage
    public override void TakeDamage(int damage)
    {
        IncrementHealth(-damage);
        if (Health <= 0)
        {
            if(!PlayerIsDead)
            {
                PlayerIsDead = true;
                youDied.Died();
                //_cameraConfiner.BoundingShape2D = _newCameraBounds;
            }            
        }
    }
    #endregion
    
    public void Respawn()
    {
        if(_respawnPoint != null)
        {
            transform.position = _respawnPoint.position;
            PlayerIsDead = false;
            IncrementHealth(999999);
        }
        else
        {
            transform.position = Vector3.zero;
            PlayerIsDead = false;
            IncrementHealth(999999);
        }
    }
    
    public void ChangeRespawnPoint(Transform newPoint)
    {
        _respawnPoint = newPoint;
    }

}