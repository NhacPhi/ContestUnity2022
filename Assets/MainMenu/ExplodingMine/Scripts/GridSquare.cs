using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.ExplodingMine
{
    public class GridSquare : MonoBehaviour
    {
        public Image normalImage;

        public Image hooverImage;

        public Image activeImage;

        public Image preditionImage;

        public Image destinationImage;

        public List<Sprite> normalImages;

        public int squareIndex { get; set; }

        public bool selected { get; set; }

        public bool canActive { get; set; }
        // Start is called before the first frame update
        void Start()
        {
            selected = false;

            canActive = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void SetImage(bool setFirstImage)
        {
            normalImage.GetComponent<Image>().sprite = setFirstImage ? normalImages[1] : normalImages[0];
        }
        private void OnMouseEnter()
        {
            if(!selected)
            {
                hooverImage.gameObject.SetActive(true);
                normalImage.gameObject.SetActive(false);
            }
        }
        private void OnMouseOver()
        {
            if(!selected)
            {
                hooverImage.gameObject.SetActive(true);
                normalImage.gameObject.SetActive(false);
            }
        }
        private void OnMouseExit()
        {
            if(!selected)
            {
                hooverImage.gameObject.SetActive(false);
                normalImage.gameObject.SetActive(true);
            }
        }

        public void ActiveSquare()
        {
            hooverImage.gameObject.SetActive(false);
            activeImage.gameObject.SetActive(true);

            selected = true;
            //SquareOccupied = true;
        }
        public void SetDestinationImage()
        {
            hooverImage.gameObject.SetActive(false);
            destinationImage.gameObject.SetActive(true);
        }
        private void ActiveSquareIncorrect()
        {
            hooverImage.gameObject.SetActive(false);
            destinationImage.gameObject.SetActive(true);
        }
        private void OnMouseDown()
        {
            Debug.Log("Mouse Down");
            if(/*Game.Instance.currentState != GameState.GAME_OVER &&*/ Game.Instance.currentState == GameState.INGAME)
            {
                Debug.Log("Mouse Down 1");
                if (!selected && canActive)
                {
                    Game.Instance.gridIndexCurrent = squareIndex;
                    GameEvent.GameOver();
                    if (Game.Instance.isChooseCorrect)
                    {
                        ActiveSquare();
                        if (Game.Instance.gridIndexCurrent != 0)
                        {
                            GameEvent.ChooseSquare();
                        }
                    }
                    else
                    {
                        ActiveSquareIncorrect();
                    }

                }
            }

        }
    }
}

