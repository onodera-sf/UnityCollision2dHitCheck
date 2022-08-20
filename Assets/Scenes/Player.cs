using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	/// <summary>状態表示用テキストオブジェクト。</summary>
	[SerializeField] private Text TextState;


	// 一定時間ごとに呼ばれます
	void FixedUpdate()
	{
		// キーボードの情報を取得
		var keyboard = Keyboard.current;
		if (keyboard == null)
		{
			Debug.Log("キーボードがありません。");
			return;
		}

		// スプライトの移動処理
		// Translate メソッドでスプライトの位置が移動します
		// Space.World を指定すると回転の影響をうけません
		if (keyboard.leftArrowKey.isPressed)
		{
			transform.Translate(-0.1f, 0, 0, Space.World);
		}
		if (keyboard.rightArrowKey.isPressed)
		{
			transform.Translate(0.1f, 0, 0, Space.World);
		}
		if (keyboard.upArrowKey.isPressed)
		{
			transform.Translate(0, 0.1f, 0, Space.World);
		}
		if (keyboard.downArrowKey.isPressed)
		{
			transform.Translate(0, -0.1f, 0, Space.World);
		}
	}

	/// <summary>衝突した瞬間に呼ばれます。</summary>
	/// <param name="partner">衝突した相手のコリジョン情報。</param>
	private void OnTriggerEnter2D(Collider2D partner)
	{
		TextState.text = $"OnTriggerEnter2D : {partner.tag} {DateTime.Now:HH:mm:ss.fff}{Environment.NewLine}{TextState.text}";
	}

	/// <summary>衝突している間呼ばれます。ただしスリープモードになった場合は呼ばれません。</summary>
	/// <param name="partner">衝突した相手のコリジョン情報。</param>
	private void OnTriggerStay2D(Collider2D partner)
	{
		TextState.text = $"OnTriggerStay2D : {partner.tag} {DateTime.Now:HH:mm:ss.fff}{Environment.NewLine}{TextState.text}";
	}

	/// <summary>衝突状態でなくなったタイミングで呼ばれます。</summary>
	/// <param name="partner">衝突した相手のコリジョン情報。</param>
	private void OnTriggerExit2D(Collider2D partner)
	{
		TextState.text = $"OnTriggerExit2D : {partner.tag} {DateTime.Now:HH:mm:ss.fff}{Environment.NewLine}{TextState.text}";
	}
}
