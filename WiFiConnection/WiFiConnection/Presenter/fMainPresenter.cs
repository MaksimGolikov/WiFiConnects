using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWifi;



namespace WiFiConnection.Presenter
{
    class fMainPresenter
    {

        WiFiConnection.Form1 form;
        Wifi wifiConnect;

        
        public fMainPresenter(WiFiConnection.Form1 newForm)
        {
            this.form = newForm;
            this.wifiConnect = new Wifi();            
        }



        public void GetListOfAvaliablePoints()
        {
            try
            {
                var avaliablePionts = wifiConnect.GetAccessPoints();
                var lViewItem = new List<System.Windows.Forms.ListViewItem>();

                foreach (var point in avaliablePionts)
                {
                    System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(point.Name);
                    item.SubItems.Add(point.SignalStrength + " %");
                    item.Tag = point;

                    lViewItem.Add(item);
                }
                if (lViewItem.Count > 0)
                {
                    this.form.FillWifiPoints(lViewItem);
                }
                else
                {
                    this.form.FillWifiPoints(lViewItem);
                    this.form.ShowMessage("WiFi points not found");
                }
            }
            catch
            {
                this.form.ShowMessage("WiFi reciever not work. Please turn it on and try again");
            }
                     
        }

        public void ConnectedToWiFi(System.Windows.Forms.ListViewItem name, string password)
        {
            if (password.Length > 0)
            {
                if (wifiConnect.ConnectionStatus == WifiStatus.Disconnected)
                {
                    AccessPoint point = (AccessPoint)name.Tag;
                    AuthRequest request = new AuthRequest(point);
                    request.Password = password;
                    
                    if (point.Connect(request))
                    {
                        this.form.ChangeWiFiState(true);
                    }
                    else
                    {
                        this.form.ShowMessage("Failed. Check password");
                    }
                }
                else
                {
                    wifiConnect.Disconnect();
                    this.form.ChangeWiFiState(false);
                }
                
            }    
        }


    }
}
