﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDDA.Models
{
    public interface IBuildsRepository
    {
        Builds GetStaticBuilds();
    }
}
