using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu_UIController : MonoBehaviour
{
    private Button play;
    private Button description;
    private Button quit;

    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        play = root.Q<Button>("Play");
        description = root.Q<Button>("Description");
        quit = root.Q<Button>("Quit");

        play.RegisterCallback<ClickEvent>(Play);
        description.RegisterCallback<ClickEvent>(Description);
        quit.RegisterCallback<ClickEvent>(Quit);
    }

    private void Play(ClickEvent evt)
    {
        Debug.Log("ppp");
    }

    private void Description(ClickEvent evt)
    {
        Debug.Log("ddd");
    }

    private void Quit(ClickEvent evt)
    {
        Debug.Log("qqq");
    }
}
