using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text mainText;
    [SerializeField]
    private Text nameText;
    
    // パラメーターを追加
    private const char SEPARATE_MAIN_START = '「';
    private const char SEPARATE_MAIN_END = '」';

    private Queue<char> _charQueue;


    // パラメーターを変更
    private string _text = "みにに「Hello,World!」";

    
    // MonoBehaviourを継承している場合限定で
    // 最初の更新関数(Updateメソッド)が呼ばれる時に最初に呼ばれる
    private void Start()
    {
        // Main Textに指定したTextコンポーネントの
        // テキストのパラメーターに代入する
        ReadLine(_text);
        OutputChar();
    }
    private Queue<char> SeparateString(string str)
    {
   // 文字列をchar型の配列にする = 1文字ごとに区切る
   char[] chars = str.ToCharArray();
   Queue<char> charQueue = new Queue<char>();
   // foreach文で配列charsに格納された文字を全て取り出し
   // キューに加える
   foreach (char c in chars) charQueue.Enqueue(c);
   return charQueue;
    }
    private void OutputChar()
    {
   // キューから値を取り出し、キュー内からは削除する
   mainText.text += _charQueue.Dequeue();
    }

    // Start is called before the first frame update
    private void ReadLine(string text)
    {
        // '「'の位置で文字列を分ける
        string[] ts = text.Split(SEPARATE_MAIN_START);
        // 分けたときの最初の値、つまり"みにに"が代入される
        string name = ts[0];
        // 分けたときの次の値、つまり"Hello,World!」"が代入されるので
        // 最後の閉じ括弧を削除して代入(="Hello,World!")
        string main = ts[1].Remove(ts[1].LastIndexOf(SEPARATE_MAIN_END));
        nameText.text = name;
        mainText.text = "";
        _charQueue = SeparateString(main);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
