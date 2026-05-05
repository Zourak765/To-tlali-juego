using UnityEngine;
using UnityEngine.Events;

public class MenuPause : MonoBehaviour
{
    public enum Menu { Continuar, Opciones, MenuPrincipal }

    [SerializeField] private UnityEvent<bool, bool, bool> onMenuUpdated;

    private bool continuar, opciones, menuPrincipal;

    public void OpenMenu(Menu _menu)
    {
        continuar = false;
        opciones = false;
        menuPrincipal = false;

        switch (_menu)
        {
            case Menu.Continuar:
                continuar = true;
                break;
            case Menu.Opciones:
                opciones = true;
                break;
            case Menu.MenuPrincipal:
                menuPrincipal = true;
                break;
        }

        onMenuUpdated?.Invoke(continuar, opciones, menuPrincipal);
    }

    public void CloseAll()
    {
        continuar = false;
        opciones = false;
        menuPrincipal = false;

        onMenuUpdated?.Invoke(continuar, opciones, menuPrincipal);
    }

    public bool GetMenuState(Menu _menu)
    {
        switch (_menu)
        {
            case Menu.Continuar:
                return continuar;
            case Menu.Opciones:
                return opciones;
            case Menu.MenuPrincipal:
                return menuPrincipal;
        }
        return false;
    }
}