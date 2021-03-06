﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApi.Model
{
    /// <summary>
    /// Task model.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Unique id of task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the task.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Priority of task.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Parent task of task.
        /// </summary>
        public ParentTask ParentTask { get; set; }

        /// <summary>
        /// Start date of the task.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the task.
        /// </summary>
        public DateTime? EndDate { get; set; }

        public bool IsComplete{ get; set; }
    }
}
