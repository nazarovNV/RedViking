using UnityEngine.UI;
using UnityEngine;

public class UICharacterController : MonoBehaviour
{
    [SerializeField] private PressedButton left;
    public PressedButton Left
    {
        get { return left; }
    }
    [SerializeField] private PressedButton right;
    public PressedButton Right
    {
        get { return right; }
    }
    [SerializeField] private PressedButton fire;
    public PressedButton Fire
    {
        get { return fire; }
    }
    [SerializeField] private PressedButton jump;
    public PressedButton Jump
    {
        get { return jump; }
    }
    [SerializeField] private PressedButton win;
    public PressedButton Win
    {
        get { return win; }
    }
    void Start()
    {
        Player.Instance.InitUIController(this);
    }
}
