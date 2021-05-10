using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAppExercise.Models
{
    public class TodoItem
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int ID { get; set; }
        public string ItemName { get; set; }
        public bool Toggled { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeCompleted { get; set; }

    }
}
