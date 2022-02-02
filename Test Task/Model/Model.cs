using System.Collections.Generic;

namespace Test_Task
{
    public class Model : IModel
    {
        public ButtonUpdate ButtonUpdate { get; private set; }
        public ILoader Factory { get; private set; }
        public Model(ILoader loadingFactory)
        {
            ButtonUpdate = new ButtonUpdate();
            Factory = loadingFactory;
            ButtonUpdate.CancelClick += Factory.StopAllOperation;
            ButtonUpdate.UpdateClick += Factory.BildWeatherAsync;
            Factory.TaskEnded += ButtonUpdate.Refresh;
        }

    }
}
