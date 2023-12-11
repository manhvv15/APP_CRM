
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Threading;

namespace AppCRM
{
    
    public class ConnectSocket
    {
        public SocketIO WIO;
        // Hàm Khởi tạo
        public ConnectSocket()
        {
            try
            {
                var uri = new Uri("http://43.239.223.142:3000/");
                WIO = new SocketIO(uri, new SocketIOOptions
                {
                    Reconnection = true,
                    Query = new Dictionary<string, string>
                    {
                        {"token", "V3" }
                    },
                }) ;
                var check = WIO.ConnectAsync();
            }
            catch (Exception ex)
            {
                //CheckError(ex.Message);
            }
        }
        // Emit dữ liệu
        public void UserDisconnect(string userId)
        {
            try
            {
                WIO.EmitAsync("CRMJoin", userId);
            }
            catch (Exception ex)
            {

            }
        }
        public void LoginSuccess(int userId, int companyId, string fromWeb)
        {
            try
            {
                WIO.EmitAsync("Login", userId, "CRM");
                if (fromWeb != "CRM") WIO.EmitAsync("Login", userId, fromWeb);
            }
            catch (Exception ex)
            {

            }
        }
    }

}
