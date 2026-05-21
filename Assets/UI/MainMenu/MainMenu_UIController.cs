using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu_UIController : MonoBehaviour
{
    private VisualElement fadeLayer;

    private Button play;
    private Button description;
    private Button quit;

    private float alpha = 1f;

    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        fadeLayer = root.Q<VisualElement>("FadeLayer");

        play = root.Q<Button>("Play");
        description = root.Q<Button>("Description");
        quit = root.Q<Button>("Quit");

        play.RegisterCallback<ClickEvent>(Play);
        description.RegisterCallback<ClickEvent>(Description);
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

    private void Description(ClickEvent evt)
    {
        Debug.Log("ddd");
    }

    private void Quit(ClickEvent evt)
    {
        Application.Quit();
    }
}
