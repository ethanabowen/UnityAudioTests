using UnityEngine;

public class MusicCube : MonoBehaviour
{
    private AudioSource audioSource;
    private MoveToGoal moveScript;
    public int scoreIndex;
    public float totalPlayTime = 0.0f;
    public ScaleNote currentScaleNote = ScaleNote.G;
    private bool isPlaying = false;

    private float m_LastStartTime;

    public void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        moveScript = gameObject.GetComponent<MoveToGoal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(
            $"{audioSource.clip.name} - OnTriggerEnter: {other.GetType().ToString()} - {totalPlayTime.ToString()}");
        if (other.GetType() == typeof(SphereCollider))
        {
            moveScript.Stun();
            if (isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
            }

            currentScaleNote = ScaleNoteMethods.GetNextChromatic(currentScaleNote);
            var clip =  Resources.Load($"Music/{currentScaleNote.ToString()}") as AudioClip;
            audioSource.clip = clip;
            if (!isPlaying)
            {
                audioSource.Play();
                isPlaying = true;
            }
        }
        else if (other.GetType() != typeof(BoxCollider) && !audioSource.isPlaying)
        {
            m_LastStartTime = Time.time;
            if (!isPlaying)
            {
                audioSource.Play();
                isPlaying = true;
            }

            ScoreBehavior.AddScore(scoreIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(
            $"{audioSource.clip.name} - OnTriggerExit: {other.GetType().ToString()} - {totalPlayTime.ToString()}");
        if (other.GetType() != typeof(BoxCollider) && other.GetType() != typeof(SphereCollider))
        {
            totalPlayTime += Time.time - m_LastStartTime;
            audioSource.Stop();
            isPlaying = false;
            ScoreBehavior.AddScore(scoreIndex);
        }
    }
}