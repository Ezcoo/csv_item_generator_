using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVkuntoon
{
    class ItemMap : ClassMap<Item>
    {
        ItemMap()
        {
            Map(m => m.STR_ITEM_NAME).Index(0);
            Map(m => m.STR_ITEM_DESC).Index(1);
            Map(m => m.STR_ITEM_SCRIPT).Index(2);
            Map(m => m.STR_ITEM_WEIGHT).Index(3);
            Map(m => m.STR_ITEM_PRICE).Index(4);
            Map(m => m.STR_ITEM_INTERFACES).Index(5);
        }

    }

}
