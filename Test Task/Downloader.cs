using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test_Task
{
    public class Downloader
    {
        public enum ButtonType { Update, Cancel }
        public ButtonType CurrentButtonType { get; private set; }

        private List<CancellationTokenSource> tokens = new List<CancellationTokenSource>();

        public Downloader()
        {

        }

        public async Task<string> StartAsync(ITextLoader loader)
        {
            CurrentButtonType = ButtonType.Cancel;
            var token = new CancellationTokenSource();
            tokens.Add(token);
            return await loader.GetDataAsync(token);
        }

        public void Stop()
        {
            CurrentButtonType = ButtonType.Update;
            foreach (var token in tokens)
            {
                token?.Cancel();
            }

            tokens.Clear();
        }
    }
}
