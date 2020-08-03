using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.Modules.SimpleUIOnNOff {
	public class SimpleDialogueViewer : MonoBehaviour {
		public UnityEngine.UI.Text speaker;
		public UnityEngine.UI.Text chat;
		public SimpleUIOnNOff DialogueControl;

		private Queue<Chat> ChatQueue = new Queue<Chat>();
		private bool isDialogueOn;

		public void SetDialogue(string Speaker, string Chat) {
			ChatQueue.Enqueue(new Chat(Speaker, Chat));
			if (!isDialogueOn) {
				StartDialogue();
			}
		}

		private void StartDialogue() {
			isDialogueOn = true;
			// Action of turning on the dialogue
			DialogueControl.Activate(isDialogueOn);

			NextDialogue();
		}

		private void NextDialogue() {
			if(ChatQueue.Count > 0) {
				Chat n = ChatQueue.Dequeue();
				speaker.text = n.Speaker;
				chat.text = n.Dialogue;
			} else {
				EndDialogue();
			}
		}

		private void EndDialogue() {
			isDialogueOn = false;
			// Action of turning off the dialogue
			DialogueControl.Activate(isDialogueOn);
		}

		private void Update() {
			if (isDialogueOn && Input.GetMouseButtonDown(0)) {
				NextDialogue();
			}
		}

		public class Chat {
			public string Speaker;
			public string Dialogue;

			public Chat(string Speaker, string Dialogue) {
				this.Speaker = Speaker;
				this.Dialogue = Dialogue;
			}
		}
	}
}