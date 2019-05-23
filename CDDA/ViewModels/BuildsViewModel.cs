using CDDA.Models;
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
        public BuildsViewModel(IBuildsRepository buildsRepository)
        {
            _buildsRepository = buildsRepository;
        }

        public List<Build> BuildList { get; set; }


        public BuildsViewModel GenerateViewModel()
        {
            var content = _buildsRepository.GetStaticBuilds();
            var model = new BuildsViewModel(_buildsRepository)
            {
                BuildList = content.BuildList
            };

            foreach (var build in model.BuildList)
            {
                foreach (var changeSet in build.ChangesetList)
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
            }
            return model;
        }
    }
}
