using System;

namespace Test_Task
{
    public class ButtonUpdate
    {
        public event Action<string> ButtonClick;
        private enum ButtonType { Update, Cancel }
        private ButtonType buttonType = ButtonType.Update;
        public void Click()
        {
            if (buttonType == ButtonType.Update)
            {
                buttonType = ButtonType.Cancel;
                ButtonClick?.Invoke("Отмена");
            }
            else
            {
                Refresh();
            }
        }

        public void Refresh()
        {
            buttonType = ButtonType.Update;
            ButtonClick?.Invoke("Узнать погоду");
        }

    }
}