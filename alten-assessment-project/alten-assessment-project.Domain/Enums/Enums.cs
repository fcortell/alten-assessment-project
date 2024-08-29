using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Enums
{
    public class Enums
    {
        public enum Code { Ca, De, Fr, Gb, Jp, Us };

        public enum Name { Canada, France, Germany, Japan, UnitedKingdom, UnitedStates };

        public enum Timezone { AmericaHalifax, AmericaNewYork, AsiaTokyo, EuropeBusingen, EuropeLondon, EuropeParis };

        public enum Genre { Action, Adventure, Anime, Comedy, Crime, Drama, Espionage, Family, Fantasy, History, Horror, Legal, Medical, Music, Mystery, Romance, ScienceFiction, Sports, Supernatural, Thriller, War, Western };

        public enum Language { English, Japanese };

        public enum Day { Friday, Monday, Saturday, Sunday, Thursday, Tuesday, Wednesday };

        public enum Time { Empty, The0900, The1200, The1300, The2000, The2030, The2100, The2130, The2200, The2230, The2300, The2330 };

        public enum Status { Ended, Running, ToBeDetermined };

        public enum TypeEnum { Animation, Documentary, Reality, Scripted, TalkShow };
    }
}
