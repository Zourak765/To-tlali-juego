using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicMinigame : MonoBehaviour
{
    [SerializeField, Min(0f)] private float delay;
    [SerializeField] private int maxNotesInTracks = 10;
    [SerializeField] private int maxSequencedNotes = 3;
    [SerializeField, Min(0f)] private float noteSpeed;
    [SerializeField, Min(0f)] private float minSpawnTime;
    [SerializeField, Min(1)] private int maxProgress = 10;
    [Space(4)]
    [SerializeField] private MinigameReferences refs;
    [SerializeField] private ExternalEvents events;

    private float[] clipSamples = new float[64];
    private float spawnElapsed;
    private int lastNoteTrackIndex = 0, sequencedNotesCount = 0;
    private float progressNormalized = 0f;

    private int currentProgress;
    public bool IsPlaying {get ; private set;}
    public bool HasWon {get; private set;}

    private List<MusicMinigame_Note> currentNotes = new List<MusicMinigame_Note>();

    private void OnDisable() => StopAll();

    public void StartMinigame(AudioClip _clip)
    {
        if(IsPlaying) return;
        Setup(_clip);
        StartCoroutine(MinigameRoutine());
    }

    public void AddPoint()
    {
        if(!IsPlaying) return;
        currentProgress++;
        if(currentProgress >= maxProgress) currentProgress = maxProgress;

        UpdateProgress();
    }
    public void RemovePoint()
    {
        if(!IsPlaying) return;
        currentProgress--;
        if(currentProgress <= 0) currentProgress = 0;

        UpdateProgress();
    }

    private void UpdateProgress()
    {
        progressNormalized = Mathf.InverseLerp(0, maxProgress, currentProgress);
        events.OnProgressUpdated?.Invoke(progressNormalized);
    }

    private void Setup(AudioClip _clip)
    {
        Clear();
        refs.TargetSource.loop = false;
        refs.TargetSource.Stop();
        refs.TargetSource.clip = _clip; 
    }

    private IEnumerator MinigameRoutine()
    {
        IsPlaying = true;

        progressNormalized = 0f;
        currentProgress = 0;
        spawnElapsed = 0f;
        HasWon = false;
        sequencedNotesCount = 0;
     
        refs.TargetSource.GetSpectrumData(clipSamples, 0, FFTWindow.Rectangular);
        refs.TargetSource.Play();

        events.OnStart?.Invoke();
        yield return new WaitForSeconds(delay);
        while(IsTrackPlaying()) // Minigame execution
        {    
            spawnElapsed += Time.deltaTime;
            if(spawnElapsed >= minSpawnTime && currentNotes.Count < maxNotesInTracks)
            {
                spawnElapsed = 0f;
                int currentTrackIndex = Random.Range(0,2);
                if(currentTrackIndex == lastNoteTrackIndex && sequencedNotesCount >= maxSequencedNotes)
                {
                    do currentTrackIndex = Random.Range(0,2);
                    while(currentTrackIndex == lastNoteTrackIndex);
                }
                if(currentTrackIndex != lastNoteTrackIndex) sequencedNotesCount = 1;
                else sequencedNotesCount++;
                SpawnNote(currentTrackIndex);
                lastNoteTrackIndex = currentTrackIndex;
            }

            for (int i = 0; i < currentNotes.Count; i++) currentNotes[i].Tick();       
            yield return null;
        }
        Clear();
        events.OnEnd?.Invoke();
        ValidateMinigameStatus();
        IsPlaying = false;
    }

    public void RemoveNote(MusicMinigame_Note _note)
    {
        if(!currentNotes.Contains(_note)) return;
        Destroy(_note.gameObject);
        currentNotes.Remove(_note); 
    }
    private void SpawnNote(int _index)
    {
        MusicMinigame_Note targetNote; 
        switch(_index)
        {
            default:
            targetNote = Instantiate(refs.BlueNotePrefab);
            targetNote.Initialize(this, refs.TrackBlueInit.position, refs.TrackBlueEnd.position, noteSpeed);
            break;

            case 1:
            targetNote = Instantiate(refs.OrangeNotePrefab);
            targetNote.Initialize(this, refs.TrackOrangeInit.position, refs.TrackOrangeEnd.position, noteSpeed);
            break;
        }
        currentNotes.Add(targetNote);
    }
    private void Clear()
    {
        if(currentNotes == null || currentNotes.Count == 0) return;
        foreach (MusicMinigame_Note note in currentNotes) Destroy(note.gameObject);
        currentNotes.Clear();
    }
    private bool IsTrackPlaying()
    {
        if(refs.TargetSource == null || refs.TargetSource.clip == null) return false;
        return refs.TargetSource.isPlaying;
    }

    private void ValidateMinigameStatus()
    {
        HasWon  = currentProgress >= maxProgress;
        if(HasWon) events.OnWin?.Invoke();
        else events.OnLoose?.Invoke();
    }


    private void StopAll()
    {
        StopAllCoroutines();
        Clear();
    }

#region Refs
    [System.Serializable]
    private class MinigameReferences
    {
        public AudioSource TargetSource;
        public Transform TrackBlueInit;
        public Transform TrackOrangeInit;
        public Transform TrackBlueEnd;
        public Transform TrackOrangeEnd;
        public MusicMinigame_Note BlueNotePrefab;
        public MusicMinigame_Note OrangeNotePrefab;
    }
    [System.Serializable]
    private struct ExternalEvents
    {
        public UnityEvent OnStart;
        public UnityEvent<float> OnProgressUpdated;
        public UnityEvent OnEnd;
        public UnityEvent OnWin;
        public UnityEvent OnLoose;
    }
    #endregion
}
