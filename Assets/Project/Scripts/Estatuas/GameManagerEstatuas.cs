using UnityEngine;

public class GameManagerEstatuas : MonoBehaviour
{
    public enum listaestatua
    {
        Estatua1,
        Estatua2,
        Estatua3,
        Estatua4
    }

    private bool[] estados = new bool[4];
    public void SetEstatua(listaestatua tipo, bool estado)
    {
        estados[(int)tipo] = estado;
    }
    public bool GetEstatua(listaestatua tipo)
    {
        return estados[(int)tipo];
    }
}