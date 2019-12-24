using System;
using SQLite;

namespace StudentPlannerXamarin.DataModels
{
    [Table("Instructor")]
    class Instructor
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
