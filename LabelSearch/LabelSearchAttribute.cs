using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ラベル名からアセットを検索し、アタッチします
/// </summary>
public class LabelSearchAttribute : PropertyAttribute
{

    /// <summary>
    /// <para> falseで検索が完了していなくても、とりあえずインスペクターを表示するようになる</para>
    /// <para>trueだと検索が終わるまでインスペクターが表示されない</para>
    /// </summary>
    public bool init = false;

    /// <summary>
    /// <para>インスペクターが表示された初回のみ検索が行われる</para>
    /// <para>falseだと検索が行われず描画されない</para>
    /// </summary>
    public bool search = true;

    /// <summary>
    /// <para>検索するラベル名</para>
    /// </summary>
    public string labelName;

    /// <summary>
    /// <para>インスペクターにラベル名を表示するかどうか</para>
    /// <para>trueで表示する</para>
    /// </summary>
    public bool canPrintLabelName = false;

    /// <summary>
    /// <para>配列の時に使用する</para>
    /// <para>インスペクターを表示した時、最初から配列のフィールドを描画したい場合trueにする</para>
    /// </summary>
    public bool foldout = false;

    /// <summary>
    /// <para>検索順が降順か昇順か</para>
    /// </summary>
    public Direction direction = Direction.ASC;

    /// <summary>
    /// <para>取得する最大数</para>
    /// <para>負や0を指定しても2147483647になる
    /// </summary>
    public int limit = 2147483647;

    /// <summary>
    /// <para>検索の高速化のためTypeをキャッシュしておく</para>
    /// </summary>
    public static Dictionary<string, System.Type> assetTypes = new Dictionary<string, System.Type> ();

    public LabelSearchAttribute (string labelName)
    {
        this.labelName = labelName;
    }

    public LabelSearchAttribute (string labelName, int limit)
    {
        if (Mathf.Sign (limit) == 1)
        {
            this.limit = limit;
        }

        this.labelName = labelName;
    }

    public LabelSearchAttribute (string labelName, Direction direction)
    {
        this.labelName = labelName;
        this.direction = direction;
    }

    public LabelSearchAttribute (string labelName, int limit, Direction direction)
    {
        this.labelName = labelName;

        if (Mathf.Sign (limit) == 1)
        {
            this.limit = limit;
        }

        this.direction = direction;
    }

    public enum Direction
    {
        ASC,
        DESC
    }
}
