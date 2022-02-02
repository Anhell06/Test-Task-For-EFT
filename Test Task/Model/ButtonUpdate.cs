using System;

namespace Test_Task
{
    public class ButtonUpdate
    {
        public event Action<string> ButtonTextChange;
        public event Action UpdateClick;
        public event Action CancelClick;
        public enum ButtonType { Update, Cancel }
        private ButtonType buttonType = ButtonType.Update;
        public void Click()
        {
            if (buttonType == ButtonType.Update)
            {
                buttonType = ButtonType.Cancel;
                ButtonTextChange?.Invoke("Отмена");
                UpdateClick?.Invoke();
                
            }
            else
            {
                Refresh();
                CancelClick?.Invoke();
            }
        }

        public void Refresh()
        {
            buttonType = ButtonType.Update;
            ButtonTextChange?.Invoke("Узнать погоду");
        }

    }
}