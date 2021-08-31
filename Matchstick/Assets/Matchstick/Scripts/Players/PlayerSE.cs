using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSE : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] footSteps;
    [SerializeField]
    private AudioClip getCantera;
    [SerializeField]
    private AudioClip cantera;
    [SerializeField]
    private AudioClip jump;
    [SerializeField]
    private AudioClip land;
    [SerializeField]
    private AudioClip lightMatch;
    [SerializeField]
    private AudioClip extinguishingMatch;


    [SerializeField]
    private AudioSource footStepsAudioSource;
    [SerializeField]
    private AudioSource canteraAudioSource;
    [SerializeField]
    private AudioSource audioSource;


    [SerializeField]
    private bool footStepRandomizePitch = true;
    [SerializeField]
    private float footStepPitchRange = 0.1f;
    [SerializeField]
    private float footStepPitchAdjust = 0.1f;
    [SerializeField]
    private float canteraPitchAdjust = -0.1f;


    void Start()
    {
        //�s�b�`����
        canteraAudioSource.pitch = 1.0f + canteraPitchAdjust;

    }

    private void Awake()
    {
        footStepsAudioSource = GetComponents<AudioSource>()[0];
    }

    void Update()
    {

    }
    //�W�����v�J�n
    public void PlayJumpStartSE()
    {
        audioSource.pitch = 0.9f;
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(jump);
    }
    //���n
    public void PlayJumpEndSE(float landingHeight)
    {
        audioSource.volume = 0.2f + landingHeight * 0.5f;
        audioSource.pitch = 1.0f + landingHeight * 0.5f;
        audioSource.PlayOneShot(land);
    }
    //�}�b�`�_��
    public void PlayLightMatchSE()
    {
        audioSource.pitch = 1.0f;
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(lightMatch);
    }
    //�}�b�`����
    public void PlayExtinguishingMatchSE()
    {
        audioSource.pitch = 1.0f;
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(extinguishingMatch);
    }


    //�J���e���擾
    public void PlayCanteraGetSE()
    {
        audioSource.pitch = 1.0f;
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(getCantera);
    }

    //�J���e���ړ�
    public void PlayCanteraMoveSE()
    {
        if (!canteraAudioSource.isPlaying)
        {
            canteraAudioSource.PlayOneShot(cantera);
        }
    }
    //�J���e���ړ���~
    public void StopCanteraMoveSE()
    {
        canteraAudioSource.Stop();
    }

    //����
    public void PlayFootStepsSE()
    {
        if (!footStepsAudioSource.isPlaying)
        {
            if (footStepRandomizePitch)
            {
                footStepsAudioSource.pitch = (1.0f + footStepPitchAdjust) + Random.Range(-footStepPitchRange, footStepPitchRange);
            }
            //����炷
            footStepsAudioSource.PlayOneShot(footSteps[Random.Range(0, footSteps.Length)]);
        }
       
    }
    //������~
    public void StopFootStepsSE()
    {
        footStepsAudioSource.Stop();
    }

}
