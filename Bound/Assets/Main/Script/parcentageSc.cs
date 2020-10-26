using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class parcentageSc : MonoBehaviour
{
    private PaintTarget ptSc;
    public GameObject score_object = null; 
    public GameObject obj;
    [SerializeField] private int stage;
    private GameObject[] result;
    private GameObject[] title;
    private GameObject[] game;

    public Button button;

    public Text score_text;


    private bool sceneFlag = false;
    public bool SceneFlag
    {
        get { return sceneFlag; }
    }

    //private float peac = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnNextScene);
        ptSc = obj.GetComponent<PaintTarget>();
        game = GameObject.FindGameObjectsWithTag("Game");
        result = GameObject.FindGameObjectsWithTag("Result");
        for (int i = 0; i < result.Length; i++)
            result[i].SetActive(false);

        for (int i = 0; i < game.Length; i++)
            game[i].SetActive(false);

        title = GameObject.FindGameObjectsWithTag("Title");

        score_text = score_object.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //peac = (ptSc.PaintCount / (32.0f * 32.0f));
        // オブジェクトからTextコンポーネントを取得
        // テキストの表示を入れ替える
        score_text.text = (int)ptSc.Per + "%";
        if (ptSc.Per > 100)
        {
            for (int i = 0; i < result.Length; i++)
                result[i].SetActive(true);
        }

        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < title.Length; i++)
                title[i].SetActive(false);
            for (int i = 0; i <game.Length; i++)
                game[i].SetActive(true);
        }
    }

    public void OnNextScene()
    {
        SceneManager.LoadScene("Stage" + stage);
    }
}
