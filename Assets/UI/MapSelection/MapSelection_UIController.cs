using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MapSelection_UIController : MonoBehaviour
{
    private VisualElement fadeLayer;

    private Button back;
    private Button mars;
    private Button earth;
    private Button jupiter;

    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        fadeLayer = root.Q<VisualElement>("FadeLayer");

        back = root.Q<Button>("Back");

        mars = root.Q<Button>("MarsButton");
        earth = root.Q<Button>("EarthButton");
        jupiter = root.Q<Button>("JupiterButton");

        fadeLayer.style.display = DisplayStyle.None;
        fadeLayer.RemoveFromClassList("AfterFading");

        back.RegisterCallback<ClickEvent>(BackToMenu);

        mars.RegisterCallback<ClickEvent>(PlayMars);
        earth.RegisterCallback<ClickEvent>(PlayEarth);
        jupiter.RegisterCallback<ClickEvent>(PlayJupiter);
    }

    private void BackToMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void PlayMars(ClickEvent evt)
    {
        mapData.mapID = 0;
        Fade();
    }

    private void PlayEarth(ClickEvent evt)
    {
        mapData.mapID = 1;
        Fade();
    }

    private void PlayJupiter(ClickEvent evt)
    {
        mapData.mapID = 2;
        Fade();
    }

    private void Fade()
    {
        fadeLayer.style.display = DisplayStyle.Flex;
        fadeLayer.AddToClassList("AfterFading");
        Invoke("LoadMap", 0.5f);
    }

    private void LoadMap()
    {
        SceneManager.LoadScene("Planet");
    }
}
