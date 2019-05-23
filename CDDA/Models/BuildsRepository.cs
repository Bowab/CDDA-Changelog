using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CDDA.Models
{
    public class BuildsRepository : IBuildsRepository
    {
        private static readonly string _baseAdress = "https://ci.narc.ro/job/Cataclysm-Matrix/api/";
        private static Builds _builds;

        public static void SetStaticBuilds()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAdress);
                var responseTask = client.GetAsync("xml?tree=builds[number,timestamp,building,result,changeSet[items[msg]],runs[result,fullDisplayName]]&xpath=//build&wrapper=builds");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;

                    XmlRootAttribute xRoot = new XmlRootAttribute();
                    xRoot.ElementName = "builds";
                    xRoot.IsNullable = true;

                    XmlSerializer serializer = new XmlSerializer(typeof(Builds), xRoot);
                    StringReader rdr = new StringReader(readTask);
                    Builds resultingMessage = (Builds)serializer.Deserialize(rdr);
                    _builds = resultingMessage;
                }
                else
                {
                    _builds = new Builds();
                }
            }
        }

        public Builds GetStaticBuilds()
        {
            return _builds;
        }
    }
}
