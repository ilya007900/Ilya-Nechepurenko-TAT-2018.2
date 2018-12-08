using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task2
{
    /// <summary>
    /// Provides methods to gets IPs from string
    /// </summary>
    class IPGetter
    {
        string StringToHandle { get; set; }
        int CurrentPosition { get; set; }
        int PointPosition { get; set; }
        List<string> IPs { get; set; }

        /// <summary>
        /// Gets part of ip before point
        /// </summary>
        /// <returns>Part of ip</returns>
        private byte? GetBeforePoint()
        {
            StringBuilder ipPart = new StringBuilder(3);
            for (int i = PointPosition - 1, j = 0; i >= 0 && j < 3; i--, j++)
            {
                if (char.IsDigit(StringToHandle[i]))
                {
                    ipPart.Append(StringToHandle[i]);
                }
                else
                {
                    break;
                }
            }
            if (ipPart.Length == 0)
            {
                return null;
            }
            for (int i = 0; i < ipPart.Length / 2; i++)
            {
                char buff = ipPart[i];
                ipPart[i] = ipPart[ipPart.Length - 1];
                ipPart[ipPart.Length - 1] = buff;
            }
            if (byte.TryParse(ipPart.ToString(), out byte result))
            {
                return result;
            }
            return null;
        }

        /// <summary>
        /// Gets part of ip after point
        /// </summary>
        /// <returns>Part of ip</returns>
        private byte? GetAfterPoint()
        {
            if (CurrentPosition >= StringToHandle.Length || StringToHandle[CurrentPosition] != '.')
            {
                return null;
            }
            StringBuilder ipPart = new StringBuilder(3);         
            CurrentPosition++;
            for (int j = 0; CurrentPosition < StringToHandle.Length && j < 3; CurrentPosition++, j++)
            {
                if (char.IsDigit(StringToHandle[CurrentPosition]))
                {
                    ipPart.Append(StringToHandle[CurrentPosition]);
                }
                else
                {
                    break;
                }
            }
            if (ipPart.Length == 0)
            {
                return null;
            }
            if (byte.TryParse(ipPart.ToString(), out byte result))
            {
                return result;
            }
            return null;
        }

        public IPGetter(string str)
        {
            StringToHandle = str;
            CurrentPosition = 0;
            IPs = new List<string>();
        }

        /// <summary>
        /// Gets IPs from string
        /// </summary>
        /// <returns>IPs as strings</returns>
        public List<string> GetIPs()
        {
            for (; CurrentPosition < StringToHandle.Length; CurrentPosition++)
            {
                if (StringToHandle[CurrentPosition] == '.')
                {
                    PointPosition = CurrentPosition;
                    List<byte?> ip = new List<byte?>();
                    ip.Add(GetBeforePoint());
                    for (int i = 0; i < 3; i++)
                    {
                        ip.Add(GetAfterPoint());
                    }
                    if (ip.All(x => x != null))
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(ip[0]);
                        for (int i = 0; i < 3; i++)
                        {
                            stringBuilder.Append('.');
                            stringBuilder.Append(ip[i + 1]);
                        }
                        IPs.Add(stringBuilder.ToString());
                    }
                    CurrentPosition = PointPosition;
                }
            }
            return IPs;
        } 
    }
}
