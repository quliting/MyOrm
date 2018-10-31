using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrmSource.Attribute;

namespace OrmSource.Entity
{
    [Property("Phones")]
    public class Phones
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }
        public string Remake { get; set; }
        public DateTime ModifyTime { get; set; }
        public int Status { get; set; }
    }

    public enum ColumnKeyType
    {
        /// <summary>
        /// 默认状态
        /// </summary>
        Default = 1,

        /// <summary>
        /// 标识为主键
        /// </summary>
        Identity = 2,

        /// <summary>
        /// Extend 状态下，不参与读取增加、修改
        /// </summary>
        Extend = 4,

        /// <summary>
        /// Read 状态下不参与增加、修改
        /// </summary>
        Read = 8
    }
}
