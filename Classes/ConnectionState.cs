namespace HorizonREST.Classes
{

    public class ConnectionState : IDisposable
    {
        private static ConnectionState? s_state;

        private readonly object s_syncObject = new();

        private readonly Task _refreshTask;

        private readonly CancellationTokenSource _src = new();

        internal static ConnectionState Instance { get => s_state ??= new(); }

        public event Action<string>? OnRenewal;

        public static void Log(string message)
        {
            var dllPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dllDir = Path.GetDirectoryName(dllPath);
            var logPath = Path.Combine(dllDir, "horizonrest.log");
            File.AppendAllText(logPath, $"{DateTime.Now:u} {message}{Environment.NewLine}");
        }

        private ConnectionState()
        {
            Log("Connection State Started");
            _refreshTask = Task.Run(async () =>
            {
                while (!_src.IsCancellationRequested)
                {
                    await Task.Delay(60000);
                    await RenewAsync();
                }
            });
        }

        internal async Task RenewAsync()
        {
            OnRenewal?.Invoke("RenewAsync called");
            try
            {
                lock (s_syncObject)
                {
                    var lastAuth = AuthContainer.Instance.LastAuthResponse;
                    if (lastAuth != null)
                    {
                        HorizonREST.ApiClient.RefreshToken(
                            lastAuth.HorizonServer,
                            lastAuth.refresh_token
                        ).GetAwaiter().GetResult();

                        OnRenewal?.Invoke("Renewed");
                    }
                    else
                    {
                        OnRenewal?.Invoke("No LastAuthResponse in RenewAsync");
                    }
                }
            }
            catch (Exception ex)
            {
                OnRenewal?.Invoke($"Exception in RenewAsync: {ex}");
            }
        }

        internal void Disconnect()
        {
            _src.Cancel();
            _refreshTask.GetAwaiter().GetResult();
        }

        public void Dispose() => _src.Dispose();
    }
}
