using System;
using System.Collections.Generic;
using System.Text;
using LSL;

namespace GameServer
{
    class LSLPush
    {
        private static StreamOutlet outlet;

        private static string streamName = "HoloLens_LSL_Stream";
        private static string streamType = "ParadigmChanges";
        private static string streamId = "123456";
        private static int channelCount = 1;

        private static string[] msg;

        public static void InitializeLSL()
        {
            msg = new string[1];
            StreamInfo streamInfo = new StreamInfo(streamName, streamType, channelCount, LSL.LSL.IRREGULAR_RATE, LSL.channel_format_t.cf_string, streamId);
            XMLElement chans = streamInfo.desc().append_child("channels");
            chans.append_child("channel").append_child_value("label", "Paradigm Change");
            outlet = new StreamOutlet(streamInfo);
            Console.WriteLine("LSL Stream up and running!");
        }

        public static void PushOutletLSL(string _msg)
        {
            msg[0] = _msg;
            outlet.push_sample(msg);
            Console.WriteLine($"Message: \"{_msg}\" pushed into outlet!");
        }

    }
}
