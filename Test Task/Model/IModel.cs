using System;

namespace Test_Task
{
    public interface IModel
    {
        ButtonUpdate ButtonUpdate { get; }
        ILoader Factory { get; }
    }
}