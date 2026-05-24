using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu_UIController : MonoBehaviour
{
    private VisualElement fadeLayer;

    private Button play;
    private Button control;
    private Button quit;

    private float alpha = 1f;

    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        fadeLayer = root.Q<VisualElement>("FadeLayer");

        play = root.Q<Button>("Play");
        control = root.Q<Button>("Control");
        quit = root.Q<Button>("Quit");

        play.RegisterCallback<ClickEvent>(Play);
        control.RegisterCallback<ClickEvent>(Control);
        quit.RegisterCallback<ClickEvent>(Quit);

        fadeLayer.style.display = DisplayStyle.Flex;
    }

    private void Update()
    {
        if (alpha > 0)
        {
            alpha -= Time.deltaTime * 4;

            fadeLayer.style.opacity = alpha;
        }
        else
        {
            fadeLayer.style.display = DisplayStyle.None;
        }
    }

    private void Play(ClickEvent evt)
    {
        SceneManager.LoadScene("MapSelection");
    }

    private void Control(ClickEvent evt)
    {
        SceneManager.LoadScene("Control");
    }

    private void Quit(ClickEvent evt)
    {
        Application.Quit();
    }
}
