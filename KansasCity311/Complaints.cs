using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KansasCity311
{
    public static class Complaints
    {
        public static string GetComplaint(string selection)
        {
            if (selection == "Bamboo")
            {
                return "Overgrown bamboo surrounding entire house. Bamboo is impeding sidewalks and falling into street. This is attracting wildlife such as racoons, feral cats, and rodents. Bamboo is an invasive species of plant, and beginning to grow into neighboring yards. The height of the bamboo exceeds the height of the house. Dried out bamboo is a fire hazard.";
            }
            else if (selection == "Sidewalk")
            {
                return "Sidewalks are impeded by over grown yard. Pedestrians are forced to cross the street in order to use side walk";
            }
            else if (selection == "Animals")
            {
                return "Raccoons, feral cats, and other wildlife are constantly seen living on the property and even entering/leaving openings in the home";
            }
            else if (selection == "Gutters")
            {
                return "Home is missing gutters on some sides and some gutters are not fastened to roof";
            }
            else if (selection == "Grass")
            {
                return "Overgrown grass in the front and back yard. Growth is on the roof, gutters, and entering the house. Infringing on neighboring yards, fences and properties. Signs of noxious plants like poison oak and poison ivy. Grass/brush is covering fire hydrant";
            }
            else if (selection == "Paint")
            {
                return "Paint on home is peeling and cracked on all sides";
            }
            else if (selection == "Limbs/Brush")
            {
                return "Limbs and brush in front and back yard impeding sidewalks. Attracting wild life like racoons and rodents";
            }
            else if (selection == "Roof")
            {
                return "Roof is in disrepair, noticeably loose shingles and holes in the roof";
            }
            else if (selection == "Guard Rails")
            {
                return "Home has damaged/missing guard rails on stairs leading to front door";
            }
            else if (selection == "Noxious Plants")
            {
                return "Noxious plants such as poison ivy and poison oak are growing in front, back and side yards";
            }
            else if (selection == "Vacant Dwelling")
            {
                return "This property is distinctly vacant. Yards are overgrown and littered with trash, brush, and limbs. Multiple open entrances on home.";
            }
            else if (selection == "Squatting")
            {
                return "Witnessed distinctly homeless peoples squatting and entering/leaving the property.";
            }
            else if (selection == "Open Entrance")
            {
                return "This property is vacant and there are open entrances into the home through windows and doors. Racoons have been seen entereing and leaving open attic windows";
            }
            else if (selection == "Vines Fence")
            {
                return "Overgrown back yard has vines growing through neighboring fences. This is destroying fencing";
            }
            else if (selection == "Litter/Trash/Rubbish")
            {
                return "Litter and trash constantly seen on property. Front porch contains building materials, brush, and other rubbish";
            }
            else if (selection == "Retaining Wall")
            {
                return "Collapsing retaining wall in back/side yard impeding onto neighboring properties and fences";
            }
            else if (selection == "Suspicious Activity")
            {
                return "Suspicious activity late at night, people entering and leaving through thick brush and open entrances on the home.";
            }
            else if (selection == "Big Kahuna")
            {
                return "It appears inspections have occured for this property, and notices have been sent to the owner, however no actions have yet occured. ";
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
