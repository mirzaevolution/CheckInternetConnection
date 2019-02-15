namespace CheckInternetConnection
{
    public class InternetConnection
    {
        //Attribute ini digunakan untuk memanggil dll Win32 Api.
        //Didalam wininet.dll ini kita bisa memanggil Fungsi InternetGetConnectedState
        //untuk mengetahui status internet komputer/laptop kita.
        //Teknik ini dinamakan P/Invoke
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool IsConnected()
        {
            return InternetGetConnectedState(out int desc, 0);
        }
    }
}
