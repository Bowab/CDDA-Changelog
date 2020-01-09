using CDDA.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CDDA.ViewModels
{
    public class BuildsViewModel
    {
        private readonly IBuildsRepository _buildsRepository;
        public List<Build> BuildList { get; set; }

        private IHostingEnvironment _env { get; set; }


        public BuildsViewModel(IBuildsRepository buildsRepository, IHostingEnvironment env)
        {
            _env = env;
            _buildsRepository = buildsRepository;
        }

        public BuildsViewModel GenerateViewModel()
        {

            // 1. Skriv content till fil.

            // 2. Kolla om filen är gammal eller ny.

            // 3. Hämta fil om ny och gör till model, annars skriv ner den på fil

            var content = _buildsRepository.GetStaticBuilds();



            



            if (content.BuildList == null)
                return this;
            else
            {
                //var model = new BuildsViewModel(_buildsRepository)
                //{
                //    BuildList = content.BuildList
                //};
                this.BuildList = content.BuildList;

                foreach (var build in this.BuildList)
                {
                    foreach (var changeSet in build.ChangesetList)
                    {
                        if (changeSet.ItemList.Any())
                        {

                            foreach (var item in changeSet.ItemList)
                            {
                                if (item.Msg.Contains("#"))
                                {
                                    Regex pattern = new Regex(@"\#(.\d+)");
                                    var result = Regex.Matches(item.Msg, pattern.ToString());
                                    StringBuilder sb = new StringBuilder();
                                    foreach (Match m in result)
                                    {
                                        string add = m.Groups[1].Value;
                                        sb.Append(add);
                                    }
                                    item.GitHashNumber = sb.ToString();

                                    int index = item.Msg.LastIndexOf("(");
                                    if (index > 0)
                                    {
                                        item.Msg = item.Msg.Substring(0, index);
                                    }
                                }
                            }
                        }
                        else
                        {
                            var item = new Item
                            {
                                Msg = "No changes, same code as previous build!"
                            };
                            changeSet.ItemList.Add(item);
                        }
                    }
                }


                // START Skriva till och hämta från cache

                var rootCachePath = @"Cache\builds.txt";
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(_env.ContentRootPath, "Cache"));
                var cachePath = System.IO.Path.Combine(_env.ContentRootPath, rootCachePath);

                var cacheModel = new BuildCache(this, DateTime.Now);
                string serializeContent = JsonConvert.SerializeObject(cacheModel);
                System.IO.File.WriteAllText(cachePath, serializeContent);

                var deserializeContent = System.IO.File.ReadAllText(@"C:\Users\Bowa\Desktop\cddamvc\CDDA\Cache\builds.txt", Encoding.UTF8);
                var fromCacheModel = JsonConvert.DeserializeObject<BuildCache>(deserializeContent);
                
                // END

                return this;
            }
        }
    }
}
