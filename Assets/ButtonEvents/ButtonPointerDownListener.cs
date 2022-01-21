/*--------------------------------------
   Email  : hamza95herbou@gmail.com
   Github : https://github.com/herbou
----------------------------------------*/

using UnityEngine ;
using UnityEngine.Events ;
using UnityEngine.EventSystems ;
using UnityEngine.UI ;

[RequireComponent (typeof(Button))]
public class ButtonPointerDownListener : MonoBehaviour,IPointerDownHandler {

   public UnityEvent onPointerDown ;

   private Button button ;

   private void Awake () {
      button = GetComponent<Button> () ;
   }

   public void OnPointerDown (PointerEventData eventData) {
      if (button.interactable && !object.ReferenceEquals (onPointerDown, null))
         onPointerDown.Invoke () ;
   }

}
