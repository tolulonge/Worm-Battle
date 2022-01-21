/*--------------------------------------
   Email  : hamza95herbou@gmail.com
   Github : https://github.com/herbou
----------------------------------------*/

using UnityEngine ;
using UnityEngine.Events ;
using UnityEngine.EventSystems ;
using UnityEngine.UI ;

[RequireComponent (typeof(Button))]
public class ButtonPointerUpListener : MonoBehaviour,IPointerUpHandler {

   public UnityEvent onPointerUp ;

   private Button button ;

   private void Awake () {
      button = GetComponent<Button> () ;
   }

   public void OnPointerUp (PointerEventData eventData) {
      if (button.interactable && !object.ReferenceEquals (onPointerUp, null))
         onPointerUp.Invoke () ;
   }

}