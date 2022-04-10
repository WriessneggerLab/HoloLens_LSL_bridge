using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class ServerLogic
    {
        public static void Update()
        {
            ThreadManager.UpdateMain();
        }
    }
}
