using UnityEngine;

public class MusicMinigame_Note : MonoBehaviour
{
    private MusicMinigame manager;
    private bool isMoving;
    private float moveSpeed;
    private Vector3 targetPosition;

    public void Initialize(MusicMinigame _manager, Vector3 _spawnPos, Vector3 _targetPosition, float _speed)
    {
        manager = _manager;
        transform.position = _spawnPos;
        targetPosition = _targetPosition;
        moveSpeed = _speed;
        isMoving = true;   
    }
    public void Tick()
    {
        if(!isMoving) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        CheckPosition();
    }
    public void Count() => manager.AddPoint();

    private void CheckPosition()
    {
        if(Vector3.Distance(transform.position, targetPosition) <= .15f)
        {
            manager.RemovePoint();
            manager.RemoveNote(this);
        }
    }
    
}