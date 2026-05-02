using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class EstatuaInteraccion : MonoBehaviour
{
    [SerializeField] private GameManagerEstatuas.listaestatua statueType;
    [SerializeField] private string requiredInstrument = "Instrumento1";
    [SerializeField] private AudioClip statueTrack;

    [Header("Notification Text")]
    [SerializeField] private Text notificationText;
    [SerializeField] private NotificationMessages notificationMessages;
    [Space(3)]
    [SerializeField] private ExternalEvents events;

    private Coroutine miniGameValidationCoroutine;
    private Coroutine showTextCoroutine;

    private GameManagerEstatuas globalGameManager;
    private MusicMinigame miniGameManager;
    private Player currentPlayer;

    private bool isMinigameRunning;


    private void Awake()
    {
        globalGameManager = FindFirstObjectByType<GameManagerEstatuas>();
        miniGameManager = FindFirstObjectByType<MusicMinigame>();
        currentPlayer = FindFirstObjectByType<Player>();
    }

    public void ActivateStatue()
    {
        if(isMinigameRunning) return;

        if (!InventMenu.instancia.TieneObjetoUnico(requiredInstrument))
        {
            ShowText(notificationMessages.NotItemMesssage, 2f);
            return;
        }

        if(miniGameValidationCoroutine != null) StopCoroutine(miniGameValidationCoroutine);
        miniGameValidationCoroutine = StartCoroutine(ValidateMinigame());
    }

    private IEnumerator ValidateMinigame()
    {
        currentPlayer.Deactivate("MusicMinigame");
        isMinigameRunning = true;
        events.OnGameStarted?.Invoke();


        miniGameManager.transform.position = transform.position;
        miniGameManager.StartMinigame(statueTrack);
        yield return null;

        while(miniGameManager.IsPlaying) yield return null;
        
        bool win = miniGameManager.HasWon;
        globalGameManager.SetEstatua(statueType, win);

        if(win)
        {
            events.OnWin?.Invoke();
            ShowText(notificationMessages.WinMesssage, 2f);
        }
        else
        {
            events.OnLoose?.Invoke();
            ShowText(notificationMessages.LooseMesssage, 2f);
        }

        events.OnGameEnded?.Invoke();
        isMinigameRunning = false;
        currentPlayer.Activate("MusicMinigame");
    }


    private void ShowText(string _text, float _duration)
    {
        if(showTextCoroutine != null) StopCoroutine(showTextCoroutine);
        showTextCoroutine = StartCoroutine(ShowTextRoutine(_text, _duration));
        
        IEnumerator ShowTextRoutine(string _text, float _duration)
        {
            notificationText.text = _text;
            notificationText.gameObject.SetActive(true);
            yield return new WaitForSeconds(_duration);
            notificationText.gameObject.SetActive(false);
        }
    }

    [System.Serializable]
    private struct ExternalEvents
    {
        public UnityEvent OnGameStarted;
        public UnityEvent OnWin;
        public UnityEvent OnLoose;
        public UnityEvent OnGameEnded;
    }

    [System.Serializable]
    private struct NotificationMessages
    {
        public string WinMesssage;
        public string LooseMesssage;
        public string NotItemMesssage;
    }
}