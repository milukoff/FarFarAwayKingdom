using Newtonsoft.Json;
using Resurces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emulatorCasketWish
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            AppSettings.LoadSettings();
            InitializeComponent();
        }

        private void GetStatus_Click(object sender, EventArgs e)
        {
            InfoLabel.Text = "";
            if (AppSettings.ServiceControl.XMLParametrsFound)
            {
                string UriString = @"http://" + AppSettings.EmulatorCasketWishParams.URLAdress + @"/" + "api" + @"/" + AppSettings.EmulatorCasketWishParams.ApiMetod + "." + AppSettings.EmulatorCasketWishParams.ApiExtension;
                string ErrorMessage = null;
                ResponseStatus responseStatus = WebApiClient.GetStatus(UriString, out ErrorMessage);
                if (string.IsNullOrEmpty(ErrorMessage))
                {
                    if (responseStatus!=null)
                    {
                        if (Statuses.StatusesDictionary.ContainsKey(responseStatus.Status))
                        {
                            InfoLabel.Text = Statuses.StatusesDictionary[responseStatus.Status];
                        }
                        else InfoLabel.Text = "Неизвестный статус";
                        if (responseStatus.Date!=DateTime.MinValue)
                        {
                            InfoLabel.Text += " " + responseStatus.Date.Date.ToShortDateString();
                        }
                    }
                }
                else
                {
                    InfoLabel.Text = ErrorMessage;
                }
            }

        }
    }
}
