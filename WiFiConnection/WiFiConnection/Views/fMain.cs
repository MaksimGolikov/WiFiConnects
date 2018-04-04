using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiFiConnection.Presenter;


namespace WiFiConnection
{
    public partial class Form1 : Form
    {

        Presenter.fMainPresenter presenter;

        public Form1()
        {
            InitializeComponent();
        }

        #region Top menu
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void refreshPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.GetListOfAvaliablePoints();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void finishToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

#endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            lb_WiFiConnectState.Text = "";
            presenter = new fMainPresenter(this);
            presenter.GetListOfAvaliablePoints();
        }

        private void bn_ConnectToWifi_Click(object sender, EventArgs e)
        {
            ListViewItem select = lView_wifiConnects.SelectedItems[0];
            presenter.ConnectedToWiFi(select, tb_PasswordToSelectedWiFi.Text);
        }

        private void lView_wifiConnects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem select = lView_wifiConnects.SelectedItems[0];
            tb_nameSelectedWiFi.Text = select.Text;
        }













        public void ShowMessage(string text)
        {
            if (text.Length > 0) {
                MessageBox.Show(text);
            }
        }

        public void FillWifiPoints(List<ListViewItem> list)
        {
            lView_wifiConnects.Items.Clear();
            if (list.Count > 0)
            {                
                for (int i = 0; i < list.Count; i++)
                {
                    lView_wifiConnects.Items.Add(list[i]);
                }
            }
        }

        public void ChangeWiFiState(bool isConnected)
        {
            if (isConnected)
            {
                lb_WiFiConnectState.Text = "Connected";
                lb_WiFiConnectState.ForeColor = Color.Red;
                bn_ConnectToWifi.Text = "Disconnect";
            }
            else
            {
                lb_WiFiConnectState.Text = "Not connected";
                lb_WiFiConnectState.ForeColor = Color.Black;
                bn_ConnectToWifi.Text = "Connect";
            }
        }

        
    }
}
