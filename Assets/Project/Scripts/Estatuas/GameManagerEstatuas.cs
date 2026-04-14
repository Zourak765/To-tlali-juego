using UnityEngine;

public class GameManagerEstatuas : MonoBehaviour
{
    public enum listaestatua
    {
        Estatua1, Estatua2, Estatua3, Estatua4
    }
    public listaestatua tipo;
    private bool Estatua1;
    private bool Estatua2;
    private bool Estatua3;
    private bool Estatua4;

    public void SetEstatua1(bool state) => Estatua1 = state;
    public bool GetEstatua1() => Estatua1;
   

    public void SetEstatua2(bool state)
    {
        Estatua2 = state;

    }
    public bool GetEstatua2()
    {
        return Estatua2;
    }

    public void SetEstatua3(bool state)
    {
        Estatua3 = state;

    }
    public bool GetEstatua3()
    {
        return Estatua3;
    }

    public void SetEstatua4(bool state)
    {
        Estatua4 = state;

    }
    public bool GetEstatua4()
    {
        return Estatua4;
    }



}
