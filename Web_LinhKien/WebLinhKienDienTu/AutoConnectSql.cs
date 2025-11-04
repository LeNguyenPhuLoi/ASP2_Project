using System.Net;
using System.Data.SqlClient;

namespace WebLinhKienDienTu
{
    public class AutoConnectSql
    {
        private string connectionString;
        private readonly string cachePath = "last_instance.txt";

        public AutoConnectSql()
        {
            //Thử instance được lưu lần trước
            if (TryLoadCachedInstance())
                return;

            //Dò tự động các instance khả dụng
            var host = Dns.GetHostName();
            var instanceOptions = new List<string> { ".", host };

            var registryView = Environment.Is64BitOperatingSystem
                ? Microsoft.Win32.RegistryView.Registry64
                : Microsoft.Win32.RegistryView.Registry32;

            using (var hklm = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, registryView))
            {
                var instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        instanceOptions.Add(host + "\\" + instanceName);
                    }
                }
            }

            //Thử song song các instance
            connectionString = instanceOptions
                .AsParallel()
                .Select(instance => new
                {
                    Instance = instance,
                    Connection = $"Data Source={instance};Initial Catalog=QLLK;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=2;"
                })
                .FirstOrDefault(x => TestConnection(x.Connection))?.Connection;

            //Nếu kết nối thành công, lưu cache
            if (connectionString != null)
            {
                var instanceName = instanceOptions.FirstOrDefault(i => connectionString.Contains(i));
                if (instanceName != null)
                    File.WriteAllText(cachePath, instanceName);
            }
        }

        //Hàm thử instance được lưu
        private bool TryLoadCachedInstance()
        {
            if (!File.Exists(cachePath))
                return false;

            var cachedInstance = File.ReadAllText(cachePath);
            var testConn = $"Data Source={cachedInstance};Initial Catalog=QLLK;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=2;";
            if (TestConnection(testConn))
            {
                connectionString = testConn;
                return true;
            }
            return false;
        }

        //hàm trả về chuỗi kết nối
        public string GetConnection()
        {
            return connectionString;
        }

        //hàm kiểm tra kết nối
        private bool TestConnection(string connStr)
        {
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
