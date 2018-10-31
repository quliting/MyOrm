using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmSource.Attribute
{
   public class PropertyAttribute:System.Attribute
   {
       public string tableName;

       public PropertyAttribute()
       {
           
       }

       public PropertyAttribute(string tableName)
       {
           this.tableName = tableName;
       }
    }
}
