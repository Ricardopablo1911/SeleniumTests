﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exemplo_2.Fixtures
{
    [CollectionDefinition("Chrome Driver")]
    public class CollectionFixture :ICollectionFixture<TestFixture>
    {

    }
}
