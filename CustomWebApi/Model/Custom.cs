using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetaPoco;

namespace CustomWebApi.Model
{
    [TableName("Custom")]
    [PrimaryKey("custom_id", AutoIncrement = true)]
    public class Custom
    {
        [Column("custom_id")]
        public int CustomId { get; set; }

        [Column("custom_name")]
        public string CustomName { get; set; }

        [Column("custom_age")]
        public string CustomAge { get; set; }

        [Column("custom_sex")]
        public string CustomSex { get; set; }

        [Column("custom_idcrad")]
        public string CustomIdCrad { get; set; }

        [Column("custom_phone")]
        public string CustomPhone { get; set; }
        

    }
}
