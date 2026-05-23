using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class inGame_UIController : MonoBehaviour
{
    [Header("OutScript")]
    public Player1 player1;
    public Player2 player2;

    private Label leftAngle;
    private Label rightAngle;

    private Label score;

    private VisualElement fadeLayer;
    private VisualElement winningMessage;
    private VisualElement back;
    private Label youWin;
    private Button quit;
    private Button backToMenu;

    private float alpha = 1f;
    private bool start = true;
    private bool end = false;
    private bool stop = false;

    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        // angle
        leftAngle = root.Q<Label>("LeftAngle");
        rightAngle = root.Q<Label>("RightAngle");

        // score
        score = root.Q<Label>("ScoreBoard");

        // fade
        fadeLayer = root.Q<VisualElement>("FadeLayer");

        // quit
        quit = root.Q<Button>("Quit");
        quit.RegisterCallback<ClickEvent>(Fade);

        // win
        winningMessage = root.Q<VisualElement>("WinningMessage");

        winningMessage.style.display = DisplayStyle.None;
        winningMessage.RemoveFromClassList("AfterMessage");
        youWin = root.Q<Label>("YouWin");

        // back
        back = root.Q<VisualElement>("Back");

        back.style.display = DisplayStyle.None;

        // back to menu
        backToMenu = root.Q<Button>("BackToMenu");
        backToMenu.RegisterCallback<ClickEvent>(Fade);

        // start fade
        fadeLayer.style.display = DisplayStyle.Flex;
    }

    private void Update()
    {
        // fade out
        if (alpha > 0 && start)
        {
            alpha -= Time.deltaTime * 4;

            fadeLayer.style.opacity = alpha;
        }
        else if(start)
        {
            fadeLayer.style.display = DisplayStyle.None;
            start = false;
        }

        // fade out
        if (alpha < 1 && end)
        {
            alpha += Time.deltaTime * 4;

            fadeLayer.style.opacity = alpha;
        }

        // angle
        float angle1 = player1.angle % 180f;
        float angle2 = (180f - player2.angle) % 180f;

        leftAngle.text = "Angle : " + angle1.ToString("F2");
        rightAngle.text = "Angle : " +  angle2.ToString("F2");

        // score
        if(!stop)
            score.text = mapData.leftScore.ToString() + " : " + mapData.rightScore.ToString();

        if(mapData.leftScore == 3 && !stop)
        {
            youWin.text = "Left Win";
            stop = true;
            Invoke("Win", 0.7f);
        }
        else if(mapData.rightScore == 3 && !stop)
        {
            youWin.text = "Right Win";
            stop = true;
            Invoke("Win", 0.7f);
        }
    }

    private void Fade(ClickEvent evt)
    {
        fadeLayer.style.display = DisplayStyle.Flex;
        end = true;
        Invoke("LoadMenu", 0.7f);
    }

    private void Win()
    {
        winningMessage.style.display = DisplayStyle.Flex;
        winningMessage.AddToClassList("AfterMessage");

        Invoke("VisualizeButton", 2f);
    }

    private void VisualizeButton()
    {
        back.style.display = DisplayStyle.Flex;
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
