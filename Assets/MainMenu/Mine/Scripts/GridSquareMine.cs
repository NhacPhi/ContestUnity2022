using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MiniGames.Mine
{
    public class GridSquareMine : MonoBehaviour
    {
        public Image normalImage;

        public Image hooverImage;

        public Image activeImage;

        public Image preditionImage;

        public Image ErrorImage;

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
            if (!selected)
            {
                hooverImage.gameObject.SetActive(true);
                normalImage.gameObject.SetActive(false);
            }
        }
        private void OnMouseOver()
        {
            if (!selected)
            {
                hooverImage.gameObject.SetActive(true);
                normalImage.gameObject.SetActive(false);
            }
        }
        private void OnMouseExit()
        {
            if (!selected)
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
            canActive = false;


            //SquareOccupied = true;
        }
        public void ActiveErrorSquare()
        {
            hooverImage.gameObject.SetActive(false);
            ErrorImage.gameObject.SetActive(true);
        }
        private void OnMouseDown()
        {
            if(GameMine.Instance.isCanSelect)
            {
                GameMine.Instance.currentIndex = squareIndex;
                if (!selected && canActive)
                {
                    GameEvetMine.CheckGameOver();
                    if (GameMine.Instance.isChooseCorrect)
                    {
                        ActiveSquare();
                    }
                    else
                    {
                        ActiveErrorSquare();
                    }

                }


                //Game.Instance.gridIndexCurrent = squareIndex;
            }
        }
    }

}
