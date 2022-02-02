using System.Collections.Generic;

namespace Test_Task
{
    public class Model : IModel
    {
        public ButtonUpdate ButtonUpdate { get; private set; }
        public ILoadingFactory Factory { get; private set; }
        public Model(ILoadingFactory loadingFactory)
        {
            ButtonUpdate = new ButtonUpdate();
            Factory = loadingFactory;
            ButtonUpdate.CancelClick += Factory.StopAllOperation;
            ButtonUpdate.UpdateClick += Factory.BildWeatherAsync;
            Factory.TaskEnded += ButtonUpdate.Refresh;
        }

    }
}
