﻿/*LEO
 * Copyright (C) Dawn of Reckoning 2019
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common;
using FrameWork;

  
namespace WorldServer
{
    [GeneralScript(false, "Poster Doors Scrypt", 0, 242)]// postern doors
    public class DoorScript : AGeneralScript
    {
        public override void OnInteract(Object Obj, Player Target, InteractMenu Menu)
        {
            GameObject go = Obj.GetGameObject();

            float dx = go.Spawn.WorldX - Target._Value.WorldX;
            float dy = go.Spawn.WorldY - Target._Value.WorldY;

            double heading = Math.Atan2(-dx, dy);

            if (heading < 0)
                heading += 4096;

            int distance = (int)((float)5 * 13.2f);
            double angle = heading;
            double targetX = go.Spawn.WorldX - (Math.Sin(angle) * distance);
            double targetY = go.Spawn.WorldY + (Math.Cos(angle) * distance);

            int newX;
            int newY;

            if (targetX > 0)
                newX = (int)targetX;
            else
                newX = 0;

            if (targetY > 0)
                newY = (int)targetY;
            else
                newY = 0;

            Target.SafeWorldTeleport((uint)newX, (uint)newY, (ushort)go.Spawn.WorldZ, (ushort)Target._Value.WorldO);
        }
    }
}