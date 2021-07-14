using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PassiveObject : MonoBehaviour, IIgnitable
{
	// ����
	[SerializeField] private UnityEvent Ignished = new UnityEvent();
	// ����
	[SerializeField] private UnityEvent FireExtinguishing = new UnityEvent();

	public void Ignition()
	{
		Debug.Log("PassiveObject -> Fire");
		Ignished.Invoke();
		// ���W
		// �A�j���[�V�����̃g���K�[
		// �T�E���h�̃g���K�[
		// �G�t�F�N�g�̃g���K�[
		// �����E���Z�n
	}
}
