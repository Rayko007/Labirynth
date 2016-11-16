using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynth
{
    partial class ProjectManager
    {
        /* Useful variables & functions:
        ** List<Item> ItemContainer -- items created in the world.
        ** AddItem(...) - adds item to world, use this instead of direct adding.
        ** GetItem(string name) - gets item by it's name. Name agents for the convenient search.
        ** RemoveItem(Item item) - removes item from all the world, not just a direct removing.
        ** Agent -> ProcessSchedule() - a simple processes schedule for a customizable agent. Debug it before use!
        */
        List<Agent> Agents;


        //Main timer of the world - use it for logic processing.
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
