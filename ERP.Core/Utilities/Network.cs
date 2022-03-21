﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace ERP.Core.Utilities
{
    public class Network
    {

        public static string GetIPAddress()
        {
            System.Net.IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            string IpAddress = Convert.ToString(ipHostInfo.AddressList[1]);

            return IpAddress;
         }

        public static string GetMACAddress()
        {
            string MacAddress = "";
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            MacAddress = Convert.ToString(nics[0].GetPhysicalAddress());

            return MacAddress;
        }
    }
}
