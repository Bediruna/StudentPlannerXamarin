using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace StudentPlannerXamarin.DataModels
{
    [Table("Assessment")]
    public class Assessment
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int TermId { get; set; }
        public int CourseId { get; set; }
        [MaxLength(8)]
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
    }
}
