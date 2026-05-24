using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Control_UIController : MonoBehaviour
{
    private Button back;

    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        back = root.Q<Button>("Back");

        back.RegisterCallback<ClickEvent>(BackToMenu);
    }

    private void BackToMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
