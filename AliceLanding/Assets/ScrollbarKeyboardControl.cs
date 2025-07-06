using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ScrollbarKeyboardControl : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public ScrollRect scrollRect;
    public float pixelStep = 80f; // 每次按鍵移動的像素數
    [SerializeField] GameObject upButton;
    [SerializeField] GameObject downButton;
    private float Timer = 0f;
    bool upClick = false;
    bool downClick = false;
    [SerializeField] AudioSource click;
    [SerializeField] AudioSource scrolling;
    [SerializeField] AudioSource singlescrolling;
    bool scrollrolling = false;
    private bool isPressing = false;
    private Vector2 pos;
    
    void Awake()
    {
        if (scrollRect != null)
        {
            pos = scrollRect.content.anchoredPosition;
        }

    }


    IEnumerator SimulateClick(GameObject button)
    {
        
        PointerEventData data = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute<IPointerDownHandler>(button, data, ExecuteEvents.pointerDownHandler);
        yield return new WaitForSeconds(0.3f); // 等待0.3秒
        ExecuteEvents.Execute<IPointerUpHandler>(button, data, ExecuteEvents.pointerUpHandler);
    }

    public void UpButtonDown()
    {
        
        upClick = true;
        pos.y -= pixelStep;
        scrollRect.content.anchoredPosition = pos;
        if (!isPressing)
        {
            click.Play();
        }
        isPressing = true;
    }

    public void UpButtonUp()
    {
        upClick = false;
        scrollrolling = false;
        scrolling.Stop();
        Timer = 0;

    }

    public void DownButtonDown()
    {
        downClick = true;
        pos.y += pixelStep;
        scrollRect.content.anchoredPosition = pos;
        if (!isPressing)
        {
            click.Play();
            
        }
        isPressing = true;
    }

    public void DownButtonUp()
    {
        downClick = false;
        scrollrolling = false;
        scrolling.Stop();
        Timer = 0;
    }


    

    public void OnPointerDown(PointerEventData eventData)
    {
        // 空實作，必要時可以根據目標物件判斷誰被按下
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 空實作，必要時可以根據目標物件判斷誰被放開
    }


    void Update()
    {
        
        float scroll = Input.GetAxis("Mouse ScrollWheel");


        if (scroll > 0f  && upButton != null) // 向上滾動
        {
            pos.y -= pixelStep;
            scrollRect.content.anchoredPosition = pos;



            if (!singlescrolling.isPlaying)
            {
                singlescrolling.Play();
            }
            

        }
        if (scroll < 0f && downButton != null) // 向下滾動
        {
            pos.y += pixelStep;
            scrollRect.content.anchoredPosition = pos;
            if (!singlescrolling.isPlaying)
            {
                singlescrolling.Play();
            }



        }

            
        



        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && downButton != null)
        {
            click.Play();
            PointerEventData data = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute<IPointerDownHandler>(downButton, data, ExecuteEvents.pointerDownHandler);
      
        }

        if (Input.GetKeyUp(KeyCode.S)|| Input.GetKeyUp(KeyCode.DownArrow))
        {
            // 模擬放開
            
            PointerEventData data = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute<IPointerUpHandler>(downButton, data, ExecuteEvents.pointerUpHandler);
            

        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))&& upButton != null)
        {
            click.Play();
            // 模擬按下狀態
            PointerEventData data = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute<IPointerDownHandler>(upButton, data, ExecuteEvents.pointerDownHandler);

            
        }

        if (Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.UpArrow))
        {
            // 模擬放開
            
            PointerEventData data = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute<IPointerUpHandler>(upButton, data, ExecuteEvents.pointerUpHandler);
            

            
        }

        if ((Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)||downClick) && downButton != null)
        {
            Timer += Time.deltaTime;
            if (Timer >= 0.5f)
            {
                pos.y += pixelStep * 0.1f;
                scrollRect.content.anchoredPosition = pos;
                if (!scrollrolling)
                {
                    scrolling.Play();
                    scrollrolling = true;                   

                }



                
            }

            
        }
        if ((Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)||upClick) && upButton != null)
        {
            Timer += Time.deltaTime;
            if (Timer >= 0.5f)
            {
                pos.y -= pixelStep * 0.1f;
                scrollRect.content.anchoredPosition = pos;
                if (!scrollrolling)
                {
                    scrolling.Play();
                    scrollrolling = true;                   

                }
            }
            
        }








    }
    
     
}