using System;

namespace Test_Task
{
    public interface IModel
    {
        ButtonUpdate ButtonUpdate { get; }
        ILoadingFactory Factory { get; }
    }
}