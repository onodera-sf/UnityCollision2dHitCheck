using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	/// <summary>��ԕ\���p�e�L�X�g�I�u�W�F�N�g�B</summary>
	[SerializeField] private Text TextState;


	// ��莞�Ԃ��ƂɌĂ΂�܂�
	void FixedUpdate()
	{
		// �L�[�{�[�h�̏����擾
		var keyboard = Keyboard.current;
		if (keyboard == null)
		{
			Debug.Log("�L�[�{�[�h������܂���B");
			return;
		}

		// �X�v���C�g�̈ړ�����
		// Translate ���\�b�h�ŃX�v���C�g�̈ʒu���ړ����܂�
		// Space.World ���w�肷��Ɖ�]�̉e���������܂���
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

	/// <summary>�Փ˂����u�ԂɌĂ΂�܂��B</summary>
	/// <param name="partner">�Փ˂�������̃R���W�������B</param>
	private void OnTriggerEnter2D(Collider2D partner)
	{
		TextState.text = $"OnTriggerEnter2D : {partner.tag} {DateTime.Now:HH:mm:ss.fff}{Environment.NewLine}{TextState.text}";
	}

	/// <summary>�Փ˂��Ă���ԌĂ΂�܂��B�������X���[�v���[�h�ɂȂ����ꍇ�͌Ă΂�܂���B</summary>
	/// <param name="partner">�Փ˂�������̃R���W�������B</param>
	private void OnTriggerStay2D(Collider2D partner)
	{
		TextState.text = $"OnTriggerStay2D : {partner.tag} {DateTime.Now:HH:mm:ss.fff}{Environment.NewLine}{TextState.text}";
	}

	/// <summary>�Փˏ�ԂłȂ��Ȃ����^�C�~���O�ŌĂ΂�܂��B</summary>
	/// <param name="partner">�Փ˂�������̃R���W�������B</param>
	private void OnTriggerExit2D(Collider2D partner)
	{
		TextState.text = $"OnTriggerExit2D : {partner.tag} {DateTime.Now:HH:mm:ss.fff}{Environment.NewLine}{TextState.text}";
	}
}
