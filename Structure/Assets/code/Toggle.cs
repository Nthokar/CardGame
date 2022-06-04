using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.code
{
	public class Toggle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField]
		GameObject ToggleWindow;
		public void OnPointerEnter(PointerEventData eventData)
		{
			ToggleWindow.GetComponent<Image>().color = Color.white;
			ToggleWindow.GetComponentInChildren<Text>().color = Color.white;
		}
		public void OnPointerExit(PointerEventData eventData)
		{
			ToggleWindow.GetComponent<Image>().color = new Color(1, 1, 1, 0);
			ToggleWindow.GetComponentInChildren<Text>().color = new Color(1, 1, 1, 0);

		}
	}
}
